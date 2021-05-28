using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalloutController : MonoBehaviour
{
    [SerializeField]
    float interval = 2.0f;
    float time;

    void Update()
    {
        time += Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        if (time <= interval)
        {
            return;
        }
        if (other.tag == "Player")
        {
            time = 0;
            other.GetComponent<PlayerController>().ReceveDamage(1);
        }
    }
}
