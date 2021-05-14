using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    SoundManager sound;

    GameObject target;
    [SerializeField]
    int enemyHP = 3;
    [SerializeField]
    float speed = 1f;
    EnemyMuzzleController emc;
    [SerializeField]
    bool isRotate = false;
    [SerializeField]
    GameObject particle;
    GameObject typhoon;
    float cnt;
    float v_cnt;

    void Start()
    {
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        target = GameObject.FindGameObjectWithTag("Player");
        emc = transform.Find("EnemyMuzzleBtype").GetComponent<EnemyMuzzleController>();
    }

    void Update()
    {
        v_cnt += Time.deltaTime;
        cnt += Time.deltaTime;
        if (isRotate)
        {
            transform.Rotate(new Vector3(0, 1, 0),25);
        }
        else
        {
            transform.LookAt(target.transform);
        }
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider cl)
    {
        if (cl.gameObject.tag == "Player")
        {
            cl.GetComponent<PlayerController>().ReceveDamage(5);
            Destroy(gameObject);
        }
    }

    public void ReceveDamage(int damageSorce)
    {
        if (v_cnt >= 0.5) 
        {
            v_cnt = 0;
            sound.PlaySeByName("robo02");
        }
        enemyHP -= damageSorce;
        Debug.Log(damageSorce + "ダメージ与えました");
        if (enemyHP <= 0)
        {
            Instantiate(particle, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
