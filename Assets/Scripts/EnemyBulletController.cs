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
    EnemyMuzzleController emc;

    void Start()
    {
        terget = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody>();
        emc = transform.parent.gameObject.GetComponent <EnemyMuzzleController> ();
        Destroy(gameObject, 5);
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
            emc.subNum();
            Destroy(gameObject);
        }

        if(other.tag == "Stage" || other.tag == "Bill")
        {
            emc.subNum();
            Destroy(gameObject);
        }
    }

    public void ReceveDamage(int damageScore)
    {
            emc.subNum();
            Destroy(gameObject);
    }
}
