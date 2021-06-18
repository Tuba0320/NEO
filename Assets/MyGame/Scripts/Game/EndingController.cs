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
    bool[] clearFlag = new bool[9];

    bool gameClear = true;

    void Start()
    {
        stM = GetComponent<StageManager>();
    }

    void Update()
    {
        foreach (bool flag in stM.GetisStageClear())
        {
            if (flag == false)
            {
                gameClear = false;
            }
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
