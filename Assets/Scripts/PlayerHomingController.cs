using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomingController : MonoBehaviour
{

    Rigidbody rb;

    GameObject terget;
    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    int damageSorce = 1;
    PlayerGeneralMuzzleController pmc;
    GameObject[] enemy;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        pmc = transform.parent.gameObject.GetComponent<PlayerGeneralMuzzleController>();
    }

    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length != 0)
        {
            terget = GameObject.FindGameObjectWithTag("Enemy"); 
        }
        else 
        {
            terget = GameObject.FindGameObjectWithTag("Boss"); 
        }

        if (terget == null)
        {
            rb.velocity = transform.forward * speed;
            return;
        }
        transform.LookAt(Vector3.Lerp(transform.forward + transform.position, terget.transform.position, 10f));
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().ReceveDamage(damageSorce);
            pmc.subNum();
            Destroy(gameObject);
        }

        if (other.tag == "Stage" || other.tag == "Bill")
        {
            pmc.subNum();
            Destroy(gameObject);
        }
    }

    public void ReceveDamage(int damageScore)
    {
        pmc.subNum();
        Destroy(gameObject);
    }
}
