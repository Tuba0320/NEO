using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatuzinController : MonoBehaviour
{
    [SerializeField]
    GameObject body;
    [SerializeField]
    float interval = 2.0f;
    float time;

    void Update()
    {
        time += Time.deltaTime;
        if (time <= interval)
        {
            body.SetActive(true);
        }
        else
        {
            body.SetActive(false);
        }
    }
}
