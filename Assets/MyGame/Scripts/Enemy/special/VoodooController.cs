using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoodooController : MonoBehaviour
{
    [SerializeField]
    float interval = 5.0f;
    float time;

    [SerializeField]
    float stopInterval = 3.0f;
    float stopTime;
    bool stopFlag = false;

    void Update()
    {
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
            }
        }
    }
}
