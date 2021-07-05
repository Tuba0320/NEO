using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    GameObject[] spawners;
    GameObject currentSpawner = null;
    int spawnerNum = 0;
    int spawner_cnt = 0;

    [SerializeField]
    GameObject scoreView;
    int viewCnt = 0;

    [SerializeField]
    GameObject[] Field;

    float cnt_v1 = 0f;

    float interval_bill = 2f;
    float cnt_bill = 0f;

    int enemyPoint = 0;
    public int EnemyPoint
    {
        get { return enemyPoint; }
        set { enemyPoint = value; }
    }

    static Score score;
    static GameObject gameManager;
    CountTime time;
    static int cnt_find = 0;

    void Start()
    {
        if (cnt_find < 1)
        {
            gameManager = GameObject.Find("GameManager");
            score = new Score();
            cnt_find++;
        }
        time = GameObject.Find("MainCanvas").transform.Find("Time").GetComponent<CountTime>();
    }

    void Update()
    {

        cnt_v1 += Time.deltaTime;
        cnt_bill += Time.deltaTime;

    }

    void FixedUpdate()
    {
        if (cnt_bill >= interval_bill)
        {
            float y = Random.Range(250f, -250f);
            GameObject.Instantiate(Field[Random.Range(0,Field.Length)], GetFieldPosition(), Quaternion.Euler(0f, y, 0f));
            cnt_bill = 0;
        }

        if (cnt_v1 < 3)
        {
            return;
        }

        SpwanersControl();
    }

    void SpwanersControl()
    {
        if (spawnerNum > spawners.Length - 1)
        {
            GameClear();
            return;
        }

        if (spawner_cnt < 1)
        {
            currentSpawner = Instantiate(spawners[spawnerNum], new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, 0f));
            spawner_cnt++;
        }

        if (currentSpawner == null)
        {
            return;
        }
        else if (currentSpawner.GetComponent<SpawnController>().GetIsClear())
        {
            Destroy(currentSpawner);
            spawner_cnt = 0;
            spawnerNum++;
        }
        
    }

    Vector3 GetFieldPosition()
    {
        float x = Random.Range(200f, -200f);
        return new Vector3(x, 25, -450);
    }

    void GameClear()
    {
        if (viewCnt < 1)
        {
            time.TimeSave();
            score.AddScore(gameManager.GetComponent<RestManager>().Rest, time.getTime(),enemyPoint);
            gameManager.GetComponent<StageManager>().IsStageClear++;
            gameManager.GetComponent<SoundManager>().StopSe();
            scoreView.SetActive(true);
            viewCnt++;
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
