using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
    [SerializeField]
    private int minute;
    [SerializeField]
    private float seconds;

    private float oldSeconds;
    private Text timerText;

    static int s_minute = 0;
    static float s_seconds = 0f;

    [SerializeField]
    bool isStop = false;

    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStop) 
        {
            timerText.text = s_minute.ToString("00") + ":" + ((int)s_seconds).ToString("00");
            return;
        }

        seconds += Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }

        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
    }

    public float getTime()
    {
        return minute * 60f + seconds;
    }

    public void TimeSave()
    {
        s_minute = minute;
        s_seconds = seconds;
    }
}
