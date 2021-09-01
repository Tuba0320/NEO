using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadlyContorller : MonoBehaviour
{
    [SerializeField]
    float interval_deadly = 15f;
    float cnt_deadly = 0f;
    float interval_deadly2 = 3f;
    float cnt_deadly2 = 0;
    public float deadly
    {
        get { return cnt_deadly; }
        set { cnt_deadly = value; }
    }
    [SerializeField]
    GameObject deadlyRange;
    static int deadlyNum = 0;
    int deadlyMax = 3;
    [SerializeField]
    Slider slider;
    [SerializeField]
    GameObject point;

    static GameObject gameManager;
    static int cnt_find = 0;

    void Start()
    {
        slider.maxValue = interval_deadly;
        if (cnt_find < 1)
        {
            gameManager = GameObject.Find("GameManager");
            cnt_find++;
        }
    }

    void Update()
    {
        cnt_deadly += Time.deltaTime;
        cnt_deadly2 += Time.deltaTime;
    }

    void FixedUpdate()
    {
        slider.value = cnt_deadly;
        Deadly();
        PointView();
    }

    void PointView()
    {
        if (deadlyNum >= 3)
        {
            point.transform.Find("Point03").gameObject.GetComponent<Image>().color = Color.red;
        }
        else
        {
            point.transform.Find("Point03").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (deadlyNum >= 2)
        {
            point.transform.Find("Point02").gameObject.GetComponent<Image>().color = Color.red;
        }
        else
        {
            point.transform.Find("Point02").gameObject.GetComponent<Image>().color = Color.black;
        }
        if (deadlyNum >= 1)
        {
            point.transform.Find("Point01").gameObject.GetComponent<Image>().color = Color.red;
        }
        else
        {
            point.transform.Find("Point01").gameObject.GetComponent<Image>().color = Color.black;
        }
    }

    void Deadly()
    {
        if (deadlyNum > 0 && Input.GetMouseButton(1) && cnt_deadly2 >= interval_deadly2)
        {
            gameManager.GetComponent<SoundManager>().PlaySeByName("オーラ2");
            Instantiate(deadlyRange, transform.position, Quaternion.identity, transform);
            deadlyNum--;
            cnt_deadly2 = 0;
        }
        if (cnt_deadly >= interval_deadly)
        {
            if (deadlyMax < deadlyNum + 1)
            {
                return;
            }
            deadlyNum++;
            cnt_deadly = 0;
        }
    }
}
