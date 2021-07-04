using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestManager : MonoBehaviour
{
    public static int rest = 3;
    public int Rest
    {
        get { return rest; }
        set
        { 
            rest = value;
            if (rest < 0)
            {
                GetComponent<MySceneManager>().ToGameOverScene(true);
            }
        }
    }
}
