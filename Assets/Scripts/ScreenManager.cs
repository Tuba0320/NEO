 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    Image fadeBoat;
    [SerializeField]
    Text text;

    float duration;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (SceneManager.GetActiveScene().name == "MenuScene" || SceneManager.GetActiveScene().name == "Config" || SceneManager.GetActiveScene().name == "Extra" || SceneManager.GetActiveScene().name == "ScoreView" || SceneManager.GetActiveScene().name == "LogIn" || SceneManager.GetActiveScene().name == "Score" || SceneManager.GetActiveScene().name == "Ending" || SceneManager.GetActiveScene().name == "Extra 1")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Update()
    {
        textFlashing();
    }

    public void StartFade()
    {
        StartCoroutine("Fadeout");
    }

    IEnumerator Fadeout()
    {
        float fadeBoatAlfa = 0f;
        yield return new WaitForSeconds(1f);
        bool isFeadOut = true;
        duration = 3f;

        while (isFeadOut)
        {
            fadeBoatAlfa += Time.deltaTime / duration * 20;
            fadeBoat.color = new Color(0f, 0f, 0f, fadeBoatAlfa);

            if (fadeBoatAlfa >= 1)
            {
                isFeadOut = false;
            }
            yield return null;
        }
    }

    void textFlashing()
    {
        float textAlfa = 1f;
        bool alphaAdditionFlag = true;
        duration = 8f;

        if (textAlfa >= 0.5f && !alphaAdditionFlag)
        {
            textAlfa -= Time.deltaTime / duration;
            text.color = new Color(text.color.r, text.color.g, text.color.b, textAlfa);

            if (textAlfa <= 0.5f)
            {
                alphaAdditionFlag = true;
            }
        }
        else if (textAlfa <= 1f && alphaAdditionFlag)
        {
            textAlfa += Time.deltaTime / duration;
            text.color = new Color(text.color.r, text.color.g, text.color.b, textAlfa);

            if (textAlfa >= 1f)
            {
                alphaAdditionFlag = false;
            }
        }
    }
}
