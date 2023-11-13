using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject settingpannel1;
    public GameObject settingpannel2;
    public GameObject sound_on;
    public GameObject sound_off;
    public GameObject effect_on;
    public GameObject effect_off;
    public GameObject cancel;

    public AudioSource sound;

    public GameObject reset;

    public AudioSource button;

    void Start()
    {
        reset.gameObject.SetActive(false);
        if (Data.Instance.gameData.sound == false)
        {
            sound_on.gameObject.SetActive(false);
            sound_off.gameObject.SetActive(true);

            sound.Stop();
        }
        else if (Data.Instance.gameData.sound == true)
        {
            sound_on.gameObject.SetActive(true);
            sound_off.gameObject.SetActive(false);

            sound.Play();
        }

        if (Data.Instance.gameData.effect == false)
        {
            effect_on.gameObject.SetActive(false);
            effect_off.gameObject.SetActive(true);
        }
        else if (Data.Instance.gameData.effect == true)
        {
            effect_on.gameObject.SetActive(true);
            effect_off.gameObject.SetActive(false);
        }

        settingpannel1.gameObject.SetActive(false);
        settingpannel2.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Data.Instance.gameData.effect == false)
        {
            button.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else if (Data.Instance.gameData.effect == true)
        {
            button.gameObject.GetComponent<AudioSource>().enabled = true;
        }
    }
    public void GoSetting()
    {
        button.Play();

        settingpannel1.gameObject.SetActive(true);
        settingpannel2.gameObject.SetActive(true);
    }
    public void Community()
    {
        button.Play();
        Application.OpenURL("https://cafe.naver.com/colosseumwars");
    }
    public void Url1()
    {
        button.Play();
        Application.OpenURL("https://cafe.naver.com/colosseumwars/3");
    }
    public void Url2()
    {
        button.Play();
        Application.OpenURL("https://cafe.naver.com/colosseumwars/4");
    }
    public void Reset_Game()
    {
        button.Play();
        reset.gameObject.SetActive(true);
    }
    public void Reset_Ok()
    {
        Data.Instance.gameData.gold = 0;
        Data.Instance.gameData.best_score = 0;
        Data.Instance.gameData.ticket = 0;
        Data.Instance.gameData.sound = true;
        Data.Instance.gameData.effect = true;
        Data.Instance.gameData.numberoftime_Number = 5;
        Data.Instance.gameData.is_Cool = false;
        Data.Instance.gameData.time_Min = 2;
        Data.Instance.gameData.time_Sec = 59;
        Data.Instance.gameData.today = 0;
        Data.Instance.gameData.tomorrow = 0;
        Data.Instance.gameData.wolf_lv = 0;
        Data.Instance.gameData.skeleton_lv = 0;
        Data.Instance.gameData.slime_lv = 0;
        Data.Instance.gameData.golem_lv = 0;
        Data.Instance.gameData.reaper_lv = 0;
        Data.Instance.gameData.have_golem = false;
        Data.Instance.gameData.have_reaper = false;

        Data.Instance.SaveGameData();
        Application.Quit();
    }
    public void Reset_Cancel()
    {
        button.Play();
        reset.gameObject.SetActive(false);
    }
    public void EffectOn()
    {
        button.Play();
        Data.Instance.gameData.effect = true;
        effect_on.gameObject.SetActive(true);
        effect_off.gameObject.SetActive(false);
        Data.Instance.SaveGameData();
    }
    public void EffectOff()
    {
        Data.Instance.gameData.effect = false;
        effect_on.gameObject.SetActive(false);
        effect_off.gameObject.SetActive(true);
        Data.Instance.SaveGameData();
    }
    public void SoundOn()
    {
        Data.Instance.gameData.sound = true;
        sound_on.gameObject.SetActive(true);
        sound_off.gameObject.SetActive(false);
        Data.Instance.SaveGameData();

        sound.Play();
    }
    public void SoundOff()
    {
        Data.Instance.gameData.sound = false;
        sound_on.gameObject.SetActive(false);
        sound_off.gameObject.SetActive(true);
        Data.Instance.SaveGameData();

        sound.Stop();

    }
    public void Cancel()
    {
        button.Play();
        reset.gameObject.SetActive(false);
        settingpannel1.gameObject.SetActive(false);
        settingpannel2.gameObject.SetActive(false);
        Data.Instance.SaveGameData();
    }
}
