using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    GameObject target;
    [SerializeField]
    float speed = 1.0f;

    float odd = 0f;

    SoundManager sound;

    void Start()
    {
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), 25);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            odd = Random.Range(0f, 100f);
            other.GetComponent<DeadlyContorller>().deadly = other.GetComponent<DeadlyContorller>().deadly + 5f;
            if (odd < 12.5)
            {
                other.GetComponent<PlayerController>().setPlayerHp(5);
            }
            if (odd < 0.1)
            {
                GameObject.Find("GameManager").GetComponent<RestManager>().addRest(1);
            }
            Destroy(this.gameObject);
        }
    }
}
