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

    private void Initialize()
    {
        score = 0;

        isNewRecoad = false;
    }

    public void AddScore(int rest,float time) {
        this.score += ScoreConversion(rest, time);
        s_score += this.score;
    }

    int ScoreConversion(int rest, float time)
    {
        int add = 0;
        if (time < 100f)
        {
            add += 300;
        }
        else if (time < 200f)
        {
            add += 100;
        }
        else 
        {
            add += 50;
        }

        if (rest >= 30)
        {
            add += 500;
        }
        else if (rest >= 20)
        {
            add += 300;
        }
        else if (rest >= 10)
        {
            add += 100;
        }
        return add;
    }

    public int getScore()
    {
        return s_score;
    }
}
