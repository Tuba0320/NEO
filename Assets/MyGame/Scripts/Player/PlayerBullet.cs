using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    Rigidbody rb;
    GameObject terget;
    GameObject[] enemy;

    [SerializeField]
    float speed = 1;
    [SerializeField]
    int damageSorce = 1;
    [SerializeField]
    float destroyInterval = 1f;

    [SerializeField]
    bool isHorming = false;
    [SerializeField]
    bool isNavigation = false;
    [SerializeField]
    bool isChage = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, destroyInterval);
    }

    void Update()
    {
        if (isNavigation)
        {
            terget = GameObject.FindGameObjectWithTag("Enemy");
        }

        if (terget == null || !isHorming)
        {
            rb.velocity = transform.forward * speed;
            return;
        }
        else if (terget != null && isHorming || isNavigation)
        {
            transform.LookAt(Vector3.Lerp(transform.forward + transform.position, terget.transform.position, 10f));
            rb.AddForce(transform.forward * speed);
        }

    }

    void OnCollisionStay(Collision other)
    {
        if (!isHorming)
        {
            return;
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().ReceveDamage(damageSorce);
            if (isChage)
            {
                return;
            }
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Stage" || other.gameObject.tag == "Bill")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isHorming)
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

            if (other.gameObject.tag == "Stage" || other.gameObject.tag == "Bill")
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
        else if (other.tag == "Enemy" && isHorming)
        {
            terget = other.gameObject;
        }

    }
}
