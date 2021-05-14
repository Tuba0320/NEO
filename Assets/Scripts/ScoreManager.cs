using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

namespace NCMB
{
    public class ScoreManager : MonoBehaviour
    {
        public int score { get; set; }
        public string name { get; private set; }

        public ScoreManager(int _score, string _name)
        {
            score = _score;
            name = _name;
        }

        public string print()
        {
            return name + ' ' + score;
        }

        public void save()
        {
            NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("ScoreManager");
            query.WhereEqualTo("Name", name);
            query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
            {
                if (e == null)
                {
                    objList[0]["Score"] = score;
                    objList[0].SaveAsync();
                }
            });
        }
        
        public void fetch()
        {
            NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("ScoreManager");
            query.WhereEqualTo("Name", name);
            query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
            {
                if (e == null)
                {
                    if (objList.Count == 0)
                    {
                        NCMBObject obj = new NCMBObject("ScoreManager");
                        obj["Name"] = name;
                        obj["Score"] = 0;
                        obj.SaveAsync();
                        score = 0;
                    }
                    else
                    {
                        score = System.Convert.ToInt32(objList[0]["Score"]);
                    }
                }
            });
        }
    }
}