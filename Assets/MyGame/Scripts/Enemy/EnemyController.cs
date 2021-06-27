using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    static SoundManager sm;
    static StageController stageC;
    Rigidbody rb;
    GameObject target;
    static Score score = new Score();
    static int cnt_find = 0;

    float scorePoint = 0.1f;

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

    [SerializeField]
    Slider slider = null;

    float cnt_se;

    void Start()
    {
        if (cnt_find < 1)
        {
            sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
            stageC = GameObject.Find("GameSetManager").GetComponent<StageController>();
            cnt_find++;
        }
        target = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 10);
        scorePoint = scorePoint * hp;
        rb = GetComponent<Rigidbody>();
        if (hp == 1)
        {
            return;
        }
        slider.maxValue = hp;
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
        if (hp <= 1)
        {
            return;
        }
        slider.value = hp;
        slider.transform.LookAt(GameObject.FindWithTag("Player").transform);
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
            EnemyDestory();
        }
    }

    public void EnemyDestory()
    {
        Instantiate(particle, this.transform.position, Quaternion.identity);
        if (Item != null)
        {
            Instantiate(Item, this.transform.position, Quaternion.identity);
        }
        score.EnemyDefeatAddScore((int)scorePoint);
        stageC.EnemyPoint = stageC.EnemyPoint + (int)scorePoint;
        sm.PlaySeByName("爆発2");
        Destroy(this.gameObject);
    }
}
