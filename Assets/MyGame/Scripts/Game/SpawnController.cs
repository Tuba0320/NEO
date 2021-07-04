using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemys;
    [SerializeField]
    bool[] patternFlags = new bool[1];

    float interval_spawn = 3f;
    float cnt_spawn = 0f;
    int spawnCnt = 0;

    bool isClear = false;

    [SerializeField]
    int posX = 0;
    int posY = 50;
    [SerializeField]
    int posZ = -250;

    void Update()
    {
        cnt_spawn += Time.deltaTime;
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
                        SpwanPattern0();
                        break;
                }
            }
        }
    }

    void SpwanPattern0()
    {
        if (spawnCnt < 1)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject.Instantiate(enemys[0], new Vector3(posX, posY, posZ), Quaternion.Euler(0f, 0f, 0f));
                posX += 40;
                posY -= 5;
                posZ -= 10;
            }

            posY = 50;
            for (int i = 0; i < 5; i++)
            {
                GameObject.Instantiate(enemys[0], new Vector3(posX,posY, posZ), Quaternion.Euler(0f, 0f, 0f));
                posX -= 40;
                posY -= 5;
                posZ -= 10;
            }

            posX = 250;
            posY = 50;
            posZ = -350;
            for (int i = 0; i < 5; i++)
            {
                GameObject.Instantiate(enemys[0], new Vector3(posX, posY, posZ), Quaternion.Euler(0f, 0f, 0f));
                posX -= 40;
                posY -= 5;
                posZ -= 10;
            }

            posY = 50;
            for (int i = 0; i < 5; i++)
            {
                GameObject.Instantiate(enemys[0], new Vector3(posX, posY, posZ), Quaternion.Euler(0f, 0f, 0f));
                posX += 40;
                posY -= 5;
                posZ -= 10;
            }

            spawnCnt++;
        }

        if (interval_spawn <= cnt_spawn)
        {
            GameObject.Instantiate(enemys[1], new Vector3(Random.Range(250, -250), 50, -250), Quaternion.Euler(0f, 0f, 0f));
            cnt_spawn = 0;
        }

        if (spawnCnt >= 1)
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
    }

    public bool GetIsClear()
    {
        return isClear;
    }
}
