using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    StageManager stageM;
    [SerializeField]
    int stageNum;

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
    GameObject Field;

    private int numberOfEnemy = 0;
    private float elapsedTime = 0f;

    private float cnt = 0f;
    bool isBoss = false;

    Score score;
    CountTime time;
    RestManager rest;

    void Start()
    {
        stageM = GameObject.Find("GameManager").GetComponent<StageManager>();
        time = GameObject.Find("MainCanvas").transform.Find("Time").GetComponent<CountTime>();
        rest = GameObject.Find("GameManager").GetComponent<RestManager>();
        score = new Score();
    }

    void Update()
    {

        StageUp();
        GameClear();

        if (numberOfEnemy >= maxNumOfEnemys)
        {
            GotoBoss();
            return;
        }

        if (cnt < 3)
        {
            return;
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime > apperNextTime)
        {
            ApperEnemy();

            apperNextTime = Random.Range(1f, 3f);
        }
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(100f, -100f);
        float y = Random.Range(15f, 40f);
        float z = Random.Range(100, -100f);

        return new Vector3(x, y, z);
    }

    Vector3 GetFieldPosition()
    {
        float x = Random.Range(750f, -750f);
        float y = Random.Range(100, 0f);
        float z = Random.Range(750f, -750f);

        return new Vector3(x, y, z);
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
        for (int i = 1;i < enemy.Length;i++)
        {
            if (enemyRate[i] > rate)
            {
                num = i;
            }
        }

        return num;
    }

    void StageUp()
    {
        cnt += Time.deltaTime;
        if (cnt <= 3)
        {
            GameObject.Instantiate(Field, GetFieldPosition(), Quaternion.Euler(0f, 0f, 0f));
        }
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
}
