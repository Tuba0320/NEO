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

    StageController sc;
    bool gameClear = false;

    void Start()
    {
        sc = new StageController();
    }

    void Update()
    {
        if (sc.IsStageClear >= 3)
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
