using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    static GameObject target;
    static int cnt_find = 0;

    [SerializeField]
    float speed = 1f;

    [SerializeField]
    bool[] MovePattern;
    [SerializeField]
    bool[] RotationPattern;

    float posX;
    float posY;
    float posZ;

    bool isReturn = false;
    bool antiFlag = false;

    [SerializeField]
    float interval = 9f;
    float cnt = 0f;

    void Awake()
    {
        SceneManager.sceneLoaded += TargetFind;
        if (cnt_find < 1)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            cnt_find++;
        }
    }

    void TargetFind(Scene sneneName, LoadSceneMode sceneMode)
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        posY = transform.position.y;
        posX = transform.position.x;
        if (transform.position.x >= 0)
        {
            antiFlag = true;
        }
    }

    void Update()
    {
        cnt += Time.deltaTime;
    }

    void FixedUpdate()
    {
        Move();
        Rotation();
        EnemyDestroy();
    }

    void Move()
    {
        for (int i = 0;i < MovePattern.Length;i++)
        {
            if (MovePattern[i])
            {
                switch (i)
                {
                    case 0:
                        MovePattern01();
                        break;
                    case 1:
                        MovePattern02();
                        break;
                    case 2:
                        MovePattern03();
                        break;
                    case 3:
                        MovePattern04();
                        break;
                    case 4:
                        MovePattern05();
                        break;
                    case 5:
                        MovePattern06();
                        break;
                }
            }
        }
    }

    void MovePattern01()
    {
        if (cnt >= interval)
        {
            Escape();
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, posY, transform.position.z + -0.05f);

        if (isReturn)
        {
            posY += 0.5f;
            if (posY + 10 > 100)
            {
                isReturn = false;
            }
        }
        else
        {
            posY -= 0.5f;
            if (posY - 10 < 0)
            {
                isReturn = true;
            }
        }

    }

    void MovePattern02()
    {
        transform.Translate(0, 0, 1.5f * speed, Space.World);
    }

    void MovePattern03()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void MovePattern04()
    {
        if (antiFlag)
        {
            transform.Translate(-1.5f * speed, 0, 0, Space.World);
        }
        else
        {
            transform.Translate(1.5f * speed, 0, 0, Space.World);
        }

        if (transform.position.x >= 250 || transform.position.x <= -250)
        {
            Destroy(gameObject);
        }
    }

    void MovePattern05()
    {
        if (target.transform.position.z - transform.position.z <= 50)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime * -1);
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime * 10);
    }

    void MovePattern06()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z + -0.1f);

        if (isReturn)
        {
            posX += 1f;
            if (posX + 10 > 150)
            {
                isReturn = false;
            }
        }
        else
        {
            posX -= 1f;
            if (posX - 10 < -150)
            {
                isReturn = true;
            }
        }
    }


    void EnemyDestroy()
    {
        if (target.transform.position.z < transform.position.z)
        {
            Destroy(gameObject);
        }
    }

    void Escape()
    {
        if (transform.position.x > 0)
        {
            transform.position = new Vector3(transform.position.x + 5f, posY + 1f, transform.position.z + 7.5f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + -5f, posY + 1f, transform.position.z + 7.5f);
        }

        EnemyDestroy();
    }

    void Rotation()
    {
        for (int i = 0; i < RotationPattern.Length; i++)
        {
            if (RotationPattern[i])
            {
                switch (i)
                {
                    case 0:
                        RotationPattern01();
                        break;
                    case 1:
                        RotationPattern02();
                        break;
                }
            }
        }
    }

    void RotationPattern01()
    {
        transform.LookAt(target.transform);
    }

    void RotationPattern02()
    {
        transform.Rotate(new Vector3(0, 1, 0), 25);
    }
}
