using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    static GameObject gameManager;
    static int cnt_find = 0;

    static float interva_se = 0.5f;
    static float cnt_se = 0f;

    GameObject target;
    [SerializeField]
    float speed = 1.0f;

    float odd = 0f;

    void Start()
    {
        if (cnt_find < 1)
        {
            gameManager = GameObject.Find("GameManager");
            cnt_find++;
        }
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        cnt_se += Time.deltaTime;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if (interva_se < cnt_se)
        {
            gameManager.GetComponent<SoundManager>().PlaySeByName("拳銃を撃つ");
            cnt_se = 0f;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            odd = Random.Range(0f, 100f);
            other.GetComponent<DeadlyContorller>().deadly = other.GetComponent<DeadlyContorller>().deadly + 1f;
            if (odd < 5)
            {
                other.GetComponent<PlayerController>().setPlayerHp(5);
            }
            if (odd < 0.01)
            {
                GameObject.Find("GameManager").GetComponent<RestManager>().Rest += 1;
            }
            Destroy(this.gameObject);
        }
    }
}
