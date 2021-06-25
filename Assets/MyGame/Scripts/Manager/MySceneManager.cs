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
        Ending();
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

    public void GetToScene(string num)
    {
        SceneManager.LoadScene(num);
    }

    public void GoToStage()
    {
        Time.timeScale = 1;
        if (stage.GetisStageClear() >= 8)
        {
            SceneManager.LoadScene("GameClearScene");
            return;
        }
        SceneManager.LoadScene("Stage1");
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

    void Ending()
    {
        if (SceneManager.GetActiveScene().name == "GameClearScene" || SceneManager.GetActiveScene().name == "GameOverScene")
        {
            if (cnt > timeUp)
            {
                SceneManager.LoadScene("Ending");
            }
        }
    }

    public void DataClear()
    {
        restM.setRest(5);
        stage.ClearFlag();
        SceneManager.LoadScene("TitleScene");
    }

}
