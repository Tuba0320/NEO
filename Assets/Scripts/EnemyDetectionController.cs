using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDetectionController : MonoBehaviour
{
    [SerializeField]
    Image leftWarn;
    [SerializeField]
    Image rigitWarn;

    void Start()
    {
        leftWarn.enabled = false;
        rigitWarn.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Boss")
        {
            var enemyDirection = other.transform.position - transform.position;
            var angle = Vector3.Angle(transform.forward, enemyDirection);

            if (angle < 40)
            {
                leftWarn.enabled = true;
            }
            else if (angle > 40)
            {
                rigitWarn.enabled = true;
            }

        }
        else
        {
            leftWarn.enabled = false;
            rigitWarn.enabled = false;
        }
        
    }
}
