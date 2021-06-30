using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    GameObject scoreView;
    int viewCnt = 0;

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
    GameObject[] Field;

    private int numberOfEnemy = 0;
    private float elapsedTime = 0f;

    float cnt_v1 = 0f;
    bool isClear = false;

    float interval_bill = 2f;
    float cnt_bill = 0f;

    int enemyPoint = 0;
    public int EnemyPoint
    {
        get { return enemyPoint; }
        set { enemyPoint = value; }
    }

    static Score score = new Score();
    CountTime time;
    static RestManager rest;
    static SoundManager sound;
    static StageManager stageM;
    static int cnt_find = 0;

    void Start()
    {
        if (cnt_find < 1)
        {
            stageM = GameObject.Find("GameManager").GetComponent<StageManager>();
            sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
            rest = GameObject.Find("GameManager").GetComponent<RestManager>();
            cnt_find++;
        }
        enemyNum = 0;
        for (int i = 0;i <  stageM.GetisStageClear();i++)
        {
            enemyNum++;
        }
        time = GameObject.Find("MainCanvas").transform.Find("Time").GetComponent<CountTime>();
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
            GotoClear();
            return;
        }

        if (cnt_v1 < 3)
        {
            return;
        }

        if (elapsedTime > apperNextTime)
        {
            GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemy.Length >= 15)
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

        return new Vector3(x, y, -250);
    }

    Vector3 GetFieldPosition()
    {
        float x = Random.Range(200f, -200f);
        return new Vector3(x, 25, -250);
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

    void GotoClear()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemy.Length == 0 && !isClear)
        {
            isClear = true;
        }

    }

    void GameClear()
    {
        if (isClear && viewCnt < 1)
        {
            time.TimeSave();
            score.AddScore(rest.getRest(), time.getTime(),enemyPoint);
            stageM.isClear();
            sound.StopSe();
            scoreView.SetActive(true);
            viewCnt++;
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public bool getIsBoss()
    {
        return isClear;
    }
}
