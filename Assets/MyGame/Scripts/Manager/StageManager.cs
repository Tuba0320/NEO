using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StageManager : MonoBehaviour
{
    static int isStageClear = 0;

    public int GetisStageClear()
    {
        return isStageClear;
    }

    public void isClear()
    {
        isStageClear++;
    }

    public void ClearFlag()
    {
        isStageClear = 0;
    }

}
