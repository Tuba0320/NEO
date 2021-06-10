using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    SoundManager sm;
    Rigidbody rb;
    GameObject target;

    [SerializeField]
    int hp = 3;

    [SerializeField]
    float speed = 1f;

    [SerializeField]
    bool isRotate = false;

    [SerializeField]
    GameObject particle;

    [SerializeField]
    GameObject Item = null;

    float cnt_se;

    void Start()
    {
        if (isRotate)
        {
            Destroy(gameObject, 15);
        }
        Destroy(gameObject, 50);
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        cnt_se += Time.deltaTime;
        Move();
    }

    void OnTriggerEnter(Collider cl)
    {
        if (cl.gameObject.tag == "Player")
        {
            cl.GetComponent<PlayerController>().ReceveDamage(3);
            Destroy(gameObject);
        }
    }

    void Move()
    {
        if (isRotate)
        {
            transform.Rotate(new Vector3(0, 1, 0), 25);
        }
        else
        {
            transform.LookAt(target.transform);
        }
        if (speed <= 0)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void ReceveDamage(int damage)
    {
        if (cnt_se >= 0.5) 
        {
            cnt_se = 0;
            sm.PlaySeByName("ロボットを殴る1");
        }
        hp -= damage;
        if (hp <= 0)
        {
            Instantiate(particle, this.transform.position, Quaternion.identity);
            float odd = Random.Range(1f, 100f);
            if (odd < 25 && Item != null)
            {
                Instantiate(Item, this.transform.position, Quaternion.identity);
            }
            sm.PlaySeByName("爆発2");
            Destroy(this.gameObject);
        }
    }
}
