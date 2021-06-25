using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadlyRange : MonoBehaviour
{
    float interval = 1f;
    float cnt = 0f;
    Vector3 speed = new Vector3(1000, 1000, 1000);

    void Update()
    {
        cnt += Time.deltaTime;
        transform.localScale += speed * Time.deltaTime;
        if (cnt >= interval)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Bill" || other.gameObject.tag == "EnemyBullet")
        {        
            Destroy(other.gameObject);
        }
    }
}
