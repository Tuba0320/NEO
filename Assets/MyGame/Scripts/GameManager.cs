using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    public class GameManager : MonoBehaviour
    {

    [SerializeField]
        Image fadeBoard;
        [SerializeField]
        Text cleared;
        float alfa;
        float textAlfa;
        float textBlinkDuration = 8f;
        bool alphaAdditionFlag, pressStartDoneFlag;

        void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            if (SceneManager.GetActiveScene().name == "MenuScene"|| SceneManager.GetActiveScene().name == "Config")
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            alfa = fadeBoard.color.a;
            textAlfa = cleared.color.a;
        }

    public void GetToOtherScene(string stage)
    {
        SceneManager.LoadScene(stage);
    }


    void Update()
        {
            BeforPressStart();
            if (Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().name == "TitleScene")
            {
                pressStartDoneFlag = true;
                StartCoroutine(FedeOut());
            }
        }

        public void ToGameOverScene()
        {
            StartCoroutine("GFadeOut");
        }

        public void ToGameClearScene()
        {
            StartCoroutine("CFadeout");
        }

        IEnumerator GFadeOut()
        {
            yield return new WaitForSeconds(5f);
            bool isFadeOut = true;
            float duration = 5f;

            while (isFadeOut)
            {
                alfa += Time.deltaTime / duration;
                fadeBoard.color = new Color(0f, 0f, 0f, alfa);

                if (alfa >= 1)
                {
                    isFadeOut = false;
                }
                yield return null;
            }
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("GameOverScene");
        }

        IEnumerator CFadeout()
        {
            yield return new WaitForSeconds(3f);
            bool isFeadOut = true;
            float duration = 3f;

            while (isFeadOut)
            {
                alfa += Time.deltaTime / duration;
                fadeBoard.color = new Color(0f, 0f, 0f, alfa);

                if (alfa >= 1)
                {
                    isFeadOut = false;
                }
                yield return null;
            }
            SceneManager.LoadScene("GameClearScene");
        }

        IEnumerator FedeOut()
        {
            bool isFadeOut = true;
            float fadeOutDuration = 3f;
            float textBlinkDuration = 0.3f;

            while (isFadeOut)
            {
                alfa += Time.deltaTime / fadeOutDuration;

                if (textAlfa >= 0.5f && !alphaAdditionFlag)
                {
                    textAlfa -= Time.deltaTime / textBlinkDuration;
                    cleared.color = new Color(cleared.color.r, cleared.color.g, cleared.color.b, textAlfa);
                    if (textAlfa <= 0.5f)
                    {
                        alphaAdditionFlag = true;
                    }
                }
                else if (textAlfa <= 1f)
                {
                    textAlfa += Time.deltaTime / textBlinkDuration;
                    cleared.color = new Color(cleared.color.r, cleared.color.g, cleared.color.b, textAlfa);

                    if (textAlfa >= 1f)
                    {
                        alphaAdditionFlag = false;
                    }
                }
                fadeBoard.color = new Color(fadeBoard.color.r, fadeBoard.color.g, fadeBoard.color.b, textAlfa);

                if (textAlfa >= 1)
                {
                    isFadeOut = false;
                }
                yield return null;
            }
            yield return new WaitForSeconds(1f);
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            SceneManager.LoadScene("MenuScene");
        }
        }

        void BeforPressStart()
        {
            if (textAlfa >= 0.5f && !alphaAdditionFlag && !pressStartDoneFlag)
            {
                textAlfa -= Time.deltaTime / textBlinkDuration;
                cleared.color = new Color(cleared.color.r, cleared.color.g, cleared.color.b, textAlfa);

                if (textAlfa <= 0.5f)
                {
                    alphaAdditionFlag = true;
                }
            }
            else if (textAlfa <= 1f && alphaAdditionFlag && !pressStartDoneFlag)
            {
                textAlfa += Time.deltaTime / textBlinkDuration;
                cleared.color = new Color(cleared.color.r, cleared.color.g, cleared.color.b, textAlfa);

                if (textAlfa >= 1f)
                {
                    alphaAdditionFlag = false;
                }
            }
        }
    }
