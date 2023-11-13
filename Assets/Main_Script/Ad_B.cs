using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using GoogleMobileAds.Api;

public class Ad_B : MonoBehaviour
{
    public Button ad_button;
    public bool isTestMode;
    public TextMeshProUGUI numberoftime;//잔여횟수 전체 TEXT
    public TextMeshProUGUI time;//광고쿨타임 TEXT
    public GameObject adcool;//쿨타임중에 뜨는 이미지
    public GameObject adend;
    public GameObject coin;

    private void Awake()
    {
        LoadRewardAd();
    }
    void Start()
    {
        adcool.gameObject.SetActive(false);
        adend.gameObject.SetActive(false);
        numberoftime.text = Data.Instance.gameData.numberoftime_Number + " / 5";
        time.text = "3 : 00";
    }

    void Update()
    {
        ad_button.interactable = rewardAd.IsLoaded();
        if(Data.Instance.gameData.isAdsBuff==true)
        {
            coin.gameObject.SetActive(true);
        }
        else
        {
            coin.gameObject.SetActive(false);
        }
        if (adcool.gameObject.activeSelf == true)
            Data.Instance.gameData.is_Cool = true;
        if (Data.Instance.gameData.numberoftime_Number<0)
        {
            adend.gameObject.SetActive(true);
        }
        else
        {
            adend.gameObject.SetActive(false);
        }
        if (Data.Instance.gameData.time_Min < 0)
        {
            adcool.gameObject.SetActive(false);
            Data.Instance.gameData.is_Cool = false;
            Data.Instance.gameData.time_Min = 2;
        }
        if (Data.Instance.gameData.time_Sec < 0)
        {
            Data.Instance.gameData.time_Min -= 1;
            Data.Instance.gameData.time_Sec = 59;
        }

        if (Data.Instance.gameData.is_Cool == true)
        {
            adcool.gameObject.SetActive(true);
            Data.Instance.gameData.time_Sec -= Time.deltaTime;
            time.text = Data.Instance.gameData.time_Min + " : " + Mathf.Ceil(Data.Instance.gameData.time_Sec).ToString();
        }
        else
            time.text = "3 : 00";

        if (Data.Instance.gameData.numberoftime_Number < 0)
            adcool.gameObject.SetActive(true);
    }


    //광고 보기 버튼을 누르면 발동되는 함수
    const string rewardTestID = "ca-app-pub-3940256099942544/5224354917";
    const string rewardID = "ca-app-pub-7537224848353526/1309209751";
    RewardedAd rewardAd;

    void LoadRewardAd()
    {
        rewardAd = new RewardedAd(isTestMode ? rewardTestID : rewardID);
        rewardAd.LoadAd(GetAdRequest());
        rewardAd.OnUserEarnedReward += (sender, e) =>
        {
            Data.Instance.gameData.is_Cool = true;
            Data.Instance.gameData.numberoftime_Number -= 1;
            numberoftime.text = Data.Instance.gameData.numberoftime_Number + " / 5";
            Data.Instance.gameData.isAdsBuff = true;
            Data.Instance.SaveGameData();
        };
    }

    public void ShowRewardAd()
    {
        rewardAd.Show();
        LoadRewardAd();
    }

    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().Build();
    }
}
