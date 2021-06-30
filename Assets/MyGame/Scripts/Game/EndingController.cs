using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EndingController : MonoBehaviour
{
    [SerializeField]
    GameObject clear;
    [SerializeField]
    GameObject over;

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
            clear.SetActive(true);
            over.SetActive(false);
        }
        else
        {
            clear.SetActive(false);
            over.SetActive(true);
        }
    }
}
