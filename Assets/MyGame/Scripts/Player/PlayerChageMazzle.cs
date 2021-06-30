using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChageMazzle : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Slider slider;

    float interval_chage = 2f;
    float cnt_chage = 0f;

    static SoundManager sound;
    static int cnt_find = 0;

    void Start()
    {
        slider.maxValue = interval_chage;
        if (cnt_find < 1)
        {
            sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
            cnt_find++;
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            cnt_chage += Time.deltaTime;
        }
        else
        {
            cnt_chage = 0;
        }
    }

    void FixedUpdate()
    {
        if (cnt_chage >= interval_chage)
        {
            ChageShot();
        }
        if (cnt_chage == 0)
        {
            slider.gameObject.SetActive(false);
        }
        else
        {
            slider.gameObject.SetActive(true);
        }
        slider.value = cnt_chage;
    }

    void ChageShot()
    {
        sound.PlaySeByName("爆発3");
        Instantiate(bullet, transform.position, transform.rotation, transform);
        cnt_chage = 0;
    }
}
