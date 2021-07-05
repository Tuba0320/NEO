using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillController : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Translate(0, 0, 1.5f, Space.World);
        if (transform.position.z >= 500)
        {
            Destroy(gameObject);
        }
    }

}
