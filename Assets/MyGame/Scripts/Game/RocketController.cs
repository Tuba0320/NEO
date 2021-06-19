using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float speed;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        rb.AddForce(transform.forward * speed);
    }

    void OnCollisionEnter(Collision cl)
    {
        if (cl.gameObject.tag == "Player")
        {
            cl.gameObject.GetComponent<PlayerController>().ReceveDamage(5);
            Destroy(gameObject);
        }
        else if (cl.gameObject.tag == "Enemy")
        {
            cl.gameObject.GetComponent<EnemyController>().ReceveDamage(3000);
            Destroy(gameObject);
        }
        else if (cl.gameObject.tag == "Bill")
        {
            Destroy(cl.gameObject);
            Destroy(gameObject);
        }
        else if (cl.gameObject.tag == "Stage" || cl.gameObject.tag == "Rocket")
        {
            Destroy(gameObject);
        }
    }
}
