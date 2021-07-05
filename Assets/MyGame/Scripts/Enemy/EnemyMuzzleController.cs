using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMuzzleController : MonoBehaviour
{
    static GameObject target;
    static int cnt_find = 0;

    [SerializeField]
    bool Bflag = false;
    [SerializeField]
    GameObject enemyBulletPrefab;
    [SerializeField]
    float shotInterval = 1.0f;
    float timeCount;
    
    void Awake()
    {
        SceneManager.sceneLoaded += TargetFind;
        if (cnt_find < 1)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            cnt_find++;
        }
    }

    void TargetFind(Scene sneneName,LoadSceneMode sceneMode)
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        timeCount += Time.deltaTime;
    }

    void FixedUpdate()
    {
        transform.LookAt(target.transform);
        if (timeCount >= shotInterval)
        {
            timeCount = 0;
            if (Bflag)
            {
                Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity, transform);
            }
            else
            {
                Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
            }
        }
    }
}
