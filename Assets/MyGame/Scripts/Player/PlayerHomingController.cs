using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomingController : MonoBehaviour
{

    Rigidbody rb;

    GameObject terget;
    [SerializeField]
    float speed = 1.0f;
    GameObject[] enemy;
    [SerializeField]
    bool flag_nav = false;

    StageController stageC;

    void Start()
    {
        if (flag_nav)
        {
            Destroy(gameObject, 7);
        }
        rb = this.GetComponent<Rigidbody>();
        Destroy(gameObject, 2);

        stageC = GameObject.Find("GameSetManager").GetComponent<StageController>();
    }

    void Update()
    {    
        if (stageC.getIsBoss())
        {
            terget = GameObject.FindGameObjectWithTag("Boss");
        }
        else if (flag_nav)
        {
            terget = GameObject.FindGameObjectWithTag("Enemy");
        }

        if (terget == null)
        {
            rb.velocity = transform.forward * speed;
            return;
        }
        transform.LookAt(Vector3.Lerp(transform.forward + transform.position, terget.transform.position, 10f));
        rb.AddForce(transform.forward * speed);
    }

    void OnCollisionStay(Collision other)
    {
        if (flag_nav)
        {
            return;
        }
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().ReceveDamage(100);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Stage" || other.gameObject.tag == "Bill")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (flag_nav)
        {
            return;
        }
        if (other.tag == "Enemy")
        {
            terget = other.gameObject;
        }
    }

    public void ReceveDamage(int damageScore)
    {
        Destroy(gameObject);
    }
}
