using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField]
    float speed = 1;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    [SerializeField]
    int damageSorce = 1;
    [SerializeField]
    float destroyInterval = 1f;

    [SerializeField]
    bool isChage = false;
    [SerializeField]
    bool isHoming = false;

    void Start()
    {
        if (isHoming)
        {
            Destroy(transform.parent.gameObject, destroyInterval);
            return;
        }
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, destroyInterval);
    }

    void FixedUpdate()
    {
        if (isHoming)
        {
            return;
        }
        rb.AddForce(transform.forward * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        
            if (other.gameObject.tag == "Enemy")
            {
             other.gameObject.GetComponent<EnemyController>().ReceveDamage(damageSorce);
             if (isChage)
             {
                 return;
             }
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Stage" || other.gameObject.tag == "Bill")
        {
             if (isChage && other.gameObject.tag == "Bill")
             {
                 Destroy(other.gameObject);
                 return;
             }
             else if(isChage && other.gameObject.tag == "Stage")
             {
                 return;
             }
             Destroy(gameObject);
        }

    }
}
