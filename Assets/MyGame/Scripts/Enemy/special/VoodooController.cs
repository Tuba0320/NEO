using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoodooController : MonoBehaviour
{
    static SoundManager sound;
    static int cnt_find = 0;

    [SerializeField]
    float interval = 5.0f;
    float time;

    [SerializeField]
    float stopInterval = 3.0f;
    float stopTime;
    bool stopFlag = false;

    void Start()
    {
        if (cnt_find < 1)
        {
            sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
            cnt_find++;
        }
    }

    void Update()
    {
        return;
        if (stopFlag)
        {
            stopTime += Time.deltaTime;
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    void OnTriggerStay(Collider other)
    {
        return;
        if (time <= interval)
        {
            stopFlag = false;
            return;
        }
        if (other.tag == "Player")
        {
            if (stopTime > stopInterval)
            {
                stopFlag = false;
                other.GetComponent<PlayerController>().SetStopFlag(false);
                stopTime = 0f;
                time = 0f;
                return;
            }
            else
            {
                stopFlag = true;
                other.GetComponent<PlayerController>().SetStopFlag(true);
                sound.PlaySeByName("敵ユニット出現");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        return;
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().SetStopFlag(false);
        }
    }
}
