using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemys;
    [SerializeField]
    bool[] patternFlags = new bool[1];

    [SerializeField]
    float interval_spawn = 1f;
    float cnt_spawn = 0f;
    float interval_slowSpawn = 2f;
    float cnt_slowSpawn = 0f;
    int mainCnt = 0;

    bool isClear = false;

    [SerializeField]
    int posX = 0;
    int posY = 50;
    [SerializeField]
    int posZ = -450;

    void Update()
    {
        cnt_spawn += Time.deltaTime;
        cnt_slowSpawn += Time.deltaTime;
    }

    void FixedUpdate()
    {
        for (int i = 0;i < patternFlags.Length;i++)
        {
            if (patternFlags[i])
            {
                switch (i)
                {
                    case 0:
                        SpwanPattern01();
                        break;
                    case 1:
                        SpwanPattern02();
                        break;
                }
            }
        }
    }

    void SpwanPattern01()
    {
        if (mainCnt < 1)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject.Instantiate(enemys[0], new Vector3(posX, posY, posZ), Quaternion.Euler(0f, 0f, 0f));
                posX += 40;
                posY -= 5;
                posZ -= 10;
            }

            posY = 50;
            for (int i = 0; i < 10; i++)
            {
                GameObject.Instantiate(enemys[0], new Vector3(posX,posY, posZ), Quaternion.Euler(0f, 0f, 0f));
                posX -= 40;
                posY -= 5;
                posZ -= 10;
            }

            posX = 250;
            posY = 50;
            posZ = -550;
            for (int i = 0; i < 10; i++)
            {
                GameObject.Instantiate(enemys[0], new Vector3(posX, posY, posZ), Quaternion.Euler(0f, 0f, 0f));
                posX -= 40;
                posY -= 5;
                posZ -= 10;
            }

            posY = 50;
            for (int i = 0; i < 10; i++)
            {
                GameObject.Instantiate(enemys[0], new Vector3(posX, posY, posZ), Quaternion.Euler(0f, 0f, 0f));
                posX += 40;
                posY -= 5;
                posZ -= 10;
            }

            mainCnt++;
        }

        if (interval_spawn <= cnt_spawn)
        {
            GameObject.Instantiate(enemys[1], new Vector3(Random.Range(250, -250), 50, -450), Quaternion.Euler(0f, 0f, 0f));
            cnt_spawn = 0;
        }

        if (interval_slowSpawn <= cnt_slowSpawn)
        {
            GameObject.Instantiate(enemys[2], new Vector3(-250, 50, Random.Range(-350, -250)), Quaternion.Euler(0f, 0f, 0f));
            cnt_slowSpawn = 0;
        }

        if (mainCnt >= 1)
        {
            ClearDecision();
        }
    }

    void SpwanPattern02()
    {
        if (interval_spawn <= cnt_spawn)
        {
            GameObject.Instantiate(enemys[0], new Vector3(Random.Range(250, -250), 50, -450), Quaternion.Euler(0f, 0f, 0f));
            cnt_spawn = 0f;
        }

        if (cnt_slowSpawn >= 15)
        {
            ClearDecision();
        }
    }

    void ClearDecision()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys.Length == 0 && !isClear)
        {
            isClear = true;
        }
        else if (enemys.Length <= 10)
        {
            interval_spawn = 15f;
            interval_slowSpawn = 25f;
        }
    }

    public bool GetIsClear()
    {
        return isClear;
    }
}
