using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using System.Linq;

public class MySceneManager : MonoBehaviour
{
    float timeUp = 5.0f;
    float cnt = 0f;
    ScreenManager sm;

    float cnt_t = 0f;
    int cnt_s = 0;
    bool flag_t = false;

    void Start()
    {
        sm = GameObject.Find("SceneManager").GetComponent<ScreenManager>();
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

    void OnLevelWasLoaded()
    {
        cnt_t = 0f;
        cnt_s = 0;
        cnt = 0f;
    }

    public void GoMenuScene()
    {
        if (SceneManager.GetActiveScene().name == "TitleScene" && Input.GetMouseButton(0)|| flag_t)
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
            flag_t = false;
        }
    }

    public void GetToScene(string num)
    {
        SceneManager.LoadScene(num);
    }

    public void GoToStage()
    {
        Time.timeScale = 1;
        if (GetComponent<StageManager>().IsStageClear >= 6)
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
            GetComponent<SoundManager>().StopSe();
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            GetComponent<SoundManager>().StopSe();
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
        Score score = new Score();
        GetComponent<RestManager>().Rest = 3;
        GetComponent<StageManager>().IsStageClear = 0;
        score.Initialize();
        SceneManager.LoadScene("TitleScene");
    }

}
