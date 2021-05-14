using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuzzleController : MonoBehaviour
{

    [SerializeField]
    GameObject BulletPrefab;
    [SerializeField]
    float shotInterval = 1.0f;
    [SerializeField]
    int bulletLimit = 5;
    float timeCount;
    GameObject[] bullets = new GameObject[100];
    int n = 0;

    void Start()
    {

    }

    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= shotInterval && n < bulletLimit && Input.GetMouseButton(0))
        {
            timeCount = 0;
                bullets[n] = Instantiate(BulletPrefab, transform.position, Quaternion.identity, transform);
                n++;
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
