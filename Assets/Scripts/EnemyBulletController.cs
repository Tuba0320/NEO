using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    Rigidbody rb;

    GameObject terget;
    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    int damageSorce = 1;

    void Start()
    {
        terget = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody>();
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        transform.LookAt(Vector3.Lerp(transform.forward + transform.position, terget.transform.position, 0.001f));
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().ReceveDamage(damageSorce);
            Destroy(gameObject);
        }

        if(other.tag == "Stage" || other.tag == "Bill")
        {
            Destroy(gameObject);
        }
    }

    public void ReceveDamage(int damageScore)
    {
            Destroy(gameObject);
    }
}
