using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    [SerializeField]
    Text text;

    void Start()
    {
        
    }

    void Update()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");

        text.text = enemy.Length.ToString("00");

    }
}
