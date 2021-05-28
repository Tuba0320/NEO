using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
    Score score;
    Text text;
    
    void Start()
    {
        score = new Score();
        text = GetComponentInChildren<Text>();
    }

    void Update()
    {
        text.text = score.getScore().ToString("0000");
    }
}
