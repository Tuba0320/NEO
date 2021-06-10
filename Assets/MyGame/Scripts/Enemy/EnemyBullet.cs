using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody rb;
    GameObject terget;

    [SerializeField]
    bool isHoming = false;

    [SerializeField]
    float speed = 1f;
    [SerializeField]
    int damageSorce = 1;
    [SerializeField]
    float destroyInterval = 1f;

    void Start()
    {
        terget = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, destroyInterval);
    }

    void Update()
    {
        if (isHoming)
        {
            transform.LookAt(Vector3.Lerp(transform.forward + transform.position, terget.transform.position, 0.001f));
            rb.velocity = transform.forward * speed;
        }
        else
        {
            rb.AddForce(transform.forward * speed);
        }
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

}
