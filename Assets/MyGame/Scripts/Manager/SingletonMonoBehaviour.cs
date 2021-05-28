using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instatnce;

    public static T Instance
    {
        get
        {
            if (instatnce == null)
            {
                instatnce = (T)FindObjectOfType(typeof(T));

                    if (instatnce == null)
                {
                    Debug.LogError(typeof(T) + "がシーンに存在しません");
                }
            }
            return instatnce;
        }
    }
}
