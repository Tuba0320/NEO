using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetsuoController : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("aaa");
            other.GetComponent<PlayerController>().SetAntiFlag(true);
        }
    }
}
