using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamaraController : MonoBehaviour
{
    [SerializeField]
    Image sight;
    [SerializeField]
    Text text;
    [SerializeField]
    GameObject main;
    [SerializeField]
    GameObject sub;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
            sight.enabled = false;
            text.enabled = true;
            sub.SetActive(true);
        }
        else
        {
            sight.enabled = true;
            text.enabled = false;
            sub.SetActive(false);
        }
    }
}
