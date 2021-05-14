using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletAtype : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    int damageSorce = 1;

    void Start()
    { 
        rb = this.GetComponent<Rigidbody>();
        Destroy(gameObject, 3);
    }

    void Update()
    {
        rb.AddForce(transform.forward * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().ReceveDamage(damageSorce);
            Destroy(gameObject);
        }

        if (other.tag == "Stage" || other.tag == "Bill" || other.tag == "Rocket")
        {
            Destroy(gameObject);
        }
    }

    public void ReceveDamage(int damageScore)
    {
        Destroy(gameObject);
    }
}
