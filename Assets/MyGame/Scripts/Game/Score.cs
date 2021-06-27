using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private NCMB.ScoreManager highScore;
    private bool isNewRecoad;

    int score = 0;
    static int s_score = 0;

    void Start()
    {
        Initialize();

        string name = FindObjectOfType<UserAuth>().currentPlayer();
        highScore = new NCMB.ScoreManager(0, name);
        highScore.fetch();
    }

    void Update()
    {
        if (highScore.score < score)
        {
            isNewRecoad = true;
            highScore.score = score;
        }
    }

    public void Save()
    {
        if (isNewRecoad)
        {
            highScore.save();
        }

        Initialize();
    }

    public void Initialize()
    {
        score = 0;
        s_score = 0;
        isNewRecoad = false;
    }

    public void AddScore(int rest,float time,int enemyPoint) {
        this.score += (int)(enemyPoint * (rest * 0.1f));
        s_score += this.score;
    }

    public void EnemyDefeatAddScore(int add)
    {
        this.score += add;
        s_score += this.score;
    }

    public int getScore()
    {
        return s_score;
    }
}
