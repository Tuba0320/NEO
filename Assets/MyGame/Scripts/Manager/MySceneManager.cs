using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using System.Linq;

public class MySceneManager : MonoBehaviour
{
    public string bgmName;
    ScreenManager sm;
    float timeUp = 5.0f;
    float cnt = 0f;
    bool flag = false;
    SoundManager sound;
    StageManager stage;
    RestManager restM;

    float cnt_t = 0f;
    bool flag_t = false;
    int cnt_s = 0;

    void Start()
    {
        stage = GetComponent<StageManager>();
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        sm = GetComponent<ScreenManager>();
        restM = GetComponent<RestManager>();
        if (!bgmName.Equals("no"))
        {
            sound.PlayBgmName(bgmName);
        }
    }

    void Update()
    {
        GoMenuScene();
        View();
        cnt += Time.deltaTime;

        if (flag_t)
        {
            cnt_t += Time.deltaTime;
        }
    }

    public void GoMenuScene()
    {
        if (Input.GetMouseButton(0) && SceneManager.GetActiveScene().name == "TitleScene" || flag_t)
        {
            flag_t = true;
            if (cnt_s == 0)
            {
                sm.StartFade();
                cnt_s++;
            }
            if (cnt_t < 2)
            {
                return;
            }
            SceneManager.LoadScene("MenuScene");
        }
    }

    public void GoToStage(string num)
    {
        if (stage.GetClear(Regex.Replace(num, @"[^0-9]", "")))
        {
            Debug.Log("すでにそのステージはクリアしています");
            return;
        }
        SceneManager.LoadScene(num);
    }

    public void GetToScene(string num)
    {
        SceneManager.LoadScene(num);
    }

    public void ToGameOverScene(bool isGameOver)
    {
        if (isGameOver)
        {
            sound.StopSe();
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            sound.StopSe();
            Scene load = SceneManager.GetActiveScene();
            SceneManager.LoadScene(load.name);
        }
        
    }

    public void ToGameClearScene()
    {
        sound.StopSe();
        SceneManager.LoadScene("GameClearScene");
    }

    void View()
    {
        if (SceneManager.GetActiveScene().name == "GameClearScene" || SceneManager.GetActiveScene().name == "GameOverScene")
        {
            flag = true;
        }

        if (cnt > timeUp && flag)
        {
            if (SceneManager.GetActiveScene().name == "GameOverScene")
            {
                SceneManager.LoadScene("Ending");
                return;
            }
            SceneManager.LoadScene("ScoreView");
        }
    }

    public void DataClear()
    {
        restM.setRest(5);
        stage.ClearFlag();
        SceneManager.LoadScene("TitleScene");
    }

    public void GoEnding()
    {
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            SceneManager.LoadScene("Ending");
        }
    }


}
