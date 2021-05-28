using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoseController : MonoBehaviour
{
    [SerializeField]
    Text text;
    bool isPose = false;
    float cnt;

    void Update()
    {
        cnt += Time.deltaTime;
        if (cnt <= 3f)
        {
            return;
        }

        if (Input.GetKeyDown("p") && isPose)
        {
            text.enabled = false;
            Time.timeScale = 1f;
            isPose = false;
        }
        else if (Input.GetKeyDown("p") && !isPose)
        {
            text.enabled = true;
            Time.timeScale = 0f;
            isPose = true;
            return;
        }
    }
}
