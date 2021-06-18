using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    StageManager stageM;
    [SerializeField]
    int stageNum;

    int enemyNum = 0;
    [SerializeField]
    GameObject[] enemy;
    [SerializeField]
    int[] enemyRate = {100,100,60 };
    [SerializeField]
    float apperNextTime = 5;
    [SerializeField]
    int maxNumOfEnemys = 5;
    [SerializeField]
    GameObject boss;
    [SerializeField]
    GameObject[] Field;

    private int numberOfEnemy = 0;
    private float elapsedTime = 0f;

    float cnt_v1 = 0f;
    float cnt_v2 = 0f;
    bool isStage = false;
    bool isBoss = false;

    float interval_bill = 2f;
    float cnt_bill = 0f;

    Score score;
    CountTime time;
    RestManager rest;

    void Start()
    {
        int cnt = 0;
        enemyNum = 0;
        stageM = GameObject.Find("GameManager").GetComponent<StageManager>();
        foreach(bool flag in stageM.GetisStageClear())
        {
            if (flag && cnt > 0)
            {
                enemyNum++;
            }
            cnt++;
        }
        time = GameObject.Find("MainCanvas").transform.Find("Time").GetComponent<CountTime>();
        rest = GameObject.Find("GameManager").GetComponent<RestManager>();
        score = new Score();
    }

    void Update()
    {

        cnt_v1 += Time.deltaTime;
        cnt_bill += Time.deltaTime;

        if (cnt_v1 < 3)
        {
            return;
        }

        elapsedTime += Time.deltaTime;

    }

    void FixedUpdate()
    {
        GameClear();

        if (cnt_bill >= interval_bill)
        {
            float y = Random.Range(250f, -250f);
            GameObject.Instantiate(Field[Random.Range(0,Field.Length)], GetFieldPosition(), Quaternion.Euler(0f, y, 0f));
            cnt_bill = 0;
        }

        if (numberOfEnemy >= maxNumOfEnemys)
        {
            GotoBoss();
            return;
        }

        if (cnt_v1 < 3)
        {
            return;
        }

        if (elapsedTime > apperNextTime)
        {
            GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemy.Length >= 10)
            {
                return;
            }

            ApperEnemy();

            apperNextTime = Random.Range(0.2f, 0.3f);
        }
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(150f, -150f);
        float y = Random.Range(40f, 70f);

        return new Vector3(x, y, -210);
    }

    Vector3 GetFieldPosition()
    {
        float x = Random.Range(200f, -200f);
        return new Vector3(x, 25, -190);
    }

    void ApperEnemy()
    {
        float randomRotationY = Random.value * 360f;

        GameObject.Instantiate(enemy[EnemySelect()], GetRandomPosition(), Quaternion.Euler(0f, randomRotationY, 0f));
        numberOfEnemy++;
        elapsedTime = 0f;
    }

    int EnemySelect()
    {
        int num = 0;
        int rate = Random.Range(0, 100);
        for (int i = 1;i < enemyNum + 3;i++)
        {
            if (enemyRate[i] > rate)
            {
                num = i;
            }
        }

        return num;
    }

    void GotoBoss()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemy.Length == 0 && !isBoss)
        {
            GameObject.Instantiate(boss, GetRandomPosition(), Quaternion.Euler(0f, 0f, 0f));
            isBoss = true;
        }

    }

    void GameClear()
    {
        GameObject[] boss = GameObject.FindGameObjectsWithTag("Boss");
        if (isBoss && boss.Length == 0)
        {
            time.TimeSave();
            Debug.Log(rest.getRest());
            Debug.Log(time.getTime());
            score.AddScore(rest.getRest(), time.getTime());
            stageM.isClear(stageNum);
            GameObject.Find("GameManager").GetComponent<MySceneManager>().ToGameClearScene();
        }
    }

    public bool getIsBoss()
    {
        return isBoss;
    }
}
