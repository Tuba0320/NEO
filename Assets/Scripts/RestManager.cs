using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestManager : MonoBehaviour
{
    private GameObject GMnager;

    public static int restNum = 30;

    [SerializeField]
    private Text restText = null;


    void Start()
    {
        GMnager = GameObject.Find("GameManager");
    }

    void Update()
    {
        if (restText == null)
        {
            return;
        }

        restText.text = restNum.ToString("0");
    }

    public void subRest()
    {

        restNum--;
        if (restNum < 0)
        {
            GMnager.GetComponent <MySceneManager>().ToGameOverScene(true);
        }
        else
        {
            GMnager.GetComponent <MySceneManager>().ToGameOverScene(false);
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
}
