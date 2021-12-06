using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoseController : MonoBehaviour
{
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject sceneManager;
    bool isPose = false;
    float cnt;
    
    void Update()
    {
        cnt += Time.deltaTime;
        if (cnt <= 3f)
        {
            return;
        }

        if (Input.GetKeyDown("p") && isPose)
        {
            menu.SetActive(false);
            Time.timeScale = 1f;
            isPose = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetKeyDown("p") && !isPose)
        {
            sceneManager.GetComponent<ScreenManager>().StopSe();
            menu.SetActive(true);
            Time.timeScale = 0f;
            isPose = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            return;
        }
    }
}
