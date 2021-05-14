using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneralMuzzleController : MonoBehaviour
{
    [SerializeField]
    GameObject[] BulletPrefab;
    [SerializeField]
    float[] shotInterval;
    [SerializeField]
    int[] bulletLimit;
    float timeCount;
    GameObject[] bullets = new GameObject[250];
    int[] n = new int[9];
    [SerializeField]
    bool isGeneral = false;

    PlayerController pc;

    void Start()
    {
        pc = transform.root.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (pc.GetStopFlag())
        {
            return;
        }

        timeCount += Time.deltaTime;
        if (timeCount >= shotInterval[0] && n[0] < bulletLimit[0] && Input.GetMouseButton(0) && !isGeneral)
        {
            timeCount = 0;
            bullets[n[0]] = Instantiate(BulletPrefab[0], transform.position, transform.rotation, transform);
            n[0]++;
        }
        else if (Input.GetMouseButton(1) && isGeneral && timeCount >= shotInterval[0] && n[0] < bulletLimit[0])
        {
            timeCount = 0;
            bullets[n[0]] = Instantiate(BulletPrefab[0], transform.position, transform.rotation);
            n[0]++;
        }
    }

    public void subNum()
    {
        n[0]--;
    }

    public void EraseAll()
    {
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
    }
}
