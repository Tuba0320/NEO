using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneralMuzzleController : MonoBehaviour
{
    [SerializeField]
    GameObject[] BulletPrefab;
    [SerializeField]
    float[] shotInterval;
    float cnt_fire;
    [SerializeField]
    string seName = null;
    int num = 1;

    PlayerController pc;

    SoundManager soundM;

    void Start()
    {
        soundM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        pc = transform.root.GetComponent<PlayerController>();
    }

    void Update()
    {
        cnt_fire += Time.deltaTime;
    }

    void FixedUpdate()
    {

        if (pc.GetStopFlag())
        {
            return;
        }
        Fire();
    }

    void Fire()
    {
        if (cnt_fire >= shotInterval[0] && Input.GetMouseButton(0))
        {
            soundM.PlaySeByName(seName);
            cnt_fire = 0;
            Instantiate(BulletPrefab[0], transform.position, transform.rotation, transform);
        }
    }

}
