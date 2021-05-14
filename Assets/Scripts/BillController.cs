using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillController : MonoBehaviour
{
    [SerializeField]
    int hp = 500;

    public void ReceveDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
