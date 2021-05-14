using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private float seconds = 4f;
    private float oldSecond = 0f;
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        seconds -= Time.deltaTime;
        if ((int)seconds != (int)oldSecond)
        {
            text.text = ((int)seconds).ToString("0");
        }

        if ((int)seconds == 0)
        {
            text.enabled = false;
        }
    }
}
