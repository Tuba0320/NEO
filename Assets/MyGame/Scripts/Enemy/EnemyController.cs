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
    bool isHoming = false;

    [SerializeField]
    GameObject particle;

    [SerializeField]
    GameObject Item = null;

    float cnt_se;

    void Start()
    {
        Destroy(gameObject, 10);
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.z >= 150 && !isHoming)
        {
            float x = Random.Range(100f, -100f);
            float y = Random.Range(75, 25f);
            transform.position = new Vector3(x, y, -200);
        }
        cnt_se += Time.deltaTime;
    }

    void FixedUpdate()
    {
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
        if (!isHoming)
        {
            transform.Translate(0, 0, 1.5f, Space.World);
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
            if (odd < 12.5 && Item != null)
            {
                Instantiate(Item, this.transform.position, Quaternion.identity);
            }
            sm.PlaySeByName("爆発2");
            Destroy(this.gameObject);
        }
    }
}
