using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GM_Ch : MonoBehaviour
{
    public Wolf_Profile wolf_profile;
    public Slime_Profile slime_profile;
    public Skeleton_Profile skeleton_profile;
    public Golem_Profile golem_profile;
    public Reaper_Profile reaper_profile;
    public GameObject cancel_profile;
    public TextMeshProUGUI gold;

    public GameObject gold_less;
    public float gold_less_time;

    //유닛 보유 여부
    public GameObject have_golem;
    public Button have_golem_button;
    public GameObject have_reaper;
    public Button have_reaper_button;

    public AudioSource sound;
    public AudioSource button;
    // Start is called before the first frame update
    void Start()
    {
        if(Data.Instance.gameData.sound == true)
        {
            sound.Play();
        }
        else if (Data.Instance.gameData.sound == false)
        {
            sound.Stop();
        }
        wolf_profile.gameObject.SetActive(false);
        slime_profile.gameObject.SetActive(false);
        skeleton_profile.gameObject.SetActive(false);
        golem_profile.gameObject.SetActive(false);
        reaper_profile.gameObject.SetActive(false);
        cancel_profile.gameObject.SetActive(false);

        gold_less_time = 0;
        gold_less.gameObject.SetActive(false);

    }
    private void Update()
    {
        if (Data.Instance.gameData.effect == false)
        {
            button.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else if (Data.Instance.gameData.effect == true)
        {
            button.gameObject.GetComponent<AudioSource>().enabled = true;
        }

        gold.text = Data.Instance.gameData.gold.ToString();
        if(gold_less_time>1f)
        {
            gold_less.gameObject.SetActive(false);
            gold_less.gameObject.transform.position = new Vector3(0, 0);
            gold_less_time = 0;
        }
        if(gold_less.gameObject.activeSelf==true)
        {
            gold_less_time += Time.deltaTime;
            gold_less.gameObject.transform.Translate(new Vector3(0, 0.001f));
        }

        if(Data.Instance.gameData.have_golem==false)
        {
            have_golem.gameObject.SetActive(false);
            have_golem_button.gameObject.GetComponent<Button>().interactable = false;
        }
        else if(Data.Instance.gameData.have_golem == true)
        {
            have_golem.gameObject.SetActive(true);
            have_golem_button.gameObject.GetComponent<Button>().interactable = true;
        }

        if (Data.Instance.gameData.have_reaper == false)
        {
            have_reaper.gameObject.SetActive(false);
            have_reaper_button.gameObject.GetComponent<Button>().interactable = false;
        }
        else if (Data.Instance.gameData.have_reaper == true)
        {
            have_reaper.gameObject.SetActive(true);
            have_reaper_button.gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void GoMain()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Wolf_Profile()
    {
        button.Play();
        wolf_profile.gameObject.SetActive(true);
        cancel_profile.gameObject.SetActive(true);
    }
    public void Slime_Profile()
    {
        button.Play();
        slime_profile.gameObject.SetActive(true);
        cancel_profile.gameObject.SetActive(true);
    }
    public void Skeleton_Profile()
    {
        button.Play();
        skeleton_profile.gameObject.SetActive(true);
        cancel_profile.gameObject.SetActive(true);
    }
    public void Golem_Profile()
    {
        button.Play();
        golem_profile.gameObject.SetActive(true);
        cancel_profile.gameObject.SetActive(true);
    }
    public void Reaper_Profile()
    {
        button.Play();
        reaper_profile.gameObject.SetActive(true);
        cancel_profile.gameObject.SetActive(true);
    }
    public void Cancel_Profile()
    {
        button.Play();
        wolf_profile.upgrade.gameObject.SetActive(false);
        slime_profile.upgrade.gameObject.SetActive(false);
        skeleton_profile.upgrade.gameObject.SetActive(false);
        golem_profile.upgrade.gameObject.SetActive(false);
        reaper_profile.upgrade.gameObject.SetActive(false);

        wolf_profile.ex.gameObject.SetActive(false);
        slime_profile.ex.gameObject.SetActive(false);
        skeleton_profile.ex.gameObject.SetActive(false);
        golem_profile.ex.gameObject.SetActive(false);
        reaper_profile.ex.gameObject.SetActive(false);

        wolf_profile.gameObject.SetActive(false);
        slime_profile.gameObject.SetActive(false);
        skeleton_profile.gameObject.SetActive(false);
        golem_profile.gameObject.SetActive(false);
        reaper_profile.gameObject.SetActive(false);
        cancel_profile.gameObject.SetActive(false);
    }
}
