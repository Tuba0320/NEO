using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EndingController : MonoBehaviour
{
    [SerializeField]
    Text clear;
    [SerializeField]
    Text over;

    StageManager stM;
    bool gameClear = false;

    void Start()
    {
        stM = GetComponent<StageManager>();
    }

    void Update()
    {
        if (stM.GetisStageClear() >= 7)
        {
            gameClear = true;
        }

        if (gameClear)
        {
            clear.enabled = true;
            over.enabled = false;
        }
        else
        {
            clear.enabled = false;
            over.enabled = true;
        }
    }
}
