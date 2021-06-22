using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseView : MonoBehaviour
{
    [SerializeField]
    Text text;
    StageManager stageM;

    void Start()
    {
        stageM = GameObject.Find("GameManager").GetComponent<StageManager>();
    }

    void Update()
    {
        text.text = stageM.GetisStageClear().ToString();
    }
}
