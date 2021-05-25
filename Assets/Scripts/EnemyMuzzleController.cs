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
    

    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= shotInterval)
        {
            timeCount = 0;
            if (Bflag)
            {
                Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity,transform);
            }
            else
            {
                Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
            }
        }
    }
}
