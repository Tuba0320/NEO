using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMuzzleController : MonoBehaviour
{
    [SerializeField]
    bool Bflag = false;
    [SerializeField]
    GameObject enemyBulletPrefab;
    [SerializeField]
    float shotInterval = 1.0f;
    [SerializeField]
    int bulletLimit = 5;
    float timeCount;
    GameObject[] bullets = new GameObject[100];
    int n = 0;

    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= shotInterval && n < bulletLimit)
        {
            timeCount = 0;
            if (Bflag)
            {
                bullets[n] = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity, transform);
                n++;
            }
            else
            {
                Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
            }
        }
    }

    public void subNum()
    {
        n--;
    }

    public void EraseAll()
    {
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
    }
}
