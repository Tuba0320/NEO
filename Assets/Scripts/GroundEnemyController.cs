using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyController : MonoBehaviour
{
    [SerializeField]
    int enemyHP = 3;
    EnemyMuzzleController emc;

    void Start()
    {
        emc = transform.Find("EnemyMuzzleBtype").GetComponent<EnemyMuzzleController>();
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
            emc.EraseAll();
            Destroy(this.gameObject);
        }
    }
}
