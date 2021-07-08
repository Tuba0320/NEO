using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    static Score score;
    static GameObject gameManager;
    static StageController stageC;
    static int cnt_find = 0;

    float scorePoint = 0.1f;

    [SerializeField]
    int hp = 3;

    [SerializeField]
    GameObject particle;

    [SerializeField]
    GameObject Item = null;

    [SerializeField]
    Slider slider = null;

    float cnt_se;

    [SerializeField]
    int destroyCnt;

    void Start()
    {
        if (cnt_find < 1)
        {
            gameManager = GameObject.Find("GameManager");
            stageC = GameObject.Find("GameSetManager").GetComponent<StageController>();
            score = new Score();
            cnt_find++;
        }
        Destroy(gameObject, destroyCnt);
        scorePoint = scorePoint * hp;
        if (hp == 1)
        {
            return;
        }
        slider.maxValue = hp;
    }

    void Update()
    {
        cnt_se += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (hp <= 1)
        {
            return;
        }
        slider.value = hp;
    }

    void OnTriggerEnter(Collider cl)
    {
        if (cl.gameObject.tag == "Player")
        {
            cl.GetComponent<PlayerController>().ReceveDamage(3);
            Destroy(gameObject);
        }
    }

    public void ReceveDamage(int damage)
    {
        if (cnt_se >= 0.5) 
        {
            cnt_se = 0;
            gameManager.GetComponent<SoundManager>().PlaySeByName("ロボットを殴る1");
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
        gameManager.GetComponent<SoundManager>().PlaySeByName("爆発2");
        Destroy(this.gameObject);
    }
}
