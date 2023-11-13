using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_select : MonoBehaviour
{
    //내카드
    public Gm_InGame my_card;
    public Card_select2 card_select2;
    //카드 자식13개씩 오브젝트 
    public GameObject[] card1 = new GameObject[13];
    public GameObject[] card2 = new GameObject[13];
    public GameObject[] card3 = new GameObject[13];
    //카드 무작위로 나오게 하는 변수 3개
    public int ran1;
    public int ran2;
    public int ran3;
    //카드 선택 버튼
    public GameObject select_on;
    public GameObject select_off;

    public AudioSource button;

    void Update()
    {
        if (Data.Instance.gameData.sound == false)
        {
            button.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else if (Data.Instance.gameData.sound == true)
        {
            button.gameObject.GetComponent<AudioSource>().enabled = true;
        }
    }
    public void Card()
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
        select_on.gameObject.SetActive(false);
        select_off.gameObject.SetActive(true);

        ran1 = Random.Range(0, 12);
        ran2 = Random.Range(0, 12);
        ran3 = Random.Range(0, 12);

        card1[ran1].gameObject.SetActive(true);
        card2[ran2].gameObject.SetActive(true);
        card3[ran3].gameObject.SetActive(true);
    }

    public void ClickCard1()
    {
        button.Play();
        card1[12].gameObject.SetActive(true);
        card2[12].gameObject.SetActive(false);
        card3[12].gameObject.SetActive(false);

        select_on.gameObject.SetActive(true);
        select_off.gameObject.SetActive(false);
    }
    public void ClickCard2()
    {
        button.Play();
        card2[12].gameObject.SetActive(true);
        card1[12].gameObject.SetActive(false);
        card3[12].gameObject.SetActive(false);

        select_on.gameObject.SetActive(true);
        select_off.gameObject.SetActive(false);
    }
    public void ClickCard3()
    {
        button.Play();
        card3[12].gameObject.SetActive(true);
        card1[12].gameObject.SetActive(false);
        card2[12].gameObject.SetActive(false);

        select_on.gameObject.SetActive(true);
        select_off.gameObject.SetActive(false);
    }

    public void Select()
    {
        button.Play();
        if (Data.Instance.gameData.card_count>=5)
        {
            card_select2.gameObject.SetActive(true);
            card_select2.CardStart();
            for(int i=0;i<12;i++)
            {
                card_select2.new_card[i].gameObject.SetActive(false);
            }
            if (card3[12].gameObject.activeSelf==true)
            {
                card_select2.new_card[ran3].gameObject.SetActive(true);
            }
            else if (card2[12].gameObject.activeSelf == true)
            {
                card_select2.new_card[ran2].gameObject.SetActive(true);
            }
            else if (card1[12].gameObject.activeSelf == true)
            {
                card_select2.new_card[ran1].gameObject.SetActive(true);
            }
            gameObject.SetActive(false);
        }
        else
        {
            if (card3[12].gameObject.activeSelf == true)
            {
                if(Data.Instance.gameData.is_card1==false)
                {
                    my_card.card1[ran3].gameObject.SetActive(true);
                    Data.Instance.gameData.is_card1 = true;
                    Data.Instance.gameData.card_count++;
                    Time.timeScale = 1;
                    ObtainAbility_ran3();
                    gameObject.SetActive(false);
                    return;
                }
                else if (Data.Instance.gameData.is_card2 == false)
                {
                    my_card.card2[ran3].gameObject.SetActive(true);
                    Data.Instance.gameData.is_card2 = true;
                    Data.Instance.gameData.card_count++;
                    Time.timeScale = 1;
                    ObtainAbility_ran3();
                    gameObject.SetActive(false);
                    return;
                }
                else if (Data.Instance.gameData.is_card3 == false)
                {
                    my_card.card3[ran3].gameObject.SetActive(true);
                    Data.Instance.gameData.is_card3 = true;
                    Data.Instance.gameData.card_count++;
                    Time.timeScale = 1;
                    ObtainAbility_ran3();
                    gameObject.SetActive(false);
                    return;
                }
                else if (Data.Instance.gameData.is_card4 == false)
                {
                    my_card.card4[ran3].gameObject.SetActive(true);
                    Data.Instance.gameData.is_card4 = true;
                    Data.Instance.gameData.card_count++;
                    Time.timeScale = 1;
                    ObtainAbility_ran3();
                    gameObject.SetActive(false);
                    return;
                }
                else if (Data.Instance.gameData.is_card5 == false)
                {
                    my_card.card5[ran3].gameObject.SetActive(true);
                    Data.Instance.gameData.is_card5 = true;
                    Data.Instance.gameData.card_count++;
                    Time.timeScale = 1;
                    ObtainAbility_ran3();
                    gameObject.SetActive(false);
                    return;
                }
            }
            else if (card2[12].gameObject.activeSelf == true)
            {
                if (Data.Instance.gameData.is_card1 == false)
                {
                    my_card.card1[ran2].gameObject.SetActive(true);
                    Data.Instance.gameData.is_card1 = true;
                    Data.Instance.gameData.card_count++;
                    Time.timeScale = 1;
                    ObtainAbility_ran2();
                    gameObject.SetActive(false);
                    return;
                }
                else if (Data.Instance.gameData.is_card2 == false)
                {
                    my_card.card2[ran2].gameObject.SetActive(true);
                    Data.Instance.gameData.is_card2 = true;
                    Data.Instance.gameData.card_count++;
                    Time.timeScale = 1;
                    ObtainAbility_ran2();
                    gameObject.SetActive(false);
                    return;
                }
                else if (Data.Instance.gameData.is_card3 == false)
                {
                    my_card.card3[ran2].gameObject.SetActive(true);
                    Data.Instance.gameData.is_card3 = true;
                    Data.Instance.gameData.card_count++;
                    Time.timeScale = 1;
                    ObtainAbility_ran2();
                    gameObject.SetActive(false);
                    return;
                }
                else if (Data.Instance.gameData.is_card4 == false)
                {
                    my_card.card4[ran2].gameObject.SetActive(true);
                    Data.Instance.gameData.is_card4 = true;
                    Data.Instance.gameData.card_count++;
                    Time.timeScale = 1;
                    ObtainAbility_ran2();
                    gameObject.SetActive(false);
                    return;
                }
                else if (Data.Instance.gameData.is_card5 == false)
                {
                    my_card.card5[ran2].gameObject.SetActive(true);
                    Data.Instance.gameData.is_card5 = true;
                    Data.Instance.gameData.card_count++;
                    Time.timeScale = 1;
                    ObtainAbility_ran2();
                    gameObject.SetActive(false);
                    return;
                }
            }
            else if (card1[12].gameObject.activeSelf == true)
            {
                if (Data.Instance.gameData.is_card1 == false)
                {
                    my_card.card1[ran1].gameObject.SetActive(true);
                    Data.Instance.gameData.is_card1 = true;
                    Data.Instance.gameData.card_count++;
                    Time.timeScale = 1;
                    ObtainAbility_ran1();
                    gameObject.SetActive(false);
                    return;
                }
                else if (Data.Instance.gameData.is_card2 == false)
                {
                    my_card.card2[ran1].gameObject.SetActive(true);
                    Data.Instance.gameData.is_card2 = true;
                    Data.Instance.gameData.card_count++;
                    Time.timeScale = 1;
                    ObtainAbility_ran1();
                    gameObject.SetActive(false);
                    return;
                }
                else if (Data.Instance.gameData.is_card3 == false)
                {
                    my_card.card3[ran1].gameObject.SetActive(true);
                    Data.Instance.gameData.is_card3 = true;
                    Data.Instance.gameData.card_count++;
                    Time.timeScale = 1;
                    ObtainAbility_ran1();
                    gameObject.SetActive(false);
                    return;
                }
                else if (Data.Instance.gameData.is_card4 == false)
                {
                    my_card.card4[ran1].gameObject.SetActive(true);
                    Data.Instance.gameData.is_card4 = true;
                    Data.Instance.gameData.card_count++;
                    Time.timeScale = 1;
                    ObtainAbility_ran1();
                    gameObject.SetActive(false);
                    return;
                }
                else if (Data.Instance.gameData.is_card5 == false)
                {
                    my_card.card5[ran1].gameObject.SetActive(true);
                    Data.Instance.gameData.is_card5 = true;
                    Data.Instance.gameData.card_count++;
                    Time.timeScale = 1;
                    ObtainAbility_ran1();
                    gameObject.SetActive(false);
                    return;
                }
            }
        }
    }
    public void ObtainAbility_ran1()
    {
        if (ran1 == 0)
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
        else if (ran1 == 1)
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
        else if (ran1 == 2)
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
        else if (ran1 == 3)
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
        else if (ran1 == 4)
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
        else if (ran1 == 5)
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
        else if (ran1 == 6)
        {
            Data.Instance.gameData.heallv++;
        }
        else if (ran1 == 7)
        {
            Data.Instance.gameData.angerlv++;
        }
        else if (ran1 == 8)
        {
            Data.Instance.gameData.vampirelv++;
        }
        else if (ran1 == 9)
        {
            Data.Instance.gameData.arrowlv++;
        }
        else if (ran1 == 10)
        {
            Data.Instance.gameData.lightninglv++;
        }
        else if (ran1 == 11)
        {
            Data.Instance.gameData.shieldlv++;
        }
    }
    public void ObtainAbility_ran2()
    {
        if (ran2 == 0)
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
        else if (ran2 == 1)
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
        else if (ran2 == 2)
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
        else if (ran2 == 3)
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
        else if (ran2 == 4)
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
        else if (ran2 == 5)
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
        else if (ran2 == 6)
        {
            Data.Instance.gameData.heallv++;
        }
        else if (ran2 == 7)
        {
            Data.Instance.gameData.angerlv++;
        }
        else if (ran2 == 8)
        {
            Data.Instance.gameData.vampirelv++;
        }
        else if (ran2 == 9)
        {
            Data.Instance.gameData.arrowlv++;
        }
        else if (ran2 == 10)
        {
            Data.Instance.gameData.lightninglv++;
        }
        else if (ran2 == 11)
        {
            Data.Instance.gameData.shieldlv++;
        }
    }
    public void ObtainAbility_ran3()
    {
        if (ran3 == 0)
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
        else if (ran3 == 1)
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
        else if (ran3 == 2)
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
        else if (ran3 == 3)
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
        else if (ran3 == 4)
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
        else if (ran3 == 5)
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
        else if (ran3 == 6)
        {
            Data.Instance.gameData.heallv++;
        }
        else if (ran3 == 7)
        {
            Data.Instance.gameData.angerlv++;
        }
        else if (ran3 == 8)
        {
            Data.Instance.gameData.vampirelv++;
        }
        else if (ran3 == 9)
        {
            Data.Instance.gameData.arrowlv++;
        }
        else if (ran3 == 10)
        {
            Data.Instance.gameData.lightninglv++;
        }
        else if (ran3 == 11)
        {
            Data.Instance.gameData.shieldlv++;
        }
    }
}
