using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestManager : MonoBehaviour
{
    public static int restNum = 3;

    [SerializeField]
    private Text[] restText = null;

    void Update()
    {
        for (int i = 0;i < restText.Length;i++)
        {
            if (restText[i] == null)
            {
                return;
            }
            restText[i].text = restNum.ToString("0");
        }
    }

    public void subRest()
    {

        restNum--;
        if (restNum < 0)
        {
            GetComponent <MySceneManager>().ToGameOverScene(true);
        }
    }

    public int getRest()
    {
        return restNum;
    }

    public void setRest(int set)
    {
        restNum = set;
    }

    public void addRest(int add)
    {
        restNum += add;
    }
}
