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
    [SerializeField]
    bool isGeneral = false;
    int num = 1;

    PlayerController pc;

    bool flag_int = false;
    float interval_int = 15f;
    float cnt_int = 0f;

    SoundManager soundM;

    void Start()
    {
        soundM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        pc = transform.root.GetComponent<PlayerController>();
    }

    void Update()
    {
        ChangeBullet();
        if (flag_int)
        {
            cnt_int += Time.deltaTime;
            if (interval_int <= cnt_int)
            {
                shotInterval[0] = 0.4f;
                cnt_int = 0f;
                flag_int = false;
            }
        }

        if (pc.GetStopFlag())
        {
            return;
        }

        timeCount += Time.deltaTime;
        if (timeCount >= shotInterval[0] && Input.GetMouseButton(0) && !isGeneral)
        {
            soundM.PlaySeByName("ショット");
            timeCount = 0;
            Instantiate(BulletPrefab[0], transform.position, transform.rotation, transform);
        }
        else if (Input.GetMouseButton(1) && isGeneral && timeCount >= shotInterval[num])
        {
            soundM.PlaySeByName("ロケットランチャー");
            timeCount = 0;
            Instantiate(BulletPrefab[num], transform.position, transform.rotation);
        }
    }

    void ChangeBullet()
    {
        if (Input.GetKey("0"))
        {
            num = 0;
        }
        if (Input.GetKey("1"))
        {
            num = 1;
        }
    }

    public void setInterval(float num)
    {
        shotInterval[0] += num;
        if (shotInterval[0] < 0.15f)
        {
            shotInterval[0] = 0.15f;
        }
    }

    public void setIntevalFlag(bool flag)
    {
        flag_int = flag;
    }

    public int getNum()
    {
        return num;
    }

}
