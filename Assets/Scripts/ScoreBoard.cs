using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class ScoreBoard : MonoBehaviour
{
    public int currentRank = 0;
    public List<NCMB.ScoreManager> topRankers = null;
    public List<NCMB.ScoreManager> neighbors = null;

    public void fetchRank(int currentScore)
    {
        NCMBQuery<NCMBObject> rankQuery = new NCMBQuery<NCMBObject>("RankManager");
        rankQuery.WhereGreaterThan("Score", currentScore);
        rankQuery.CountAsync((int count, NCMBException e) =>
        {
            if (e != null)
            {

            }
            else
            {
                currentRank = count + 1;
            }
        });
    }

    public void fetchTopRankers()
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("ScoreManager");
        query.OrderByDescending("Score");
        query.Limit = 5;
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e != null)
            {

            }
            else
            {
                List<NCMB.ScoreManager> list = new List<NCMB.ScoreManager>();

                foreach (NCMBObject obj in objList)
                {
                    int s = System.Convert.ToInt32(obj["Score"]);
                    string n = System.Convert.ToString(obj["Name"]);
                    list.Add(new ScoreManager(s, n));
                }
                topRankers = list;
            }
        });
    }

    public void fetchNeighbors()
    {
        neighbors = new List<NCMB.ScoreManager>();

        int numSkip = currentRank - 3;
        if (numSkip < 0) numSkip = 0;

        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("ScoreManager");
        query.OrderByDescending("Score");
        query.Skip = numSkip;
        query.Limit = 5;
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e != null)
            {

            }
            else
            {
                List<NCMB.ScoreManager> list = new List<NCMB.ScoreManager>();
                foreach(NCMBObject obj in objList)
                {
                    int s = System.Convert.ToInt32(obj["Score"]);
                    string n = System.Convert.ToString(obj["Name"]);
                    list.Add(new ScoreManager(s, n));
                }
                neighbors = list;
            }
        });
    }
}
