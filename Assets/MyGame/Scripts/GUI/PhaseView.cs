using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseView : MonoBehaviour
{
    [SerializeField]
    Text text;
    static StageManager stageM;
    static int cnt_find = 0;

    void Start()
    {
        if (cnt_find < 1)
        {
            stageM = GameObject.Find("GameManager").GetComponent<StageManager>();
            cnt_find++;
        }
    }

    void Update()
    {
        text.text = stageM.GetisStageClear().ToString();
    }
}
