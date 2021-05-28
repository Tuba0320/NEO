using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    static int stageNum = 9;
    static bool[] isStageClear = new bool[stageNum];
    MySceneManager sceneM;

    [SerializeField]
    Text text = null;

    void Start()
    {
        int cnt = 0;
        foreach(bool flag in isStageClear){
            if (text == null)
            {
                break;
            }
            if (flag && cnt > 0)
            {
                text.enabled = false;
            }
            cnt++;
        }
        isStageClear[0] = true;
        sceneM = GetComponent<MySceneManager>();

        /*for (int i = 0;i <= 8;i++)
        {
            isStageClear[i] = true;
        }*/

        for (int i = 1; i <= 8;i++)
        {
            if (isStageClear[i])
            {
                continue;
            }
            return;
        }

        sceneM.GoEnding();
        Debug.Log("すべてのステージをクリアしました");
    }

    public void isClear(int num)
    {
        isStageClear[num] = true;
    }

    public bool GetClear(string num)
    {
        int n = Int32.Parse(num);
        return isStageClear[n];
    }

    public bool[] GetisStageClear()
    {
        return isStageClear;
    }

    public void ClearFlag()
    {
        isStageClear = new bool[stageNum];
    }

}
