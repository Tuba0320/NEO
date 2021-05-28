using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    void Start()
    {
        string[] saveStringList = new string[3];

        for (int i = 0; i < saveStringList.Length;i++)
        {
            string saveString = PlayerPrefs.GetString("Save_Data" + i, "No Data");
            Debug.Log(saveString);
        }

        for (int i = 0; i < saveStringList.Length; i++)
        {
            PlayerPrefs.SetString("Save_Data" + i, "Have Data" + i);
            PlayerPrefs.Save();
        }
    }
}
