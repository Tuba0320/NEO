using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestViewController : MonoBehaviour
{
    [SerializeField]
    Text[] texts;

    static GameObject gameManager;
    static int cnt_find = 0;

    void Start()
    {
        if (cnt_find < 1)
        {
            gameManager = GameObject.Find("GameManager");
            cnt_find++;
        }
    }

    void FixedUpdate()
    {
        foreach(Text text in texts)
        {
            text.text = gameManager.GetComponent<RestManager>().Rest.ToString();
        }
    }
}
