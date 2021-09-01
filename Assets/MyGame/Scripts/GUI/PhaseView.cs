using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseView : MonoBehaviour
{
    [SerializeField]
    Text text;
    StageController sc;

    void Start()
    {
        sc = new StageController();
    }

    void Update()
    {
        text.text = sc.IsStageClear.ToString();
    }
}
