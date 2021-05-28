using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    [SerializeField]
    Text text;
    float interval = 1f;
    float cnt = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        cnt += Time.deltaTime;
        if (interval < cnt)
        {
            GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
            text.text = enemy.Length.ToString("00");
            cnt = 0;
        }

    }
}
