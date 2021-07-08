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

    GameObject gameManager;
    bool gameClear = false;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        if (gameManager.GetComponent<StageManager>().IsStageClear >= 5)
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
