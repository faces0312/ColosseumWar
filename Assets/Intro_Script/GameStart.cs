using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using UnityEngine.UI;


public class GameStart : MonoBehaviour
{
    public GameObject wait;
    public float wait_time;

    void Awake()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) =>
        {

        });
        Data.Instance.gameData.today = DateTime.Now.Day - 31;
        if (Data.Instance.gameData.tomorrow == 0)
            Data.Instance.gameData.tomorrow = Data.Instance.gameData.today;

        if ((Data.Instance.gameData.today - Data.Instance.gameData.tomorrow) <= -2)
            Data.Instance.gameData.tomorrow = Data.Instance.gameData.today;

        if (Data.Instance.gameData.today >= Data.Instance.gameData.tomorrow)
        {
            Data.Instance.gameData.numberoftime_Number = 5;
            Data.Instance.gameData.is_Cool = false;
            Data.Instance.gameData.time_Min = 2;
            Data.Instance.gameData.time_Sec = 59;
            Data.Instance.gameData.tomorrow = DateTime.Now.Day - 30;
        }
    }

    private void Start()
    {
        wait_time = 0;
        wait.gameObject.SetActive(true);
    }
    private void Update()
    {
        if(wait_time<=5f)
        {
            wait_time += Time.deltaTime;
        }
        else if(wait_time>5f)
        {
            wait.gameObject.SetActive(false);
        }
    }
    public void GoGameStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Url1()
    {
        Application.OpenURL("https://cafe.naver.com/colosseumwars/4");
    }

    public void Url2()
    {
        Application.OpenURL("https://cafe.naver.com/colosseumwars/3");
    }
}
