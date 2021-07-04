using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    GameObject target;

    [SerializeField]
    float speed = 1f;
    
    [SerializeField]
    bool isHoming = false;
    [SerializeField]
    bool[] MovePattern;
    [SerializeField]
    bool[] RotationPattern;

    float posX;
    float posY;
    float posZ;

    bool isReturn = false;

    void Start()
    {
        posY = transform.position.y;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (transform.position.z >= 150 && !isHoming)
        {
            float x = Random.Range(100f, -100f);
            float y = Random.Range(75, 25f);
            transform.position = new Vector3(x, y, -200);
        }
    }

    void FixedUpdate()
    {
        Move();
        Rotation();
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
                }
            }
        }
    }

    void MovePattern01()//isHoming
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
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
        transform.Translate(0, 0, 1.5f, Space.World);
    }

    void MovePattern03()//isHoming
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
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
