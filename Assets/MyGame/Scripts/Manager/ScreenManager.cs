 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    string bgmName;
    [SerializeField]
    Image fadeBoat = null;
    [SerializeField]
    bool cursorView = false;
    float duration;

    static GameObject gameManager;
    int cnt_find = 0;

    void Start()
    {
        if (cnt_find < 1)
        {
            gameManager = GameObject.Find("GameManager");
            cnt_find++;
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (cursorView)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (!bgmName.Equals("none"))
        {
            gameManager.GetComponent<SoundManager>().PlayBgmName(bgmName);
        }
    }

    public void selectStage()
    {
        gameManager.GetComponent<MySceneManager>().GoToStage();
    }

    public void selectScene(string name)
    {
        if (name == "TitleScene")
        {
            gameManager.GetComponent<MySceneManager>().DataClear();
        }
        gameManager.GetComponent<MySceneManager>().GetToScene(name);
    }

    public void StartFade()
    {
        if (fadeBoat == null)
        {
            return;
        }

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

    /*void textFlashing()
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
    }*/
}
