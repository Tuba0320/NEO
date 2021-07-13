using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomingRange : MonoBehaviour
{
    GameObject terget;
    Rigidbody rb;

    [SerializeField]
    float speed = 1;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (terget != null)
        {
            transform.LookAt(Vector3.Lerp(transform.forward + transform.position, terget.transform.position, 10f));
            rb.AddForce(transform.forward * speed);
        }
        else
        {
            rb.AddForce(transform.forward * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (terget != null)
            {
                return;
            }
            terget = other.gameObject;
        }
    }
}
