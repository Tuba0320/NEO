using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestManager : MonoBehaviour
{
    private GameObject GMnager;

    public static int restNum = 5;

    [SerializeField]
    private Text[] restText = null;


    void Start()
    {
        GMnager = GameObject.Find("GameManager");
    }

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
            GMnager.GetComponent <MySceneManager>().ToGameOverScene(true);
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
