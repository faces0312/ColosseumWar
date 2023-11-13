using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Pause : MonoBehaviour
{
    public GameObject pause_pannel;
    public GameObject sound_on;
    public GameObject sound_off;
    public AudioSource bgm;

    public GameObject give_up;

    public AudioSource pause_button;
    public AudioSource button;
    void Start()
    {
        pause_pannel.gameObject.SetActive(false);
        give_up.gameObject.SetActive(false);
        if (Data.Instance.gameData.sound==true)
        {
            sound_on.gameObject.SetActive(true);
            sound_off.gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.sound == false)
        {
            sound_on.gameObject.SetActive(false);
            sound_off.gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (Data.Instance.gameData.sound == false)
        {
            sound_on.gameObject.SetActive(false);
            sound_off.gameObject.SetActive(true);
            pause_button.gameObject.GetComponent<AudioSource>().enabled = false;
            button.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else if (Data.Instance.gameData.sound == true)
        {
            sound_on.gameObject.SetActive(true);
            sound_off.gameObject.SetActive(false);
            pause_button.gameObject.GetComponent<AudioSource>().enabled = true;
            button.gameObject.GetComponent<AudioSource>().enabled = true;
        }
    }
    public void Touch_Pause()
    {
        pause_button.Play();
        Time.timeScale = 0;
        pause_pannel.gameObject.SetActive(true);
    }
    public void Dis_Touch_Pause()
    {
        Time.timeScale = 1;
        pause_pannel.gameObject.SetActive(false);
        give_up.gameObject.SetActive(false);
    }
    public void Touch_Main()
    {
        button.Play();
        give_up.gameObject.SetActive(true);
    }
    public void Touch_Main_Ok()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
    public void Touch_Main_Cancel()
    {
        button.Play();
        give_up.gameObject.SetActive(false);
    }
    public void Touch_Sound_On()
    {
        Data.Instance.gameData.sound = true;
        sound_on.gameObject.SetActive(true);
        sound_off.gameObject.SetActive(false);
        bgm.Play();
    }
    public void Touch_Sound_Off()
    {
        Data.Instance.gameData.sound = false;
        sound_on.gameObject.SetActive(false);
        sound_off.gameObject.SetActive(true);
        bgm.Stop();
    }
}
