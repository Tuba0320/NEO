using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyController : MonoBehaviour
{
    [SerializeField]
    int enemyHP = 3;

    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), 90);
    }

    public void ReceveDamage(int damageSorce)
    {
        enemyHP -= damageSorce;
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
