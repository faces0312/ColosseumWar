using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game_End : MonoBehaviour
{
    public Gm_InGame gm;
    public FollowCamera followCamera;
    public TextMeshProUGUI playtime_min;
    public TextMeshProUGUI playtime_sec;
    public TextMeshProUGUI playtime_money;
    public TextMeshProUGUI score;
    public TextMeshProUGUI score_money;
    public TextMeshProUGUI finalscore;
    public TextMeshProUGUI finalscore_money;
    public GameObject gomain;

    // Start is called before the first frame update
    void Start()
    {
        gomain.gameObject.SetActive(false);
        playtime_min.text = gm.playTime_min.text;
        playtime_sec.text = gm.playTime_second.text;
        playtime_money.text = null;
        score.text = null;
        score_money.text = null;
        finalscore.text = null;
        finalscore_money.text = null; ;

        StartCoroutine(PlayTimeMoney());
        StartCoroutine(Score());
        StartCoroutine(ScoreMoney());
        StartCoroutine(FinalScore());
        StartCoroutine(FinalMoney());
    }

    
    IEnumerator PlayTimeMoney()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        playtime_money.text = ((int)(((gm.playTime_Min * 60) + (gm.playTime_Second))/2)).ToString();
    }
    IEnumerator Score()
    {
        yield return new WaitForSecondsRealtime(0.6f);
        score.text = followCamera.score_text.text;
    }
    IEnumerator ScoreMoney()
    {
        yield return new WaitForSecondsRealtime(0.9f);
        score_money.text = (followCamera.score / 2).ToString();
    }
    IEnumerator FinalScore()
    {
        yield return new WaitForSecondsRealtime(1.2f);
        finalscore.text = ((int)(((gm.playTime_Min * 60) + (gm.playTime_Second)) + followCamera.score)).ToString();
    }
    IEnumerator FinalMoney()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        for(int i = 1; i<= ((((gm.playTime_Min * 60) + (gm.playTime_Second)) + followCamera.score)/2); i++)
        {
            finalscore_money.text = i.ToString();
            yield return new WaitForSecondsRealtime(0.0001f);
        }
        gomain.gameObject.SetActive(true);
    }

    public void GoMain()
    {
        Time.timeScale = 1;
        if(Data.Instance.gameData.isAdsBuff==true)
        {
            Data.Instance.gameData.gold += (int)((((gm.playTime_Min * 60) + (gm.playTime_Second)) + followCamera.score));
        }
        else if (Data.Instance.gameData.isAdsBuff == false)
        {
            Data.Instance.gameData.gold += (int)((((gm.playTime_Min * 60) + (gm.playTime_Second)) + followCamera.score) / 2);
        }
        if (Data.Instance.gameData.best_score< (((gm.playTime_Min * 60) + (gm.playTime_Second)) + followCamera.score))
        {
            Data.Instance.gameData.best_score = (int)(((gm.playTime_Min * 60) + (gm.playTime_Second)) + followCamera.score);
            Social.ReportScore(Data.Instance.gameData.best_score, GPGSIds.leaderboard, (bool success) => { });
        }
        Data.Instance.gameData.isAdsBuff = false;
        Data.Instance.SaveGameData();
        SceneManager.LoadScene("MainScene");
    }
}
