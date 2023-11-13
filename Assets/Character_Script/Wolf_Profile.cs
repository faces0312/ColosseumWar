using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wolf_Profile : MonoBehaviour
{
    public GM_Ch gm;
    public GameObject upgrade;
    public GameObject upgrade_button;
    //설명 파일
    public GameObject ex;
    //강화여부(별)
    public GameObject star1_X;
    public GameObject star1_O;
    public GameObject star2_X;
    public GameObject star2_O;
    public GameObject star3_X;
    public GameObject star3_O;
    public GameObject star4_X;
    public GameObject star4_O;
    public GameObject star5_X;
    public GameObject star5_O;
    public GameObject star6_X;
    public GameObject star6_O;
    public GameObject[] star7 = new GameObject[6];

    public AudioSource button;
    public AudioSource upgrade_sound_success;
    public AudioSource upgrade_sound_fail;

    public TextMeshProUGUI hp;
    public TextMeshProUGUI atk;
    public TextMeshProUGUI characteristic;
    public TextMeshProUGUI level_before;
    public TextMeshProUGUI level_after;
    public TextMeshProUGUI level_money;

    // Start is called before the first frame update
    void Start()
    {
        upgrade.gameObject.SetActive(false);
        ex.gameObject.SetActive(false);

        star1_O.gameObject.SetActive(false);
        star2_O.gameObject.SetActive(false);
        star3_O.gameObject.SetActive(false);
        star4_O.gameObject.SetActive(false);
        star5_O.gameObject.SetActive(false);
        star6_O.gameObject.SetActive(false);
        star1_X.gameObject.SetActive(true);
        star2_X.gameObject.SetActive(true);
        star3_X.gameObject.SetActive(true);
        star4_X.gameObject.SetActive(true);
        star5_X.gameObject.SetActive(true);
        star6_X.gameObject.SetActive(true);
        
        for(int i=0;i<6;i++)
        {
            star7[i].gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (Data.Instance.gameData.effect == false)
        {
            button.gameObject.GetComponent<AudioSource>().enabled = false;
            upgrade_sound_success.gameObject.GetComponent<AudioSource>().enabled = false;
            upgrade_sound_fail.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else if (Data.Instance.gameData.effect == true)
        {
            button.gameObject.GetComponent<AudioSource>().enabled = true;
            upgrade_sound_success.gameObject.GetComponent<AudioSource>().enabled = true;
            upgrade_sound_fail.gameObject.GetComponent<AudioSource>().enabled = true;
        }
        if(Data.Instance.gameData.wolf_lv==0)
        {
            level_before.text = "공격 3";
            level_after.text = "6";
            level_money.text = "1000";
            hp.text = "50";
            atk.text = "3";
        }
        else if (Data.Instance.gameData.wolf_lv == 1)
        {
            level_before.text = "체력 50";
            level_after.text = "60";
            level_money.text = "3000";
            hp.text = "50";
            atk.text = "6";
        }
        else if (Data.Instance.gameData.wolf_lv == 2)
        {
            level_before.text = "스킬 5";
            level_after.text = "7";
            level_money.text = "6000";
            hp.text = "60";
            atk.text = "6";
        }
        else if (Data.Instance.gameData.wolf_lv == 3)
        {
            level_before.text = "속도15";
            level_after.text = "25";
            level_money.text = "10000";
            hp.text = "60";
            atk.text = "6";
        }
        else if (Data.Instance.gameData.wolf_lv == 4)
        {
            level_before.text = "공격 6";
            level_after.text = "9";
            level_money.text = "20000";
            hp.text = "60";
            atk.text = "6";
        }
        else if (Data.Instance.gameData.wolf_lv == 5)
        {
            level_before.text = "체력 60";
            level_after.text = "80";
            level_money.text = "30000";
            hp.text = "60";
            atk.text = "9";
        }
        else if (Data.Instance.gameData.wolf_lv == 6)
        {
            level_before.text = "특성";
            level_after.text = "개방";
            level_money.text = "50000";
            hp.text = "80";
            atk.text = "9";
        }
        else if (Data.Instance.gameData.wolf_lv == 7)
        {
            hp.text = "80";
            atk.text = "9";
        }

        if(Data.Instance.gameData.wolf_lv>=7)
        {
            characteristic.text = "스킬 사용시 적을 강하게\n물어뜯어 체력을\n일정량 회복합니다";
        }
        else
        {
            characteristic.text = "특성 개방시 열람 가능";
        }

        if (Data.Instance.gameData.wolf_lv == 1)
        {
            star1_O.gameObject.SetActive(true);
            star1_X.gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.wolf_lv == 2)
        {
            star1_O.gameObject.SetActive(true);
            star1_X.gameObject.SetActive(false);

            star2_O.gameObject.SetActive(true);
            star2_X.gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.wolf_lv == 3)
        {
            star1_O.gameObject.SetActive(true);
            star1_X.gameObject.SetActive(false);

            star2_O.gameObject.SetActive(true);
            star2_X.gameObject.SetActive(false);

            star3_O.gameObject.SetActive(true);
            star3_X.gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.wolf_lv == 4)
        {
            star1_O.gameObject.SetActive(true);
            star1_X.gameObject.SetActive(false);

            star2_O.gameObject.SetActive(true);
            star2_X.gameObject.SetActive(false);

            star3_O.gameObject.SetActive(true);
            star3_X.gameObject.SetActive(false);

            star4_O.gameObject.SetActive(true);
            star4_X.gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.wolf_lv == 5)
        {
            star1_O.gameObject.SetActive(true);
            star1_X.gameObject.SetActive(false);

            star2_O.gameObject.SetActive(true);
            star2_X.gameObject.SetActive(false);

            star3_O.gameObject.SetActive(true);
            star3_X.gameObject.SetActive(false);

            star4_O.gameObject.SetActive(true);
            star4_X.gameObject.SetActive(false);

            star5_O.gameObject.SetActive(true);
            star5_X.gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.wolf_lv == 6)
        {
            star1_O.gameObject.SetActive(true);
            star1_X.gameObject.SetActive(false);

            star2_O.gameObject.SetActive(true);
            star2_X.gameObject.SetActive(false);

            star3_O.gameObject.SetActive(true);
            star3_X.gameObject.SetActive(false);

            star4_O.gameObject.SetActive(true);
            star4_X.gameObject.SetActive(false);

            star5_O.gameObject.SetActive(true);
            star5_X.gameObject.SetActive(false);

            star6_O.gameObject.SetActive(true);
            star6_X.gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.wolf_lv == 7)
        {
            star1_O.gameObject.SetActive(false);
            star1_X.gameObject.SetActive(false);

            star2_O.gameObject.SetActive(false);
            star2_X.gameObject.SetActive(false);

            star3_O.gameObject.SetActive(false);
            star3_X.gameObject.SetActive(false);

            star4_O.gameObject.SetActive(false);
            star4_X.gameObject.SetActive(false);

            star5_O.gameObject.SetActive(false);
            star5_X.gameObject.SetActive(false);

            star6_O.gameObject.SetActive(false);
            star6_X.gameObject.SetActive(false);

            for(int i=0; i<6;i++)
            {
                star7[i].gameObject.SetActive(true);
            }
        }

        if (Data.Instance.gameData.wolf_lv >= 7)
            upgrade_button.gameObject.SetActive(false);
        else
            upgrade_button.gameObject.SetActive(true);
    }
    public void Arrow()
    {
        button.Play();
        if (ex.gameObject.activeSelf == false)
        {
            upgrade.gameObject.SetActive(false);
            ex.gameObject.SetActive(true);
        }
        else if (ex.gameObject.activeSelf == true)
        {
            upgrade.gameObject.SetActive(false);
            ex.gameObject.SetActive(false);
        }
    }
    public void Upgrade()
    {
        button.Play();
        upgrade.gameObject.SetActive(true);
    }
    public void Upgrade_Go()
    {
        if(Data.Instance.gameData.wolf_lv==0&&Data.Instance.gameData.gold>=1000)
        {
            upgrade_sound_success.Play();
            Data.Instance.gameData.gold -= 1000;
            Data.Instance.gameData.wolf_lv++;
            Data.Instance.SaveGameData();
            upgrade.gameObject.SetActive(false);

            return;
        }
        else if (Data.Instance.gameData.wolf_lv == 0 && Data.Instance.gameData.gold < 1000)
        {
            gm.gold_less.gameObject.SetActive(true);
            upgrade_sound_fail.Play();
            return;
        }

        if (Data.Instance.gameData.wolf_lv == 1 && Data.Instance.gameData.gold >= 3000)
        {
            upgrade_sound_success.Play();
            Data.Instance.gameData.gold -= 3000;
            Data.Instance.gameData.wolf_lv++;
            Data.Instance.SaveGameData();
            upgrade.gameObject.SetActive(false);
            return;
        }
        else if (Data.Instance.gameData.wolf_lv == 1 && Data.Instance.gameData.gold < 3000)
        {
            gm.gold_less.gameObject.SetActive(true);
            upgrade_sound_fail.Play();
            return;
        }

        if (Data.Instance.gameData.wolf_lv == 2 && Data.Instance.gameData.gold >= 6000)
        {
            upgrade_sound_success.Play();
            Data.Instance.gameData.gold -= 6000;
            Data.Instance.gameData.wolf_lv++;
            Data.Instance.SaveGameData();
            upgrade.gameObject.SetActive(false);
            return;
        }
        else if (Data.Instance.gameData.wolf_lv == 2 && Data.Instance.gameData.gold < 6000)
        {
            gm.gold_less.gameObject.SetActive(true);
            upgrade_sound_fail.Play();
            return;
        }

        if (Data.Instance.gameData.wolf_lv == 3 && Data.Instance.gameData.gold >= 10000)
        {
            upgrade_sound_success.Play();
            Data.Instance.gameData.gold -= 10000;
            Data.Instance.gameData.wolf_lv++;
            Data.Instance.SaveGameData();
            upgrade.gameObject.SetActive(false);
            return;
        }
        else if (Data.Instance.gameData.wolf_lv == 3 && Data.Instance.gameData.gold < 10000)
        {
            gm.gold_less.gameObject.SetActive(true);
            upgrade_sound_fail.Play();
            return;
        }

        if (Data.Instance.gameData.wolf_lv == 4 && Data.Instance.gameData.gold >= 20000)
        {
            upgrade_sound_success.Play();
            Data.Instance.gameData.gold -= 20000;
            Data.Instance.gameData.wolf_lv++;
            Data.Instance.SaveGameData();
            upgrade.gameObject.SetActive(false);
            return;
        }
        else if (Data.Instance.gameData.wolf_lv == 4 && Data.Instance.gameData.gold < 20000)
        {
            gm.gold_less.gameObject.SetActive(true);
            upgrade_sound_fail.Play();
            return;
        }

        if (Data.Instance.gameData.wolf_lv == 5 && Data.Instance.gameData.gold >= 30000)
        {
            upgrade_sound_success.Play();
            Data.Instance.gameData.gold -= 30000;
            Data.Instance.gameData.wolf_lv++;
            Data.Instance.SaveGameData();
            upgrade.gameObject.SetActive(false);
            return;
        }
        else if (Data.Instance.gameData.wolf_lv == 5 && Data.Instance.gameData.gold < 30000)
        {
            gm.gold_less.gameObject.SetActive(true);
            upgrade_sound_fail.Play();
            return;
        }

        if (Data.Instance.gameData.wolf_lv == 6 && Data.Instance.gameData.gold >= 50000)
        {
            upgrade_sound_success.Play();
            Data.Instance.gameData.gold -= 50000;
            Data.Instance.gameData.wolf_lv++;
            Data.Instance.SaveGameData();
            upgrade.gameObject.SetActive(false);
            return;
        }
        else if (Data.Instance.gameData.wolf_lv == 6 && Data.Instance.gameData.gold < 50000)
        {
            gm.gold_less.gameObject.SetActive(true);
            upgrade_sound_fail.Play();
            return;
        }
    }
    public void Upgrade_Cancel()
    {
        button.Play();
        upgrade.gameObject.SetActive(false);
    }
}
