using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_select2 : MonoBehaviour
{
    public Gm_InGame my_card;
    //
    //가지고 있는 카드 5개의 자식오브젝트
    public GameObject[] card1 = new GameObject[13];
    public GameObject[] card2 = new GameObject[13];
    public GameObject[] card3 = new GameObject[13];
    public GameObject[] card4 = new GameObject[13];
    public GameObject[] card5 = new GameObject[13];

    //새로 뽑은 카드
    public GameObject[] new_card = new GameObject[12];

    //교체와 버리기 버튼
    public GameObject change_on;
    public GameObject change_off;
    public GameObject throw_on;
    public GameObject throw_off;

    public AudioSource button;
    private void Update()
    {
        if (Data.Instance.gameData.sound == false)
        {
            button.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else if (Data.Instance.gameData.sound == true)
        {
            button.gameObject.GetComponent<AudioSource>().enabled = true;
        }

        if (card1[12].gameObject.activeSelf == false&& card2[12].gameObject.activeSelf == false&& card3[12].gameObject.activeSelf == false
            && card4[12].gameObject.activeSelf == false&& card5[12].gameObject.activeSelf == false)
        {
            change_on.gameObject.SetActive(false);
            change_off.gameObject.SetActive(true);

            throw_on.gameObject.SetActive(true);
            throw_off.gameObject.SetActive(false);
        }
        else
        {
            change_on.gameObject.SetActive(true);
            change_off.gameObject.SetActive(false);

            throw_on.gameObject.SetActive(false);
            throw_off.gameObject.SetActive(true);
        }

        
        
    }
    public void CardStart()
    {
        for (int i = 0; i < 13; i++)
        {
            card1[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < 13; i++)
        {
            card2[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < 13; i++)
        {
            card3[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < 13; i++)
        {
            card4[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < 13; i++)
        {
            card5[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < 12; i++)
        {
            if (my_card.card1[i].gameObject.activeSelf == true)
            {
                card1[i].gameObject.SetActive(true);
            }
            if (my_card.card2[i].gameObject.activeSelf == true)
            {
                card2[i].gameObject.SetActive(true);
            }
            if (my_card.card3[i].gameObject.activeSelf == true)
            {
                card3[i].gameObject.SetActive(true);
            }
            if (my_card.card4[i].gameObject.activeSelf == true)
            {
                card4[i].gameObject.SetActive(true);
            }
            if (my_card.card5[i].gameObject.activeSelf == true)
            {
                card5[i].gameObject.SetActive(true);
            }
        }
    }

    public void ClickCard1()
    {
        button.Play();
        if(card1[12].gameObject.activeSelf==true)
        {
            card1[12].gameObject.SetActive(false);
            card2[12].gameObject.SetActive(false);
            card3[12].gameObject.SetActive(false);
            card4[12].gameObject.SetActive(false);
            card5[12].gameObject.SetActive(false);
        }
        else
        {
            card1[12].gameObject.SetActive(true);
            card2[12].gameObject.SetActive(false);
            card3[12].gameObject.SetActive(false);
            card4[12].gameObject.SetActive(false);
            card5[12].gameObject.SetActive(false);
        }
    }
    public void ClickCard2()
    {
        button.Play();
        if (card2[12].gameObject.activeSelf == true)
        {
            card1[12].gameObject.SetActive(false);
            card2[12].gameObject.SetActive(false);
            card3[12].gameObject.SetActive(false);
            card4[12].gameObject.SetActive(false);
            card5[12].gameObject.SetActive(false);
        }
        else
        {
            card1[12].gameObject.SetActive(false);
            card2[12].gameObject.SetActive(true);
            card3[12].gameObject.SetActive(false);
            card4[12].gameObject.SetActive(false);
            card5[12].gameObject.SetActive(false);
        }
    }
    public void ClickCard3()
    {
        button.Play();
        if (card3[12].gameObject.activeSelf == true)
        {
            card1[12].gameObject.SetActive(false);
            card2[12].gameObject.SetActive(false);
            card3[12].gameObject.SetActive(false);
            card4[12].gameObject.SetActive(false);
            card5[12].gameObject.SetActive(false);
        }
        else
        {
            card1[12].gameObject.SetActive(false);
            card2[12].gameObject.SetActive(false);
            card3[12].gameObject.SetActive(true);
            card4[12].gameObject.SetActive(false);
            card5[12].gameObject.SetActive(false);
        }
    }
    public void ClickCard4()
    {
        button.Play();
        if (card4[12].gameObject.activeSelf == true)
        {
            card1[12].gameObject.SetActive(false);
            card2[12].gameObject.SetActive(false);
            card3[12].gameObject.SetActive(false);
            card4[12].gameObject.SetActive(false);
            card5[12].gameObject.SetActive(false);
        }
        else
        {
            card1[12].gameObject.SetActive(false);
            card2[12].gameObject.SetActive(false);
            card3[12].gameObject.SetActive(false);
            card4[12].gameObject.SetActive(true);
            card5[12].gameObject.SetActive(false);
        }
    }
    public void ClickCard5()
    {
        button.Play();
        if (card5[12].gameObject.activeSelf == true)
        {
            card1[12].gameObject.SetActive(false);
            card2[12].gameObject.SetActive(false);
            card3[12].gameObject.SetActive(false);
            card4[12].gameObject.SetActive(false);
            card5[12].gameObject.SetActive(false);
        }
        else
        {
            card1[12].gameObject.SetActive(false);
            card2[12].gameObject.SetActive(false);
            card3[12].gameObject.SetActive(false);
            card4[12].gameObject.SetActive(false);
            card5[12].gameObject.SetActive(true);
        }
    }


    public void Change()
    {
        button.Play();
        if (card1[12].gameObject.activeSelf==true)
        {
            for(int i=0;i<12;i++)
            {
                if(my_card.card1[i].gameObject.activeSelf==true)
                {
                    if(i==0)
                        DisObtain_0();
                    else if (i == 1)
                        DisObtain_1();
                    else if(i==2)
                        DisObtain_2();
                    else if (i == 3)
                        DisObtain_3();
                    else if (i == 4)
                        DisObtain_4();
                    else if (i == 5)
                        DisObtain_5();
                    else if (i == 6)
                        DisObtain_6();
                    else if (i == 7)
                        DisObtain_7();
                    else if (i == 8)
                        DisObtain_8();
                    else if (i == 9)
                        DisObtain_9();
                    else if (i == 10)
                        DisObtain_10();
                    else if (i == 11)
                        DisObtain_11();
                }
                my_card.card1[i].gameObject.SetActive(false);
                if (new_card[i].gameObject.activeSelf==true)
                {
                    if (i == 0)
                        Obtain_0();
                    else if (i == 1)
                        Obtain_1();
                    else if (i == 2)
                        Obtain_2();
                    else if (i == 3)
                        Obtain_3();
                    else if (i == 4)
                        Obtain_4();
                    else if (i == 5)
                        Obtain_5();
                    else if (i == 6)
                        Obtain_6();
                    else if (i == 7)
                        Obtain_7();
                    else if (i == 8)
                        Obtain_8();
                    else if (i == 9)
                        Obtain_9();
                    else if (i == 10)
                        Obtain_10();
                    else if (i == 11)
                        Obtain_11();
                    my_card.card1[i].gameObject.SetActive(true);
                    Time.timeScale = 1;
                    gameObject.SetActive(false);
                }
            }
        }
        if (card2[12].gameObject.activeSelf == true)
        {
            for (int i = 0; i < 12; i++)
            {
                if (my_card.card2[i].gameObject.activeSelf == true)
                {
                    if (i == 0)
                        DisObtain_0();
                    else if (i == 1)
                        DisObtain_1();
                    else if (i == 2)
                        DisObtain_2();
                    else if (i == 3)
                        DisObtain_3();
                    else if (i == 4)
                        DisObtain_4();
                    else if (i == 5)
                        DisObtain_5();
                    else if (i == 6)
                        DisObtain_6();
                    else if (i == 7)
                        DisObtain_7();
                    else if (i == 8)
                        DisObtain_8();
                    else if (i == 9)
                        DisObtain_9();
                    else if (i == 10)
                        DisObtain_10();
                    else if (i == 11)
                        DisObtain_11();
                }
                my_card.card2[i].gameObject.SetActive(false);
                if (new_card[i].gameObject.activeSelf == true)
                {
                    if (i == 0)
                        Obtain_0();
                    else if (i == 1)
                        Obtain_1();
                    else if (i == 2)
                        Obtain_2();
                    else if (i == 3)
                        Obtain_3();
                    else if (i == 4)
                        Obtain_4();
                    else if (i == 5)
                        Obtain_5();
                    else if (i == 6)
                        Obtain_6();
                    else if (i == 7)
                        Obtain_7();
                    else if (i == 8)
                        Obtain_8();
                    else if (i == 9)
                        Obtain_9();
                    else if (i == 10)
                        Obtain_10();
                    else if (i == 11)
                        Obtain_11();
                    my_card.card2[i].gameObject.SetActive(true);
                    Time.timeScale = 1;
                    gameObject.SetActive(false);
                }
            }
        }
        if (card3[12].gameObject.activeSelf == true)
        {
            for (int i = 0; i < 12; i++)
            {
                if (my_card.card3[i].gameObject.activeSelf == true)
                {
                    if (i == 0)
                        DisObtain_0();
                    else if (i == 1)
                        DisObtain_1();
                    else if (i == 2)
                        DisObtain_2();
                    else if (i == 3)
                        DisObtain_3();
                    else if (i == 4)
                        DisObtain_4();
                    else if (i == 5)
                        DisObtain_5();
                    else if (i == 6)
                        DisObtain_6();
                    else if (i == 7)
                        DisObtain_7();
                    else if (i == 8)
                        DisObtain_8();
                    else if (i == 9)
                        DisObtain_9();
                    else if (i == 10)
                        DisObtain_10();
                    else if (i == 11)
                        DisObtain_11();
                }
                my_card.card3[i].gameObject.SetActive(false);
                if (new_card[i].gameObject.activeSelf == true)
                {
                    if (i == 0)
                        Obtain_0();
                    else if (i == 1)
                        Obtain_1();
                    else if (i == 2)
                        Obtain_2();
                    else if (i == 3)
                        Obtain_3();
                    else if (i == 4)
                        Obtain_4();
                    else if (i == 5)
                        Obtain_5();
                    else if (i == 6)
                        Obtain_6();
                    else if (i == 7)
                        Obtain_7();
                    else if (i == 8)
                        Obtain_8();
                    else if (i == 9)
                        Obtain_9();
                    else if (i == 10)
                        Obtain_10();
                    else if (i == 11)
                        Obtain_11();
                    my_card.card3[i].gameObject.SetActive(true);
                    Time.timeScale = 1;
                    gameObject.SetActive(false);
                }
            }
        }
        if (card4[12].gameObject.activeSelf == true)
        {
            for (int i = 0; i < 12; i++)
            {
                if (my_card.card4[i].gameObject.activeSelf == true)
                {
                    if (i == 0)
                        DisObtain_0();
                    else if (i == 1)
                        DisObtain_1();
                    else if (i == 2)
                        DisObtain_2();
                    else if (i == 3)
                        DisObtain_3();
                    else if (i == 4)
                        DisObtain_4();
                    else if (i == 5)
                        DisObtain_5();
                    else if (i == 6)
                        DisObtain_6();
                    else if (i == 7)
                        DisObtain_7();
                    else if (i == 8)
                        DisObtain_8();
                    else if (i == 9)
                        DisObtain_9();
                    else if (i == 10)
                        DisObtain_10();
                    else if (i == 11)
                        DisObtain_11();
                }
                my_card.card4[i].gameObject.SetActive(false);
                if (new_card[i].gameObject.activeSelf == true)
                {
                    if (i == 0)
                        Obtain_0();
                    else if (i == 1)
                        Obtain_1();
                    else if (i == 2)
                        Obtain_2();
                    else if (i == 3)
                        Obtain_3();
                    else if (i == 4)
                        Obtain_4();
                    else if (i == 5)
                        Obtain_5();
                    else if (i == 6)
                        Obtain_6();
                    else if (i == 7)
                        Obtain_7();
                    else if (i == 8)
                        Obtain_8();
                    else if (i == 9)
                        Obtain_9();
                    else if (i == 10)
                        Obtain_10();
                    else if (i == 11)
                        Obtain_11();
                    my_card.card4[i].gameObject.SetActive(true);
                    Time.timeScale = 1;
                    gameObject.SetActive(false);
                }
            }
        }
        if (card5[12].gameObject.activeSelf == true)
        {
            for (int i = 0; i < 12; i++)
            {
                if (my_card.card5[i].gameObject.activeSelf == true)
                {
                    if (i == 0)
                        DisObtain_0();
                    else if (i == 1)
                        DisObtain_1();
                    else if (i == 2)
                        DisObtain_2();
                    else if (i == 3)
                        DisObtain_3();
                    else if (i == 4)
                        DisObtain_4();
                    else if (i == 5)
                        DisObtain_5();
                    else if (i == 6)
                        DisObtain_6();
                    else if (i == 7)
                        DisObtain_7();
                    else if (i == 8)
                        DisObtain_8();
                    else if (i == 9)
                        DisObtain_9();
                    else if (i == 10)
                        DisObtain_10();
                    else if (i == 11)
                        DisObtain_11();
                }
                my_card.card5[i].gameObject.SetActive(false);
                if (new_card[i].gameObject.activeSelf == true)
                {
                    if (i == 0)
                        Obtain_0();
                    else if (i == 1)
                        Obtain_1();
                    else if (i == 2)
                        Obtain_2();
                    else if (i == 3)
                        Obtain_3();
                    else if (i == 4)
                        Obtain_4();
                    else if (i == 5)
                        Obtain_5();
                    else if (i == 6)
                        Obtain_6();
                    else if (i == 7)
                        Obtain_7();
                    else if (i == 8)
                        Obtain_8();
                    else if (i == 9)
                        Obtain_9();
                    else if (i == 10)
                        Obtain_10();
                    else if (i == 11)
                        Obtain_11();
                    my_card.card5[i].gameObject.SetActive(true);
                    Time.timeScale = 1;
                    gameObject.SetActive(false);
                }
            }
        }
    }
    public void Trash()
    {
        button.Play();
        for (int i = 0; i < 12; i++)
        {
            new_card[i].gameObject.SetActive(false);
        }
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void DisObtain_0()
    {
        if (my_card.is_wolf == true)
        {
            my_card.wolf.total_hp.text = "/ " + (Data.Instance.gameData.wolf_hp - 5).ToString();
            my_card.wolf.wolf_hp -= 5;

        }
        else if (my_card.is_skeleton == true)
        {
            my_card.skeleton.total_hp.text = "/ " + (Data.Instance.gameData.skeleton_hp - 5).ToString();
            my_card.skeleton.skeleton_hp -= 5;
        }
        else if (my_card.is_slime == true)
        {
            my_card.slime.total_hp.text = "/ " + (Data.Instance.gameData.slime_hp - 5).ToString();
            my_card.slime.slime_hp -= 5;
        }
        else if (my_card.is_golem == true)
        {
            my_card.golem.total_hp.text = "/ " + (Data.Instance.gameData.golem_hp - 5).ToString();
            my_card.golem.golem_hp -= 5;
        }
        else if (my_card.is_reaper == true)
        {
            my_card.reaper.total_hp.text = "/ " + (Data.Instance.gameData.reaper_hp - 5).ToString();
            my_card.reaper.reaper_hp -= 5;
        }
    }
    public void DisObtain_1()
    {
        if (my_card.is_wolf == true)
        {
            my_card.wolf.total_hp.text = "/ " + (Data.Instance.gameData.wolf_hp - 3).ToString();
            my_card.wolf.wolf_hp -= 3;

        }
        else if (my_card.is_skeleton == true)
        {
            my_card.skeleton.total_hp.text = "/ " + (Data.Instance.gameData.skeleton_hp - 3).ToString();
            my_card.skeleton.skeleton_hp -= 3;
        }
        else if (my_card.is_slime == true)
        {
            my_card.slime.total_hp.text = "/ " + (Data.Instance.gameData.slime_hp - 3).ToString();
            my_card.slime.slime_hp -= 3;
        }
        else if (my_card.is_golem == true)
        {
            my_card.golem.total_hp.text = "/ " + (Data.Instance.gameData.golem_hp - 3).ToString();
            my_card.golem.golem_hp -= 3;
        }
        else if (my_card.is_reaper == true)
        {
            my_card.reaper.total_hp.text = "/ " + (Data.Instance.gameData.reaper_hp - 3).ToString();
            my_card.reaper.reaper_hp -= 3;
        }
    }
    public void DisObtain_2()
    {
        if (my_card.is_wolf == true)
        {
            Data.Instance.gameData.wolf_damage -= 5;
            Data.Instance.gameData.wolf_last_damage -= 5;
            Data.Instance.gameData.wolf_skill_damage -= 5;
        }
        else if (my_card.is_skeleton == true)
        {
            Data.Instance.gameData.skeleton_damage -= 5;
            Data.Instance.gameData.skeleton_last_damage -= 5;
            Data.Instance.gameData.skeleton_skill_damage -= 5;
        }
        else if (my_card.is_slime == true)
        {
            Data.Instance.gameData.slime_damage -= 5;
            Data.Instance.gameData.sllime_skill_damage -= 5;
        }
        else if (my_card.is_golem == true)
        {
            Data.Instance.gameData.golem_damage -= 5;
            Data.Instance.gameData.goelm_last_damage -= 5;
        }
        else if (my_card.is_reaper == true)
        {
            Data.Instance.gameData.reaper_damage -= 5;
            Data.Instance.gameData.reaper_skill_damage -= 5;
        }
    }
    public void DisObtain_3()
    {
        if (my_card.is_wolf == true)
        {
            Data.Instance.gameData.wolf_damage -= 3;
            Data.Instance.gameData.wolf_last_damage -= 3;
            Data.Instance.gameData.wolf_skill_damage -= 3;
        }
        else if (my_card.is_skeleton == true)
        {
            Data.Instance.gameData.skeleton_damage -= 3;
            Data.Instance.gameData.skeleton_last_damage -= 3;
            Data.Instance.gameData.skeleton_skill_damage -= 3;
        }
        else if (my_card.is_slime == true)
        {
            Data.Instance.gameData.slime_damage -= 3;
            Data.Instance.gameData.sllime_skill_damage -= 3;
        }
        else if (my_card.is_golem == true)
        {
            Data.Instance.gameData.golem_damage -= 3;
            Data.Instance.gameData.goelm_last_damage -= 3;
        }
        else if (my_card.is_reaper == true)
        {
            Data.Instance.gameData.reaper_damage -= 3;
            Data.Instance.gameData.reaper_skill_damage -= 3;
        }
    }
    public void DisObtain_4()
    {
        if (my_card.is_wolf == true)
        {
            my_card.wolf.wolf_speed -= (my_card.wolf.wolf_speed * 0.1f);
        }
        else if (my_card.is_skeleton == true)
        {
            my_card.skeleton.skeleton_speed -= (my_card.skeleton.skeleton_speed * 0.1f);
        }
        else if (my_card.is_slime == true)
        {
            my_card.slime.slime_speed -= (my_card.slime.slime_speed * 0.1f);
        }
        else if (my_card.is_golem == true)
        {
            my_card.golem.golem_speed -= (my_card.golem.golem_speed * 0.1f);
        }
        else if (my_card.is_reaper == true)
        {
            my_card.reaper.reaper_speed -= (my_card.reaper.reaper_speed * 0.1f);
        }
    }
    public void DisObtain_5()
    {
        if (my_card.is_wolf == true)
        {
            my_card.wolf.wolf_speed -= (my_card.wolf.wolf_speed * 0.05f);
        }
        else if (my_card.is_skeleton == true)
        {
            my_card.skeleton.skeleton_speed -= (my_card.skeleton.skeleton_speed * 0.05f);
        }
        else if (my_card.is_slime == true)
        {
            my_card.slime.slime_speed -= (my_card.slime.slime_speed * 0.05f);
        }
        else if (my_card.is_golem == true)
        {
            my_card.golem.golem_speed -= (my_card.golem.golem_speed * 0.05f);
        }
        else if (my_card.is_reaper == true)
        {
            my_card.reaper.reaper_speed -= (my_card.reaper.reaper_speed * 0.05f);
        }
    }
    public void DisObtain_6()
    {
        Data.Instance.gameData.heallv--;
    }
    public void DisObtain_7()
    {
        Data.Instance.gameData.angerlv--;
    }
    public void DisObtain_8()
    {
        Data.Instance.gameData.vampirelv--;
    }
    public void DisObtain_9()
    {
        Data.Instance.gameData.arrowlv--;
    }
    public void DisObtain_10()
    {
        Data.Instance.gameData.lightninglv--;
    }
    public void DisObtain_11()
    {
        Data.Instance.gameData.shieldlv--;
    }

    public void Obtain_0()
    {
        if (my_card.is_wolf == true)
        {
            my_card.wolf.total_hp.text = "/ " + (Data.Instance.gameData.wolf_hp + 5).ToString();
            my_card.wolf.wolf_hp += 5;

        }
        else if (my_card.is_skeleton == true)
        {
            my_card.skeleton.total_hp.text = "/ " + (Data.Instance.gameData.skeleton_hp + 5).ToString();
            my_card.skeleton.skeleton_hp += 5;

        }
        else if (my_card.is_slime == true)
        {
            my_card.slime.total_hp.text = "/ " + (Data.Instance.gameData.slime_hp + 5).ToString();
            my_card.slime.slime_hp += 5;

        }
        else if (my_card.is_golem == true)
        {
            my_card.golem.total_hp.text = "/ " + (Data.Instance.gameData.golem_hp + 5).ToString();
            my_card.golem.golem_hp += 5;

        }
        else if (my_card.is_reaper == true)
        {
            my_card.reaper.total_hp.text = "/ " + (Data.Instance.gameData.reaper_hp + 5).ToString();
            my_card.reaper.reaper_hp += 5;

        }
    }
    public void Obtain_1()
    {
        if (my_card.is_wolf == true)
        {
            my_card.wolf.total_hp.text = "/ " + (Data.Instance.gameData.wolf_hp + 3).ToString();
            my_card.wolf.wolf_hp += 3;

        }
        else if (my_card.is_skeleton == true)
        {
            my_card.skeleton.total_hp.text = "/ " + (Data.Instance.gameData.skeleton_hp + 3).ToString();
            my_card.skeleton.skeleton_hp += 3;

        }
        else if (my_card.is_slime == true)
        {
            my_card.slime.total_hp.text = "/ " + (Data.Instance.gameData.slime_hp + 3).ToString();
            my_card.slime.slime_hp += 3;

        }
        else if (my_card.is_golem == true)
        {
            my_card.golem.total_hp.text = "/ " + (Data.Instance.gameData.golem_hp + 3).ToString();
            my_card.golem.golem_hp += 3;

        }
        else if (my_card.is_reaper == true)
        {
            my_card.reaper.total_hp.text = "/ " + (Data.Instance.gameData.reaper_hp + 3).ToString();
            my_card.reaper.reaper_hp += 3;

        }
    }
    public void Obtain_2()
    {
        if (my_card.is_wolf == true)
        {
            Data.Instance.gameData.wolf_damage += 5;
            Data.Instance.gameData.wolf_last_damage += 5;
            Data.Instance.gameData.wolf_skill_damage += 5;
        }
        else if (my_card.is_skeleton == true)
        {
            Data.Instance.gameData.skeleton_damage += 5;
            Data.Instance.gameData.skeleton_last_damage += 5;
            Data.Instance.gameData.skeleton_skill_damage += 5;
        }
        else if (my_card.is_slime == true)
        {
            Data.Instance.gameData.slime_damage += 5;
            Data.Instance.gameData.sllime_skill_damage += 5;
        }
        else if (my_card.is_golem == true)
        {
            Data.Instance.gameData.golem_damage += 5;
            Data.Instance.gameData.goelm_last_damage += 5;
        }
        else if (my_card.is_reaper == true)
        {
            Data.Instance.gameData.reaper_damage += 5;
            Data.Instance.gameData.reaper_skill_damage += 5;
        }
    }
    public void Obtain_3()
    {
        if (my_card.is_wolf == true)
        {
            Data.Instance.gameData.wolf_damage += 3;
            Data.Instance.gameData.wolf_last_damage += 3;
            Data.Instance.gameData.wolf_skill_damage += 3;
        }
        else if (my_card.is_skeleton == true)
        {
            Data.Instance.gameData.skeleton_damage += 3;
            Data.Instance.gameData.skeleton_last_damage += 3;
            Data.Instance.gameData.skeleton_skill_damage += 3;
        }
        else if (my_card.is_slime == true)
        {
            Data.Instance.gameData.slime_damage += 3;
            Data.Instance.gameData.sllime_skill_damage += 3;
        }
        else if (my_card.is_golem == true)
        {
            Data.Instance.gameData.golem_damage += 3;
            Data.Instance.gameData.goelm_last_damage += 3;
        }
        else if (my_card.is_reaper == true)
        {
            Data.Instance.gameData.reaper_damage += 3;
            Data.Instance.gameData.reaper_skill_damage += 3;
        }
    }
    public void Obtain_4()
    {
        if (my_card.is_wolf == true)
        {
            my_card.wolf.wolf_speed *= 1.1f;
        }
        else if (my_card.is_skeleton == true)
        {
            my_card.skeleton.skeleton_speed *= 1.1f;
        }
        else if (my_card.is_slime == true)
        {
            my_card.slime.slime_speed *= 1.1f;
        }
        else if (my_card.is_golem == true)
        {
            my_card.golem.golem_speed *= 1.1f;
        }
        else if (my_card.is_reaper == true)
        {
            my_card.reaper.reaper_speed *= 1.1f;
        }
    }
    public void Obtain_5()
    {
        if (my_card.is_wolf == true)
        {
            my_card.wolf.wolf_speed *= 1.05f;
        }
        else if (my_card.is_skeleton == true)
        {
            my_card.skeleton.skeleton_speed *= 1.05f;
        }
        else if (my_card.is_slime == true)
        {
            my_card.slime.slime_speed *= 1.05f;
        }
        else if (my_card.is_golem == true)
        {
            my_card.golem.golem_speed *= 1.05f;
        }
        else if (my_card.is_reaper == true)
        {
            my_card.reaper.reaper_speed *= 1.05f;
        }
    }
    public void Obtain_6()
    {
        Data.Instance.gameData.heallv++;
    }
    public void Obtain_7()
    {
        Data.Instance.gameData.angerlv++;
    }
    public void Obtain_8()
    {
        Data.Instance.gameData.vampirelv++;
    }
    public void Obtain_9()
    {
        Data.Instance.gameData.arrowlv++;
    }
    public void Obtain_10()
    {
        Data.Instance.gameData.lightninglv++;
    }
    public void Obtain_11()
    {
        Data.Instance.gameData.shieldlv++;
    }

}
