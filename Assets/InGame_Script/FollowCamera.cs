using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GooglePlayGames;
public class FollowCamera : MonoBehaviour
{
    public Gm_InGame gm;
    public Character wolf;
    public Skeleton skeleton;
    public Golem golem;
    public Slime_In slime;
    public Reaper reaper;

    public Transform valkyrie_attack_zone_left;
    public Transform valkyrie_attack_zone_right;
    public Transform warrior_attack_zone_left;
    public Transform warrior_attack_zone_right;
    public Transform assassin_attack_zone_left;
    public Transform assassin_attack_zone_right;
    public Transform mob_attack_zone_left;
    public Transform mob_attack_zone_right;

    public int score;
    public TextMeshProUGUI score_text;

    public Transform origin;
    //몹 최대 수
    public GameObject death_Cnt;
    public int death_cnt;
    public float death_Time = 7f;
    public float delay_Time = 0f;

    //화상,독? 어쨌든 레드존
    public GameObject redzone_effect;

    public GameObject card;
    public GameObject card2;

    //흡혈
    public GameObject vampire;
    public GameObject cardbouble_vampire;
    public float dis_vampire_time;

    public float name_time;
    public GameObject warrior;
    public GameObject mage;
    public GameObject valkyrie;
    public GameObject assassin;

    void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        cardbouble_vampire.gameObject.SetActive(false);
        vampire.gameObject.SetActive(false);

        card.gameObject.SetActive(false);
        card2.gameObject.SetActive(false);

        score = 0;
        score_text.text = "0";

        death_Cnt.gameObject.SetActive(false);
        redzone_effect.gameObject.SetActive(false);

        warrior.gameObject.SetActive(false);
        mage.gameObject.SetActive(false);
        valkyrie.gameObject.SetActive(false);
        assassin.gameObject.SetActive(false);
    }

    void Update()
    {
        if(name_time>=2f)
        {
            name_time = 0;
            warrior.gameObject.SetActive(false);
            mage.gameObject.SetActive(false);
            valkyrie.gameObject.SetActive(false);
            assassin.gameObject.SetActive(false);
        }
        if(warrior.gameObject.activeSelf==true)
        {
            name_time += Time.deltaTime;
        }
        if (mage.gameObject.activeSelf == true)
        {
            name_time += Time.deltaTime;
        }
        if (valkyrie.gameObject.activeSelf == true)
        {
            name_time += Time.deltaTime;
        }
        if (assassin.gameObject.activeSelf == true)
        {
            name_time += Time.deltaTime;
        }


        score_text.text = score.ToString();

        if(death_cnt>15)
        {
            death_Cnt.gameObject.SetActive(true);
            delay_Time += Time.deltaTime;
        }
        else
        {
            death_Cnt.gameObject.SetActive(false);
            delay_Time = 0f;
        }
        if(delay_Time>=death_Time)
        {
            if (wolf.gameObject.activeSelf == true)
            {
                wolf.wolf_hp -= 5;
            }
            if (skeleton.gameObject.activeSelf == true)
            {
                skeleton.skeleton_hp -= 5;
            }
            if (golem.gameObject.activeSelf == true)
            {
                golem.golem_hp -= 5;
            }
            if (slime.gameObject.activeSelf == true)
            {
                slime.slime_hp -= 5;
            }
            if (reaper.gameObject.activeSelf == true)
            {
                reaper.reaper_hp -= 5;
            }
            delay_Time = 0f;

            
        }

        if (wolf.gameObject.activeSelf==true)
        {
            valkyrie_attack_zone_left.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            valkyrie_attack_zone_right.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            
            mob_attack_zone_left.transform.localScale = new Vector3(1, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            mob_attack_zone_right.transform.localScale = new Vector3(1, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);

            transform.position = Vector2.Lerp(transform.position, wolf.transform.position, Time.deltaTime*2f);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);


            assassin_attack_zone_left.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            assassin_attack_zone_right.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            assassin_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-4f, 0, 10f);
            assassin_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(4f, 0, 10f);
            valkyrie_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-5f, 0, 10f);
            valkyrie_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(5f, 0, 10f);
            warrior_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-4f, 0, 10f);
            warrior_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(4f, 0, 10f);
            mob_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-3f, 0, 10f);
            mob_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(3f, 0, 10f);
        }    
        else if (skeleton.gameObject.activeSelf == true)
        {
            assassin_attack_zone_left.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            assassin_attack_zone_right.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            assassin_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-4f, 0, 10f);
            assassin_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(4f, 0, 10f);
            valkyrie_attack_zone_left.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            valkyrie_attack_zone_right.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            mob_attack_zone_left.transform.localScale = new Vector3(1, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            mob_attack_zone_right.transform.localScale = new Vector3(1, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);

            transform.position = Vector2.Lerp(transform.position, skeleton.transform.position, Time.deltaTime * 2f);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);

            valkyrie_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-5f, 0, 10f);
            valkyrie_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(5f, 0, 10f);
            warrior_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-4f, 0, 10f);
            warrior_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(4f, 0, 10f);
            mob_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-3f, 0, 10f);
            mob_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(3f, 0, 10f);
        }
        else if (slime.gameObject.activeSelf == true)
        {
            assassin_attack_zone_left.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            assassin_attack_zone_right.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            assassin_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-4f, 0, 10f);
            assassin_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(4f, 0, 10f);
            valkyrie_attack_zone_left.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            valkyrie_attack_zone_right.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            mob_attack_zone_left.transform.localScale = new Vector3(1, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            mob_attack_zone_right.transform.localScale = new Vector3(1, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);

            transform.position = Vector2.Lerp(transform.position, slime.transform.position, Time.deltaTime * 2f);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);

            valkyrie_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-5f, 0, 10f);
            valkyrie_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(5f, 0, 10f);
            warrior_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-4f, 0, 10f);
            warrior_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(4f, 0, 10f);
            mob_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-3f, 0, 10f);
            mob_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(3f, 0, 10f);
        }
        else if (golem.gameObject.activeSelf == true)
        {
            assassin_attack_zone_left.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            assassin_attack_zone_right.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            assassin_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-4f, 0, 10f);
            assassin_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(4f, 0, 10f);
            valkyrie_attack_zone_left.transform.localScale = new Vector3(2, 3, valkyrie_attack_zone_left.transform.localScale.z);
            valkyrie_attack_zone_right.transform.localScale = new Vector3(2, 3, valkyrie_attack_zone_left.transform.localScale.z);

            mob_attack_zone_left.transform.localScale = new Vector3(1, 3, valkyrie_attack_zone_left.transform.localScale.z);
            mob_attack_zone_right.transform.localScale = new Vector3(1, 3, valkyrie_attack_zone_left.transform.localScale.z);

            transform.position = Vector2.Lerp(transform.position, golem.transform.position, Time.deltaTime * 2f);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);

            valkyrie_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-5f, 0, 10f);
            valkyrie_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(5f, 0, 10f);
            warrior_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-4f, 0, 10f);
            warrior_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(4f, 0, 10f);
            mob_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-3f, 0, 10f);
            mob_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(3f, 0, 10f);
        }
        else if (reaper.gameObject.activeSelf == true)
        {
            //카메라 중심 유닛 맞추기
            transform.position = Vector2.Lerp(transform.position, reaper.transform.position, Time.deltaTime * 2f);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);

            //몹 공격 범위 크기
            mob_attack_zone_left.transform.localScale = new Vector3(1, 3, valkyrie_attack_zone_left.transform.localScale.z);
            mob_attack_zone_right.transform.localScale = new Vector3(1, 3, valkyrie_attack_zone_left.transform.localScale.z);
            //몹 공격 범위 위치
            mob_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-3f, 0, 10f);
            mob_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(3f, 0, 10f);
            
            //어쌔신 공격범위 크기
            assassin_attack_zone_left.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            assassin_attack_zone_right.transform.localScale = new Vector3(2, 1.5f, valkyrie_attack_zone_left.transform.localScale.z);
            //어쌔신 공격법위 위치
            assassin_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-4f, 0, 10f);
            assassin_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(4f, 0, 10f);

            //발키리 공격범위 크기
            valkyrie_attack_zone_left.transform.localScale = new Vector3(3, 3, valkyrie_attack_zone_left.transform.localScale.z);
            valkyrie_attack_zone_right.transform.localScale = new Vector3(3, 3, valkyrie_attack_zone_left.transform.localScale.z);
            //발키리 공격범위 위치
            valkyrie_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-5f, 0, 10f);
            valkyrie_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(5f, 0, 10f);
            warrior_attack_zone_left.gameObject.transform.position = transform.position + new Vector3(-4f, 0, 10f);
            warrior_attack_zone_right.gameObject.transform.position = transform.position + new Vector3(4f, 0, 10f);
        }
        origin.transform.position = gameObject.transform.position;
        if (gm.is_wolf == true)
        {
            redzone_effect.gameObject.transform.position = wolf.gameObject.transform.position + new Vector3(0f, 2f, 10f);
        }
        else if (gm.is_slime == true)
        {
            redzone_effect.gameObject.transform.position = slime.gameObject.transform.position + new Vector3(0f, 2f, 10f);
        }
        else if (gm.is_skeleton == true)
        {
            redzone_effect.gameObject.transform.position = skeleton.gameObject.transform.position + new Vector3(0f, 2f, 10f);
        }
        else if (gm.is_golem == true)
        {
            redzone_effect.gameObject.transform.position = golem.gameObject.transform.position + new Vector3(0f, 2f, 10f);
        }
        else if (gm.is_reaper == true)
        {
            redzone_effect.gameObject.transform.position = reaper.gameObject.transform.position + new Vector3(0f, 2f, 10f); ;
        }

        //흡혈
        if (Data.Instance.gameData.vampirelv > 0)
        {
            cardbouble_vampire.gameObject.SetActive(true);
            vampire.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.5f);
        }
        if(dis_vampire_time>=1f)
        {
            dis_vampire_time = 0;
            vampire.gameObject.SetActive(false);
        }
        if(vampire.gameObject.activeSelf==true)
        {
            dis_vampire_time += Time.deltaTime;
        }
    }
}   
