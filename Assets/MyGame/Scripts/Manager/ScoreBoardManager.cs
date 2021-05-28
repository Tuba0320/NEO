using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardManager : MonoBehaviour
{

    private ScoreBoard sBoard;
    private NCMB.ScoreManager currentHighScore;
    public Text[] top = new Text[5];
    public Text[] nei = new Text[5];

    bool isScoreFetched;
    bool isRankFeched;
    bool isLeaderBoardFetched;

    private bool backButton;

    void Start()
    {
        sBoard = new ScoreBoard();

        isScoreFetched = false;
        isRankFeched = false;
        isLeaderBoardFetched = false;

        string name = FindObjectOfType<UserAuth>().currentPlayer();
        currentHighScore = new NCMB.ScoreManager(-1, name);
        currentHighScore.fetch();
    }

    void Update()
    {
        if (currentHighScore.score != -1 && !isScoreFetched)
        {
            sBoard.fetchRank(currentHighScore.score);
            isScoreFetched = true;
        }

        if (sBoard.currentRank != 0 && !isRankFeched)
        {
            sBoard.fetchTopRankers();
            sBoard.fetchNeighbors();
            isRankFeched = true;
        }

        if (sBoard.topRankers != null && sBoard.neighbors != null && !isLeaderBoardFetched)
        {
            int offset = 2;
            if (sBoard.currentRank == 1) offset = 0;
            if (sBoard.currentRank == 2) offset = 1;

            for (int i = 0; i < sBoard.topRankers.Count; ++i)
            {
                top[i].text = i + 1 + ". " + sBoard.topRankers[i].print();
            }

            for (int i = 0; i < sBoard.neighbors.Count; ++i)
            {
                nei[i].text = sBoard.currentRank - offset + i + ". " + sBoard.neighbors[i].print();
            }
            isLeaderBoardFetched = true;
        }
    }
}
