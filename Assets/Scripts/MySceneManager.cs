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
        GoLoginScene();
        View();
        cnt += Time.deltaTime;
    }

    public void GoLoginScene()
    {
        if (Input.GetMouseButton(0) && SceneManager.GetActiveScene().name == "TitleScene")
        {
            sm.StartFade();
            
            SceneManager.LoadScene("Login");
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
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            Scene load = SceneManager.GetActiveScene();
            SceneManager.LoadScene(load.name);
        }
        
    }

    public void ToGameClearScene()
    {
      // sm.Fadeout();
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
        //restM.setRest(3);
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
