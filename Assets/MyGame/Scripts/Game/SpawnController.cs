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
    [SerializeField]
    float interval_spawn01 = 2f;
    float cnt_spawn01 = 0f;
    [SerializeField]
    float interval_spawn02 = 1f;
    float cnt_spawn02 = 0f;
    [SerializeField]
    float interval_spawn03 = 0f;
    float cnt_spawn03 = 0f;
    int mainSpawnCnt = 0;

    float cnt_time = 0f;

    bool isClear = false;

    [SerializeField]
    int posX = 0;
    [SerializeField]
    int posY = 50;
    [SerializeField]
    int posZ = -450;

    void Update()
    {
        cnt_spawn += Time.deltaTime;
        cnt_spawn01 += Time.deltaTime;
        cnt_spawn02 += Time.deltaTime;
        cnt_spawn03 += Time.deltaTime;
        cnt_time += Time.deltaTime;
    }

    void FixedUpdate()
    {
        Spwan();
    }

    void Spwan()
    {
        for (int i = 0; i < patternFlags.Length; i++)
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
                    case 2:
                        SpwanPattern03();
                        break;
                    case 3:
                        SpwanPattern04();
                        break;
                    case 4:
                        SpwanPattern05();
                        break;
                    case 5:
                        SpawnPattern06();
                        break;
                }
            }
        }
    }

    void SpwanPattern01()
    {
        if (mainSpawnCnt < 1)
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject.Instantiate(enemys[0], new Vector3(posX, posY, posZ), Quaternion.Euler(0f, 0f, 0f));
                posX += 40;
                posY -= 5;
                posZ -= 10;
            }

            posY = 50;
            for (int i = 0; i < 8; i++)
            {
                GameObject.Instantiate(enemys[0], new Vector3(posX,posY, posZ), Quaternion.Euler(0f, 0f, 0f));
                posX -= 40;
                posY -= 5;
                posZ -= 10;
            }

            posX = 250;
            posY = 50;
            posZ = -550;
            for (int i = 0; i < 8; i++)
            {
                GameObject.Instantiate(enemys[0], new Vector3(posX, posY, posZ), Quaternion.Euler(0f, 0f, 0f));
                posX -= 40;
                posY -= 5;
                posZ -= 10;
            }

            posY = 50;
            for (int i = 0; i < 8; i++)
            {
                GameObject.Instantiate(enemys[0], new Vector3(posX, posY, posZ), Quaternion.Euler(0f, 0f, 0f));
                posX += 40;
                posY -= 5;
                posZ -= 10;
            }

            mainSpawnCnt++;
        }
        else
        {
            ClearDecision();
        }

        if (interval_spawn <= cnt_spawn)
        {
            MiniSpwanPattern01(1);
            cnt_spawn = 0;
        }

        if (interval_spawn01 <= cnt_spawn01)
        {
            GameObject.Instantiate(enemys[2], new Vector3(-250, 50, Random.Range(-400, -150)), Quaternion.Euler(0f, 90f, 0f));
            cnt_spawn01 = 0;
        }

        if (interval_spawn02 <= cnt_spawn02)
        {
            MiniSpwanPattern01(3);
            cnt_spawn02 = 0;
        }
    }

    void SpwanPattern02()
    {
        if (interval_spawn <= cnt_spawn)
        {
            MiniSpwanPattern01(0);
            cnt_spawn = 0f;
        }

        if (interval_spawn01 <= cnt_spawn01)
        {
            MiniSpwanPattern01(1);
            cnt_spawn01 = 0f;
        }

        if (interval_spawn02 <= cnt_spawn02)
        {
            int num = Random.Range(250, -250);
            if (num >= 0)
            {
                MiniSpwanPattern02(2, 1);
            }
            else
            {
                MiniSpwanPattern02(2, -1);
            }
            cnt_spawn02 = 0f;
        }

        if (cnt_time >= 20f)
        {
            ClearDecision();
        }
    }

    void SpwanPattern03()
    {
        if (interval_spawn <= cnt_spawn)
        {
            MiniSpwanPattern01(0);
            cnt_spawn = 0f;
        }

        if (interval_spawn01 <= cnt_spawn01)
        {
            MiniSpwanPattern01(1);
            cnt_spawn01 = 0f;
        }

        if (cnt_time >= 20f)
        {
            ClearDecision();
        }
    }

    void SpwanPattern04()
    {
        if (interval_spawn <= cnt_spawn)
        {
            MiniSpwanPattern01(0);
            cnt_spawn = 0f;
        }

        if (interval_spawn01 <= cnt_spawn01)
        {
            MiniSpwanPattern01(1);
            cnt_spawn01 = 0f;
        }

        if (interval_spawn02 <= cnt_spawn02)
        {
            MiniSpwanPattern01(2);
            cnt_spawn02 = 0f;
        }

        if (cnt_time >= 20f)
        {
            ClearDecision();
        }
    }

    void SpwanPattern05()
    {
        if (mainSpawnCnt >= 1 && cnt_time >= 20)
        {
            ClearDecision();
        }
        else if (mainSpawnCnt < 1)
        {
            for (int i = 0; i < 5; i++)
            {
                posX = -250;
                posY += 30;
                posZ = -450;
                for (int j = 0; j < 10; j++)
                {
                    GameObject.Instantiate(enemys[0], new Vector3(posX, posY, posZ), Quaternion.Euler(0f, 0f, 0f));
                    posX += 50;
                    posZ -= 50;
                }
            }
            mainSpawnCnt++;
        }

        if (interval_spawn <= cnt_spawn)
        {
            MiniSpwanPattern01(1);
            cnt_spawn = 0f;
        }

        if (interval_spawn01 <= cnt_spawn01)
        {
            MiniSpwanPattern01(2);
            cnt_spawn01 = 0f;
        }
    }


    void SpawnPattern06()
    {
        if (interval_spawn <= cnt_spawn)
        {
            MiniSpwanPattern01(0);
            cnt_spawn = 0f;
        }

        if (interval_spawn01 <= cnt_spawn01)
        {
            MiniSpwanPattern01(1);
            cnt_spawn01 = 0f;
        }

        if (interval_spawn02 <= cnt_spawn02)
        {
            int num = Random.Range(250, -250);
            if (num >= 0)
            {
                MiniSpwanPattern02(2, 1);
            }
            else
            {
                MiniSpwanPattern02(2, -1);
            }
            cnt_spawn02 = 0f;
        }

        if (interval_spawn03 <= cnt_spawn03)
        {
            MiniSpwanPattern01(3);
            cnt_spawn03 = 0f;
        }

        if (cnt_time >= 20)
        {
            ClearDecision();
        }
    }

    void MiniSpwanPattern01(int num)//最奥からPositionX250~-250の範囲で出現するパターン
    {
        GameObject.Instantiate(enemys[num], new Vector3(Random.Range(250, -250), 50, -450), Quaternion.Euler(0f, 0f, 0f));
    }

    void MiniSpwanPattern02(int num,int direction)//PositionZ450~-450の範囲で最も右または最も左に出現するパターン(引数のdirectionは1か-1のみを渡す)
    {
        if (direction != 1 && direction != -1)
        {
            return;
        }
        GameObject.Instantiate(enemys[num], new Vector3(250 * direction, 50, Random.Range(450, -450)), Quaternion.Euler(0f, 90f * -direction, 0f));
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
            interval_spawn = 30f;
            interval_spawn01 = 30f;
            interval_spawn02 = 30f;
            interval_spawn03 = 30f;
        }
    }

    public bool GetIsClear()
    {
        return isClear;
    }
}
