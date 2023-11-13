using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class Gm_InGame : MonoBehaviour
{
    public Button ad_button;

    public bool isTestMode;

    public FollowCamera followCamera;
    public Character wolf;
    public Skeleton skeleton;
    public Golem golem;
    public Slime_In slime;
    public Reaper reaper;

    public bool is_wolf;
    public bool is_skeleton;
    public bool is_golem;
    public bool is_slime;
    public bool is_reaper;

    public int playTime_Min;
    public float playTime_Second;
    public TextMeshProUGUI playTime_min;
    public TextMeshProUGUI playTime_second;

    public GameObject[] card1 = new GameObject[12];
    public GameObject[] card2 = new GameObject[12];
    public GameObject[] card3 = new GameObject[12];
    public GameObject[] card4 = new GameObject[12];
    public GameObject[] card5 = new GameObject[12];

    public GameObject cardbouble_heal;
    public GameObject cardbouble_anger;
    public GameObject cardbouble_arrow;
    public GameObject cardbouble_lightning;
    public GameObject cardbouble_shield;
    //낙뢰
    public GameObject lightning;
    public float lightning_time;
    public float dis_lightning_time;
    public float lightning_x;
    public float lightning_y;
    //분노
    public GameObject anger;
    public float anger_time;
    public float dis_anger_time;
    public int is_anger;
    //회복
    public GameObject heal;
    public float heal_time;
    public float dis_heal_time;
    //화살
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject arrow4;
    public GameObject arrow5;
    public GameObject arrow6;
    public GameObject arrow7;
    public GameObject arrow8;
    public float arrow_time;
    public float dis_arrow_time;
    //쉴드
    public GameObject shield;
    public GameObject shield_broke;
    public GameObject shield_effect;
    public float shield_time;
    public int shield_cnt;
    //부활
    public GameObject reborn;
    public GameObject game_end;

    //
    public AudioSource bgm;

    public GameObject wing;
    public float wing_time;
    private void Awake()
    {
        Application.targetFrameRate = 40;
    }
    void Start()
    {
        LoadRewardAd();
        wing.gameObject.SetActive(false);
        if(Data.Instance.gameData.sound==true)
        {
            bgm.Play();
        }
        else if (Data.Instance.gameData.sound == false)
        {
            bgm.Stop();
        }
        //카드 소지 갯수 초기화
        Data.Instance.gameData.card_count = 0;
        //카드 가지고 있는 여부 초기화
        Data.Instance.gameData.is_card1 = false;
        Data.Instance.gameData.is_card2 = false;
        Data.Instance.gameData.is_card3 = false;
        Data.Instance.gameData.is_card4 = false;
        Data.Instance.gameData.is_card5 = false;

        //특성카드 레벨 초기화
        Data.Instance.gameData.heallv = 0;
        Data.Instance.gameData.angerlv = 0;
        Data.Instance.gameData.vampirelv = 0;
        Data.Instance.gameData.arrowlv = 0;
        Data.Instance.gameData.lightninglv = 0;
        Data.Instance.gameData.shieldlv = 0;
        
        cardbouble_heal.gameObject.SetActive(false);
        cardbouble_anger.gameObject.SetActive(false);
        cardbouble_arrow.gameObject.SetActive(false);
        cardbouble_lightning.gameObject.SetActive(false);
        cardbouble_shield.gameObject.SetActive(false);

        lightning.gameObject.SetActive(false);
        lightning_time = 0;
        dis_lightning_time = 0;
        lightning_x = 0;
        lightning_y = 0;
        
        anger.gameObject.SetActive(false);
        anger_time = 0;
        dis_anger_time = 0;
        is_anger = 0;
        
        heal.gameObject.SetActive(false);
        heal_time = 0;
        dis_heal_time = 0;

        arrow1.gameObject.SetActive(false);
        arrow2.gameObject.SetActive(false);
        arrow3.gameObject.SetActive(false);
        arrow4.gameObject.SetActive(false);
        arrow5.gameObject.SetActive(false);
        arrow6.gameObject.SetActive(false);
        arrow7.gameObject.SetActive(false);
        arrow8.gameObject.SetActive(false);
        arrow_time = 0;
        dis_arrow_time = 0;

        shield.gameObject.SetActive(false);
        shield_broke.gameObject.SetActive(false);
        shield_effect.gameObject.SetActive(false);
        shield_time = 0;
        shield_cnt = 0;

        reborn.gameObject.SetActive(false);
        game_end.gameObject.SetActive(false);
        //미카엘
        Data.Instance.gameData.michael_hp = 8;
        Data.Instance.gameData.michael_damage = 1;
        Data.Instance.gameData.michael_speed = 6;
        //뭉크
            Data.Instance.gameData.monk_hp = 6;
            Data.Instance.gameData.monk_damage = 2;
            Data.Instance.gameData.monk_speed = 6;
        //도적
            Data.Instance.gameData.thief_hp = 5;
            Data.Instance.gameData.thief_damage = 2;
            Data.Instance.gameData.thief_speed = 8;
        //궁수
            Data.Instance.gameData.archer_hp = 4;
            Data.Instance.gameData.archer_damage = 3;
            Data.Instance.gameData.archer_speed = 3;
        //법사
            Data.Instance.gameData.magician_hp = 3;
            Data.Instance.gameData.magician_damage = 4;
            Data.Instance.gameData.magician_speed = 2;
        //해적
            Data.Instance.gameData.pirate_hp = 6;
            Data.Instance.gameData.pirate_damage = 2;
            Data.Instance.gameData.pirate_speed = 4;
        //보스 워리어
            Data.Instance.gameData.warrior_hp = 70;
            Data.Instance.gameData.warrior_damage = 5;
            Data.Instance.gameData.warrior_body_damage = 3;
            Data.Instance.gameData.warrior_skill_damage = 7;
            Data.Instance.gameData.warrior_speed = 4;
        //보스 발키리
            Data.Instance.gameData.valkyrie_hp = 50;
            Data.Instance.gameData.valkyrie_damage = 7;
            Data.Instance.gameData.valkyrie_body_damage = 3;
            Data.Instance.gameData.valkyrie_skill_damage = 10;
            Data.Instance.gameData.valkyrie_speed = 6;
        //보스 어썌신
            Data.Instance.gameData.assassin_hp = 40;
            Data.Instance.gameData.assassin_damage = 8;
            Data.Instance.gameData.assassin_body_damage = 3;
            Data.Instance.gameData.assassin_skill_damage = 10;
            Data.Instance.gameData.assassin_speed = 10;
        //보스 메이지
            Data.Instance.gameData.mage_hp = 50;
            Data.Instance.gameData.mage_damage = 15;
            Data.Instance.gameData.mage_body_damage = 5;
            Data.Instance.gameData.mage_speed = 4;

        //울프
        wolf.wolf_hp = Data.Instance.gameData.wolf_hp;
        wolf.wolf_dm = Data.Instance.gameData.wolf_damage;
        wolf.wolf_last_dm = Data.Instance.gameData.wolf_last_damage;
        wolf.wolf_skill_dm = Data.Instance.gameData.wolf_skill_damage;
        wolf.wolf_speed = Data.Instance.gameData.wolf_speed;

        //스켈레톤
        skeleton.skeleton_hp = Data.Instance.gameData.skeleton_hp;
        skeleton.skeleton_dm = Data.Instance.gameData.skeleton_damage;
        skeleton.skeleton_last_dm = Data.Instance.gameData.skeleton_last_damage;
        skeleton.skeleton_skill_dm = Data.Instance.gameData.skeleton_skill_damage;
        skeleton.skeleton_speed = Data.Instance.gameData.skeleton_speed;

        //슬라임
        slime.slime_hp = Data.Instance.gameData.slime_hp;
        slime.slime_dm = Data.Instance.gameData.slime_damage;
        slime.slime_skill_dm = Data.Instance.gameData.sllime_skill_damage;
        slime.slime_speed = Data.Instance.gameData.slime_speed;

        //골렘
        golem.golem_hp = Data.Instance.gameData.golem_hp;
        golem.golem_dm = Data.Instance.gameData.golem_damage;
        golem.golem_last_dm = Data.Instance.gameData.goelm_last_damage;
        golem.golem_speed = Data.Instance.gameData.golem_speed;

        //리퍼
        reaper.reaper_hp = Data.Instance.gameData.reaper_hp;
        reaper.reaper_dm = Data.Instance.gameData.reaper_damage;
        reaper.reaper_skill_dm = Data.Instance.gameData.reaper_skill_damage;
        reaper.reaper_speed = Data.Instance.gameData.reaper_speed;

        //부활가능
        Data.Instance.gameData.reborn = false;

        playTime_Min = 0;
        playTime_Second = 0;

        is_wolf = false;
        is_slime = false;
        is_skeleton = false;
        is_golem = false;
        is_reaper = false;
        
        if (Data.Instance.gameData.character_cnt==1)
        {
            is_wolf = true;
        }
        else if (Data.Instance.gameData.character_cnt == 2)
        {
            is_slime = true;
        }
        else if (Data.Instance.gameData.character_cnt == 3)
        {
            is_skeleton = true;
        }
        else if (Data.Instance.gameData.character_cnt == 4)
        {
            is_golem = true;
        }
        else if (Data.Instance.gameData.character_cnt == 5)
        {
            is_reaper = true;
        }
        if (is_wolf == true)
        {
            wolf.gameObject.SetActive(true);
            wolf.now_hp.gameObject.SetActive(true);
            wolf.total_hp.gameObject.SetActive(true);
            wolf.damage_la.gameObject.SetActive(true);

            skeleton.gameObject.SetActive(false);
            skeleton.now_hp.gameObject.SetActive(false);
            skeleton.total_hp.gameObject.SetActive(false);
            skeleton.damage_la.gameObject.SetActive(false);

            golem.gameObject.SetActive(false);
            golem.now_hp.gameObject.SetActive(false);
            golem.total_hp.gameObject.SetActive(false);
            golem.damage_la.gameObject.SetActive(false);

            slime.gameObject.SetActive(false);
            slime.now_hp.gameObject.SetActive(false);
            slime.total_hp.gameObject.SetActive(false);
            slime.damage_la.gameObject.SetActive(false);

            reaper.gameObject.SetActive(false);
            reaper.now_hp.gameObject.SetActive(false);
            reaper.total_hp.gameObject.SetActive(false);
            reaper.skill.gameObject.SetActive(false);
            reaper.skillEffect.gameObject.SetActive(false);
            reaper.damage_la.gameObject.SetActive(false);
        }
            
        if (is_skeleton == true)
        {
            wolf.gameObject.SetActive(false);
            wolf.now_hp.gameObject.SetActive(false);
            wolf.total_hp.gameObject.SetActive(false);
            wolf.damage_la.gameObject.SetActive(false);

            skeleton.gameObject.SetActive(true);
            skeleton.now_hp.gameObject.SetActive(true);
            skeleton.total_hp.gameObject.SetActive(true);
            skeleton.damage_la.gameObject.SetActive(true);

            golem.gameObject.SetActive(false);
            golem.now_hp.gameObject.SetActive(false);
            golem.total_hp.gameObject.SetActive(false);
            golem.damage_la.gameObject.SetActive(false);

            slime.gameObject.SetActive(false);
            slime.now_hp.gameObject.SetActive(false);
            slime.total_hp.gameObject.SetActive(false);
            slime.damage_la.gameObject.SetActive(false);

            reaper.gameObject.SetActive(false);
            reaper.now_hp.gameObject.SetActive(false);
            reaper.total_hp.gameObject.SetActive(false);
            reaper.skill.gameObject.SetActive(false);
            reaper.skillEffect.gameObject.SetActive(false);
            reaper.damage_la.gameObject.SetActive(false);
        }

        if (is_golem == true)
        {
            wolf.gameObject.SetActive(false);
            wolf.now_hp.gameObject.SetActive(false);
            wolf.total_hp.gameObject.SetActive(false);
            wolf.damage_la.gameObject.SetActive(false);

            skeleton.gameObject.SetActive(false);
            skeleton.now_hp.gameObject.SetActive(false);
            skeleton.total_hp.gameObject.SetActive(false);
            skeleton.damage_la.gameObject.SetActive(false);

            golem.gameObject.SetActive(true);
            golem.now_hp.gameObject.SetActive(true);
            golem.total_hp.gameObject.SetActive(true);
            golem.damage_la.gameObject.SetActive(true);

            slime.gameObject.SetActive(false);
            slime.now_hp.gameObject.SetActive(false);
            slime.total_hp.gameObject.SetActive(false);
            slime.damage_la.gameObject.SetActive(false);

            reaper.gameObject.SetActive(false);
            reaper.now_hp.gameObject.SetActive(false);
            reaper.total_hp.gameObject.SetActive(false);
            reaper.skill.gameObject.SetActive(false);
            reaper.skillEffect.gameObject.SetActive(false);
            reaper.damage_la.gameObject.SetActive(false);
        }

        if (is_slime == true)
        {
            wolf.gameObject.SetActive(false);
            wolf.now_hp.gameObject.SetActive(false);
            wolf.total_hp.gameObject.SetActive(false);
            wolf.damage_la.gameObject.SetActive(false);

            skeleton.gameObject.SetActive(false);
            skeleton.now_hp.gameObject.SetActive(false);
            skeleton.total_hp.gameObject.SetActive(false);
            skeleton.damage_la.gameObject.SetActive(false);

            golem.gameObject.SetActive(false);
            golem.now_hp.gameObject.SetActive(false);
            golem.total_hp.gameObject.SetActive(false);
            golem.damage_la.gameObject.SetActive(false);

            slime.gameObject.SetActive(true);
            slime.now_hp.gameObject.SetActive(true);
            slime.total_hp.gameObject.SetActive(true);
            slime.damage_la.gameObject.SetActive(true);

            reaper.gameObject.SetActive(false);
            reaper.now_hp.gameObject.SetActive(false);
            reaper.total_hp.gameObject.SetActive(false);
            reaper.skill.gameObject.SetActive(false);
            reaper.skillEffect.gameObject.SetActive(false);
            reaper.damage_la.gameObject.SetActive(false);
        }
        if(is_reaper==true)
        {
            wolf.gameObject.SetActive(false);
            wolf.now_hp.gameObject.SetActive(false);
            wolf.total_hp.gameObject.SetActive(false);
            wolf.damage_la.gameObject.SetActive(false);

            skeleton.gameObject.SetActive(false);
            skeleton.now_hp.gameObject.SetActive(false);
            skeleton.total_hp.gameObject.SetActive(false);
            skeleton.damage_la.gameObject.SetActive(false);

            golem.gameObject.SetActive(false);
            golem.now_hp.gameObject.SetActive(false);
            golem.total_hp.gameObject.SetActive(false);
            golem.damage_la.gameObject.SetActive(false);

            slime.gameObject.SetActive(false);
            slime.now_hp.gameObject.SetActive(false);
            slime.total_hp.gameObject.SetActive(false);
            slime.damage_la.gameObject.SetActive(false);

            reaper.gameObject.SetActive(true);
            reaper.now_hp.gameObject.SetActive(true);
            reaper.total_hp.gameObject.SetActive(true);
            reaper.skill.gameObject.SetActive(true);
            reaper.skillEffect.gameObject.SetActive(true);
            reaper.damage_la.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ad_button.interactable = rewardAd.IsLoaded();
        if (wing_time>=2f)
        {
            wing.gameObject.SetActive(false);
            wing_time = 0;
        }
        if(wing.gameObject.activeSelf==true)
        {
            wing_time += Time.deltaTime;
        }
        //게임중에도 광고보상 쿨타임이 돌게
        if (Data.Instance.gameData.time_Min < 0)
        {
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
            Data.Instance.gameData.time_Sec -= Time.deltaTime;
        }

        playTime_min.text = playTime_Min.ToString();
        playTime_second.text = string.Format("{0:N0}", playTime_Second);
        if (playTime_Second>=60)
        {
            playTime_Min++;
            playTime_Second = 0;
        }
        playTime_Second += Time.deltaTime;

        //체력 회복
        if(Data.Instance.gameData.heallv>0)
        {
            if(is_wolf==true)
            {
                heal.gameObject.transform.position = new Vector3(wolf.gameObject.transform.position.x, wolf.gameObject.transform.position.y + 2.5f);
            }
            else if (is_slime == true)
            {
                heal.gameObject.transform.position = new Vector3(slime.gameObject.transform.position.x, slime.gameObject.transform.position.y + 2.5f);
            }
            else if (is_skeleton == true)
            {
                heal.gameObject.transform.position = new Vector3(skeleton.gameObject.transform.position.x, skeleton.gameObject.transform.position.y + 2.5f);
            }
            else if (is_golem == true)
            {
                heal.gameObject.transform.position = new Vector3(golem.gameObject.transform.position.x, golem.gameObject.transform.position.y + 2.5f);
            }
            else if (is_reaper == true)
            {
                heal.gameObject.transform.position = new Vector3(reaper.gameObject.transform.position.x, reaper.gameObject.transform.position.y + 2.5f);
            }
            cardbouble_heal.gameObject.SetActive(true);
            heal_time += Time.deltaTime;
        }
        if(heal.gameObject.activeSelf==true)
        {
            if (dis_heal_time > 1f)
            {
                heal.gameObject.SetActive(false);
                dis_heal_time = 0;
            }
            dis_heal_time += Time.deltaTime;
        }  
        if (heal_time >= 20f)
        {
            heal.gameObject.SetActive(true);
            if (Data.Instance.gameData.heallv == 1)
            {
                if(is_wolf==true)
                {
                    if (wolf.wolf_hp < Data.Instance.gameData.wolf_hp)
                        wolf.wolf_hp += 1;
                }
                else if (is_slime == true)
                {
                    if(slime.slime_hp<Data.Instance.gameData.slime_hp)
                        slime.slime_hp += 1;
                }
                else if (is_skeleton == true)
                {
                    if (skeleton.skeleton_hp < Data.Instance.gameData.skeleton_hp)
                        skeleton.skeleton_hp += 1;
                }
                else if (is_golem == true)
                {
                    if (golem.golem_hp < Data.Instance.gameData.golem_hp)
                        golem.golem_hp += 1;
                }
                else if (is_reaper == true)
                {
                    if (reaper.reaper_hp < Data.Instance.gameData.reaper_hp)
                        reaper.reaper_hp += 1;
                }
            }
            else if (Data.Instance.gameData.heallv == 2)
            {
                if (is_wolf == true)
                {
                    if (wolf.wolf_hp +1 == Data.Instance.gameData.wolf_hp)
                        wolf.wolf_hp += 1;
                    else if (wolf.wolf_hp +2 <= Data.Instance.gameData.wolf_hp)
                        wolf.wolf_hp += 2;
                }
                else if (is_slime == true)
                {
                    if (slime.slime_hp +1== Data.Instance.gameData.slime_hp)
                        slime.slime_hp += 1;
                    else if (slime.slime_hp +2<= Data.Instance.gameData.slime_hp)
                        slime.slime_hp += 2;
                }
                else if (is_skeleton == true)
                {
                    if (skeleton.skeleton_hp + 1 == Data.Instance.gameData.skeleton_hp)
                        skeleton.skeleton_hp += 1;
                    else if (skeleton.skeleton_hp + 2 <= Data.Instance.gameData.skeleton_hp)
                        skeleton.skeleton_hp += 2;
                }
                else if (is_golem == true)
                {
                    if (golem.golem_hp + 1 == Data.Instance.gameData.golem_hp)
                        golem.golem_hp += 1;
                    else if (golem.golem_hp + 2 <= Data.Instance.gameData.golem_hp)
                        golem.golem_hp += 2;
                }
                else if (is_reaper == true)
                {
                    if (reaper.reaper_hp + 1 == Data.Instance.gameData.reaper_hp)
                        reaper.reaper_hp += 1;
                    else if (reaper.reaper_hp + 2 <= Data.Instance.gameData.reaper_hp)
                        reaper.reaper_hp += 2;
                }
            }
            else if (Data.Instance.gameData.heallv == 3)
            {
                if (is_wolf == true)
                {
                    if (wolf.wolf_hp + 1 == Data.Instance.gameData.wolf_hp)
                        wolf.wolf_hp += 1;
                    else if (wolf.wolf_hp + 2 == Data.Instance.gameData.wolf_hp)
                        wolf.wolf_hp += 2;
                    else if (wolf.wolf_hp + 3 <= Data.Instance.gameData.wolf_hp)
                        wolf.wolf_hp += 3;
                }
                else if (is_slime == true)
                {
                    if (slime.slime_hp + 1 == Data.Instance.gameData.slime_hp)
                        slime.slime_hp += 1;
                    else if (slime.slime_hp + 2 == Data.Instance.gameData.slime_hp)
                        slime.slime_hp += 2;
                    else if (slime.slime_hp + 3 <= Data.Instance.gameData.slime_hp)
                        slime.slime_hp += 3;
                }
                else if (is_skeleton == true)
                {
                    if (skeleton.skeleton_hp + 1 == Data.Instance.gameData.skeleton_hp)
                        skeleton.skeleton_hp += 1;
                    else if (skeleton.skeleton_hp + 2 == Data.Instance.gameData.skeleton_hp)
                        skeleton.skeleton_hp += 2;
                    else if (skeleton.skeleton_hp + 3 <= Data.Instance.gameData.skeleton_hp)
                        skeleton.skeleton_hp += 3;
                }
                else if (is_golem == true)
                {
                    if (golem.golem_hp + 1 == Data.Instance.gameData.golem_hp)
                        golem.golem_hp += 1;
                    else if (golem.golem_hp + 2 == Data.Instance.gameData.golem_hp)
                        golem.golem_hp += 2;
                    else if (golem.golem_hp + 3 <= Data.Instance.gameData.golem_hp)
                        golem.golem_hp += 3;
                }
                else if (is_reaper == true)
                {
                    if (reaper.reaper_hp + 1 == Data.Instance.gameData.reaper_hp)
                        reaper.reaper_hp += 1;
                    else if (reaper.reaper_hp + 2 == Data.Instance.gameData.reaper_hp)
                        reaper.reaper_hp += 2;
                    else if (reaper.reaper_hp + 3 <= Data.Instance.gameData.reaper_hp)
                        reaper.reaper_hp += 3;
                }
            }
            else if (Data.Instance.gameData.heallv == 4)
            {
                if (is_wolf == true)
                {
                    if (wolf.wolf_hp + 1 == Data.Instance.gameData.wolf_hp)
                        wolf.wolf_hp += 1;
                    else if (wolf.wolf_hp + 2 == Data.Instance.gameData.wolf_hp)
                        wolf.wolf_hp += 2;
                    else if (wolf.wolf_hp + 3 == Data.Instance.gameData.wolf_hp)
                        wolf.wolf_hp += 3;
                    else if (wolf.wolf_hp + 4 <= Data.Instance.gameData.wolf_hp)
                        wolf.wolf_hp += 4;
                }
                else if (is_slime == true)
                {
                    if (slime.slime_hp + 1 == Data.Instance.gameData.slime_hp)
                        slime.slime_hp += 1;
                    else if (slime.slime_hp + 2 == Data.Instance.gameData.slime_hp)
                        slime.slime_hp += 2;
                    else if (slime.slime_hp + 3 == Data.Instance.gameData.slime_hp)
                        slime.slime_hp += 3;
                    else if (slime.slime_hp + 4 <= Data.Instance.gameData.slime_hp)
                        slime.slime_hp += 4;
                }
                else if (is_skeleton == true)
                {
                    if (skeleton.skeleton_hp + 1 == Data.Instance.gameData.skeleton_hp)
                        skeleton.skeleton_hp += 1;
                    else if (skeleton.skeleton_hp + 2 == Data.Instance.gameData.skeleton_hp)
                        skeleton.skeleton_hp += 2;
                    else if (skeleton.skeleton_hp + 3 == Data.Instance.gameData.skeleton_hp)
                        skeleton.skeleton_hp += 3;
                    else if (skeleton.skeleton_hp + 4 <= Data.Instance.gameData.skeleton_hp)
                        skeleton.skeleton_hp += 4;
                }
                else if (is_golem == true)
                {
                    if (golem.golem_hp + 1 == Data.Instance.gameData.golem_hp)
                        golem.golem_hp += 1;
                    else if (golem.golem_hp + 2 == Data.Instance.gameData.golem_hp)
                        golem.golem_hp += 2;
                    else if (golem.golem_hp + 3 == Data.Instance.gameData.golem_hp)
                        golem.golem_hp += 3;
                    else if (golem.golem_hp + 4 <= Data.Instance.gameData.golem_hp)
                        golem.golem_hp += 4;
                }
                else if (is_reaper == true)
                {
                    if (reaper.reaper_hp + 1 == Data.Instance.gameData.reaper_hp)
                        reaper.reaper_hp += 1;
                    else if (reaper.reaper_hp + 2 == Data.Instance.gameData.reaper_hp)
                        reaper.reaper_hp += 2;
                    else if (reaper.reaper_hp + 3 == Data.Instance.gameData.reaper_hp)
                        reaper.reaper_hp += 3;
                    else if (reaper.reaper_hp + 4 <= Data.Instance.gameData.reaper_hp)
                        reaper.reaper_hp += 4;
                }
            }
            else if (Data.Instance.gameData.heallv == 5)
            {
                if (is_wolf == true)
                {
                    if (wolf.wolf_hp + 1 == Data.Instance.gameData.wolf_hp)
                        wolf.wolf_hp += 1;
                    else if (wolf.wolf_hp + 2 == Data.Instance.gameData.wolf_hp)
                        wolf.wolf_hp += 2;
                    else if (wolf.wolf_hp + 3 == Data.Instance.gameData.wolf_hp)
                        wolf.wolf_hp += 3;
                    else if (wolf.wolf_hp + 4 == Data.Instance.gameData.wolf_hp)
                        wolf.wolf_hp += 4;
                    else if (wolf.wolf_hp + 5 <= Data.Instance.gameData.wolf_hp)
                        wolf.wolf_hp += 5;
                }
                else if (is_slime == true)
                {
                    if (slime.slime_hp + 1 == Data.Instance.gameData.slime_hp)
                        slime.slime_hp += 1;
                    else if (slime.slime_hp + 2 == Data.Instance.gameData.slime_hp)
                        slime.slime_hp += 2;
                    else if (slime.slime_hp + 3 == Data.Instance.gameData.slime_hp)
                        slime.slime_hp += 3;
                    else if (slime.slime_hp + 4 == Data.Instance.gameData.slime_hp)
                        slime.slime_hp += 4;
                    else if (slime.slime_hp + 5 <= Data.Instance.gameData.slime_hp)
                        slime.slime_hp += 5;
                }
                else if (is_skeleton == true)
                {
                    if (skeleton.skeleton_hp + 1 == Data.Instance.gameData.skeleton_hp)
                        skeleton.skeleton_hp += 1;
                    else if (skeleton.skeleton_hp + 2 == Data.Instance.gameData.skeleton_hp)
                        skeleton.skeleton_hp += 2;
                    else if (skeleton.skeleton_hp + 3 == Data.Instance.gameData.skeleton_hp)
                        skeleton.skeleton_hp += 3;
                    else if (skeleton.skeleton_hp + 4 == Data.Instance.gameData.skeleton_hp)
                        skeleton.skeleton_hp += 4;
                    else if (skeleton.skeleton_hp + 5 <= Data.Instance.gameData.skeleton_hp)
                        skeleton.skeleton_hp += 5;
                }
                else if (is_golem == true)
                {
                    if (golem.golem_hp + 1 == Data.Instance.gameData.golem_hp)
                        golem.golem_hp += 1;
                    else if (golem.golem_hp + 2 == Data.Instance.gameData.golem_hp)
                        golem.golem_hp += 2;
                    else if (golem.golem_hp + 3 == Data.Instance.gameData.golem_hp)
                        golem.golem_hp += 3;
                    else if (golem.golem_hp + 4 == Data.Instance.gameData.golem_hp)
                        golem.golem_hp += 4;
                    else if (golem.golem_hp + 5 <= Data.Instance.gameData.golem_hp)
                        golem.golem_hp += 5;
                }
                else if (is_reaper == true)
                {
                    if (reaper.reaper_hp + 1 == Data.Instance.gameData.reaper_hp)
                        reaper.reaper_hp += 1;
                    else if (reaper.reaper_hp + 2 == Data.Instance.gameData.reaper_hp)
                        reaper.reaper_hp += 2;
                    else if (reaper.reaper_hp + 3 == Data.Instance.gameData.reaper_hp)
                        reaper.reaper_hp += 3;
                    else if (reaper.reaper_hp + 4 == Data.Instance.gameData.reaper_hp)
                        reaper.reaper_hp += 4;
                    else if (reaper.reaper_hp + 5 <= Data.Instance.gameData.reaper_hp)
                        reaper.reaper_hp += 5;
                }
            }
            heal_time = 0;
        }

        //분노
        if(Data.Instance.gameData.angerlv>0)
        {
            if (is_wolf == true)
            {
                anger.gameObject.transform.position = new Vector3(wolf.gameObject.transform.position.x, wolf.gameObject.transform.position.y + 1f);
            }
            else if (is_slime == true)
            {
                anger.gameObject.transform.position = new Vector3(slime.gameObject.transform.position.x, slime.gameObject.transform.position.y + 1f);
            }
            else if (is_skeleton == true)
            {
                anger.gameObject.transform.position = new Vector3(skeleton.gameObject.transform.position.x, skeleton.gameObject.transform.position.y + 1f);
            }
            else if (is_golem == true)
            {
                anger.gameObject.transform.position = new Vector3(golem.gameObject.transform.position.x, golem.gameObject.transform.position.y + 1f);
            }
            else if (is_reaper == true)
            {
                anger.gameObject.transform.position = new Vector3(reaper.gameObject.transform.position.x, reaper.gameObject.transform.position.y + 1f);
            }
            cardbouble_anger.gameObject.SetActive(true);
            anger_time += Time.deltaTime;
        }
        if(anger.gameObject.activeSelf==true)
        {
            if (is_wolf == true&&is_anger==0)
            {
                Data.Instance.gameData.wolf_damage *= 2;
                Data.Instance.gameData.wolf_last_damage *= 2;
                Data.Instance.gameData.wolf_skill_damage *= 2;
                is_anger = 1;
            }
            else if (is_skeleton == true && is_anger == 0)
            {
                Data.Instance.gameData.skeleton_damage *= 2;
                Data.Instance.gameData.skeleton_last_damage *= 2;
                Data.Instance.gameData.skeleton_skill_damage *= 2;
                is_anger = 1;
            }
            else if (is_slime == true && is_anger == 0)
            {
                Data.Instance.gameData.slime_damage *= 2;
                Data.Instance.gameData.sllime_skill_damage *= 2;
                is_anger = 1;
            }
            else if (is_golem == true && is_anger == 0)
            {
                Data.Instance.gameData.golem_damage *= 2;
                Data.Instance.gameData.goelm_last_damage *= 2;
                is_anger = 1;
            }
            else if (is_reaper == true && is_anger == 0)
            {
                Data.Instance.gameData.reaper_damage *= 2;
                Data.Instance.gameData.reaper_skill_damage *= 2;
                is_anger = 1;
            }


            if (Data.Instance.gameData.angerlv==1)
            {
                if (dis_anger_time > 5f)
                {
                    if (is_wolf == true)
                    {
                        Data.Instance.gameData.wolf_damage /= 2;
                        Data.Instance.gameData.wolf_last_damage /= 2;
                        Data.Instance.gameData.wolf_skill_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_skeleton == true)
                    {
                        Data.Instance.gameData.skeleton_damage /= 2;
                        Data.Instance.gameData.skeleton_last_damage /= 2;
                        Data.Instance.gameData.skeleton_skill_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_slime == true)
                    {
                        Data.Instance.gameData.slime_damage /= 2;
                        Data.Instance.gameData.sllime_skill_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_golem == true)
                    {
                        Data.Instance.gameData.golem_damage /= 2;
                        Data.Instance.gameData.goelm_last_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_reaper == true)
                    {
                        Data.Instance.gameData.reaper_damage /= 2;
                        Data.Instance.gameData.reaper_skill_damage /= 2;
                        is_anger = 0;
                    }
                    dis_anger_time = 0;
                    anger.gameObject.SetActive(false);
                }
            }
            else if (Data.Instance.gameData.angerlv == 2)
            {
                if (dis_anger_time > 6f)
                {
                    if (is_wolf == true)
                    {
                        Data.Instance.gameData.wolf_damage /= 2;
                        Data.Instance.gameData.wolf_last_damage /= 2;
                        Data.Instance.gameData.wolf_skill_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_skeleton == true)
                    {
                        Data.Instance.gameData.skeleton_damage /= 2;
                        Data.Instance.gameData.skeleton_last_damage /= 2;
                        Data.Instance.gameData.skeleton_skill_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_slime == true)
                    {
                        Data.Instance.gameData.slime_damage /= 2;
                        Data.Instance.gameData.sllime_skill_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_golem == true)
                    {
                        Data.Instance.gameData.golem_damage /= 2;
                        Data.Instance.gameData.goelm_last_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_reaper == true)
                    {
                        Data.Instance.gameData.reaper_damage /= 2;
                        Data.Instance.gameData.reaper_skill_damage /= 2;
                        is_anger = 0;
                    }
                    dis_anger_time = 0;
                    anger.gameObject.SetActive(false);
                }
            }
            else if (Data.Instance.gameData.angerlv == 3)
            {
                if (dis_anger_time > 7f)
                {
                    if (is_wolf == true)
                    {
                        Data.Instance.gameData.wolf_damage /= 2;
                        Data.Instance.gameData.wolf_last_damage /= 2;
                        Data.Instance.gameData.wolf_skill_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_skeleton == true)
                    {
                        Data.Instance.gameData.skeleton_damage /= 2;
                        Data.Instance.gameData.skeleton_last_damage /= 2;
                        Data.Instance.gameData.skeleton_skill_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_slime == true)
                    {
                        Data.Instance.gameData.slime_damage /= 2;
                        Data.Instance.gameData.sllime_skill_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_golem == true)
                    {
                        Data.Instance.gameData.golem_damage /= 2;
                        Data.Instance.gameData.goelm_last_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_reaper == true)
                    {
                        Data.Instance.gameData.reaper_damage /= 2;
                        Data.Instance.gameData.reaper_skill_damage /= 2;
                        is_anger = 0;
                    }
                    dis_anger_time = 0;
                    anger.gameObject.SetActive(false);
                }
            }
            else if (Data.Instance.gameData.angerlv == 4)
            {
                if (dis_anger_time > 8f)
                {
                    if (is_wolf == true)
                    {
                        Data.Instance.gameData.wolf_damage /= 2;
                        Data.Instance.gameData.wolf_last_damage /= 2;
                        Data.Instance.gameData.wolf_skill_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_skeleton == true)
                    {
                        Data.Instance.gameData.skeleton_damage /= 2;
                        Data.Instance.gameData.skeleton_last_damage /= 2;
                        Data.Instance.gameData.skeleton_skill_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_slime == true)
                    {
                        Data.Instance.gameData.slime_damage /= 2;
                        Data.Instance.gameData.sllime_skill_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_golem == true)
                    {
                        Data.Instance.gameData.golem_damage /= 2;
                        Data.Instance.gameData.goelm_last_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_reaper == true)
                    {
                        Data.Instance.gameData.reaper_damage /= 2;
                        Data.Instance.gameData.reaper_skill_damage /= 2;
                        is_anger = 0;
                    }
                    dis_anger_time = 0;
                    anger.gameObject.SetActive(false);
                }
            }
            else if (Data.Instance.gameData.angerlv == 5)
            {
                if (dis_anger_time > 9f)
                {
                    if (is_wolf == true)
                    {
                        Data.Instance.gameData.wolf_damage /= 2;
                        Data.Instance.gameData.wolf_last_damage /= 2;
                        Data.Instance.gameData.wolf_skill_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_skeleton == true)
                    {
                        Data.Instance.gameData.skeleton_damage /= 2;
                        Data.Instance.gameData.skeleton_last_damage /= 2;
                        Data.Instance.gameData.skeleton_skill_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_slime == true)
                    {
                        Data.Instance.gameData.slime_damage /= 2;
                        Data.Instance.gameData.sllime_skill_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_golem == true)
                    {
                        Data.Instance.gameData.golem_damage /= 2;
                        Data.Instance.gameData.goelm_last_damage /= 2;
                        is_anger = 0;
                    }
                    else if (is_reaper == true)
                    {
                        Data.Instance.gameData.reaper_damage /= 2;
                        Data.Instance.gameData.reaper_skill_damage /= 2;
                        is_anger = 0;
                    }
                    dis_anger_time = 0;
                    anger.gameObject.SetActive(false);
                }
            }
            dis_anger_time += Time.deltaTime;
        }
        if(anger_time>30f)
        {
            anger.gameObject.SetActive(true);
            anger_time = 0;
        }
        //번개
        if (Data.Instance.gameData.lightninglv > 0)
        {
            cardbouble_lightning.gameObject.SetActive(true);
            lightning_time += Time.deltaTime;
        }
        if (lightning.gameObject.activeSelf==true)
        {
            if(dis_lightning_time>0.5f)
            {
                dis_lightning_time = 0;
                lightning.gameObject.SetActive(false);
            }
            dis_lightning_time += Time.deltaTime;
        }
        if(Data.Instance.gameData.lightninglv==1)
        {
            if(lightning_time>10f)
            {
                lightning_x = Random.Range(followCamera.gameObject.transform.position.x - 15f, followCamera.gameObject.transform.position.x + 15f);
                lightning_y = Random.Range(followCamera.gameObject.transform.position.y - 10f, followCamera.gameObject.transform.position.y + 10f);
                lightning.gameObject.transform.position = new Vector3(lightning_x, lightning_y);
                lightning.gameObject.SetActive(true);
                lightning_time = 0;
            }
        }
        else if (Data.Instance.gameData.lightninglv == 2)
        {
            if (lightning_time > 9f)
            {
                lightning_x = Random.Range(followCamera.gameObject.transform.position.x - 15f, followCamera.gameObject.transform.position.x + 15f);
                lightning_y = Random.Range(followCamera.gameObject.transform.position.y - 10f, followCamera.gameObject.transform.position.y + 10f);
                lightning.gameObject.transform.position = new Vector3(lightning_x, lightning_y);
                lightning.gameObject.SetActive(true);
                lightning_time = 0;
            }
        }
        else if (Data.Instance.gameData.lightninglv == 3)
        {
            if (lightning_time > 8f)
            {
                lightning_x = Random.Range(followCamera.gameObject.transform.position.x - 15f, followCamera.gameObject.transform.position.x + 15f);
                lightning_y = Random.Range(followCamera.gameObject.transform.position.y - 10f, followCamera.gameObject.transform.position.y + 10f);
                lightning.gameObject.transform.position = new Vector3(lightning_x, lightning_y);
                lightning.gameObject.SetActive(true);
                lightning_time = 0;
            }
        }
        else if (Data.Instance.gameData.lightninglv == 4)
        {
            if (lightning_time > 7f)
            {
                lightning_x = Random.Range(followCamera.gameObject.transform.position.x - 15f, followCamera.gameObject.transform.position.x + 15f);
                lightning_y = Random.Range(followCamera.gameObject.transform.position.y - 10f, followCamera.gameObject.transform.position.y + 10f);
                lightning.gameObject.transform.position = new Vector3(lightning_x, lightning_y);
                lightning.gameObject.SetActive(true);
                lightning_time = 0;
            }
        }
        else if (Data.Instance.gameData.lightninglv == 5)
        {
            if (lightning_time > 6f)
            {
                lightning_x = Random.Range(followCamera.gameObject.transform.position.x - 15f, followCamera.gameObject.transform.position.x + 15f);
                lightning_y = Random.Range(followCamera.gameObject.transform.position.y - 10f, followCamera.gameObject.transform.position.y + 10f);
                lightning.gameObject.transform.position = new Vector3(lightning_x, lightning_y);
                lightning.gameObject.SetActive(true);
                lightning_time = 0;
            }
        }

        //화살
        if (Data.Instance.gameData.arrowlv > 0)
        {
            cardbouble_arrow.gameObject.SetActive(true);

            arrow1.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            arrow2.gameObject.transform.eulerAngles = new Vector3(0, 0, 45);
            arrow3.gameObject.transform.eulerAngles = new Vector3(0, 0, 90);
            arrow4.gameObject.transform.eulerAngles = new Vector3(0, 0, 135);
            arrow5.gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
            arrow6.gameObject.transform.eulerAngles = new Vector3(0, 0, 225);
            arrow7.gameObject.transform.eulerAngles = new Vector3(0, 0, 270);
            arrow8.gameObject.transform.eulerAngles = new Vector3(0, 0, 315);
            arrow_time += Time.deltaTime;
        }
        if(arrow1.gameObject.activeSelf==true)
        {
            arrow1.transform.Translate(Vector3.up * Time.deltaTime * 30f);
            arrow2.transform.Translate(Vector3.up * Time.deltaTime * 30f);
            arrow3.transform.Translate(Vector3.up * Time.deltaTime * 30f);
            arrow4.transform.Translate(Vector3.up * Time.deltaTime * 30f);
            arrow5.transform.Translate(Vector3.up * Time.deltaTime * 30f);
            arrow6.transform.Translate(Vector3.up * Time.deltaTime * 30f);
            arrow7.transform.Translate(Vector3.up * Time.deltaTime * 30f);
            arrow8.transform.Translate(Vector3.up * Time.deltaTime * 30f);
            if (dis_arrow_time > 1f)
            {
                arrow1.gameObject.SetActive(false);
                arrow2.gameObject.SetActive(false);
                arrow3.gameObject.SetActive(false);
                arrow4.gameObject.SetActive(false);
                arrow5.gameObject.SetActive(false);
                arrow6.gameObject.SetActive(false);
                arrow7.gameObject.SetActive(false);
                arrow8.gameObject.SetActive(false);
                dis_arrow_time = 0;
            }
            dis_arrow_time += Time.deltaTime;
        }
        if (arrow_time >= 20f)
        {
            arrow1.gameObject.transform.position = new Vector3(followCamera.gameObject.transform.position.x, followCamera.gameObject.transform.position.y);
            arrow2.gameObject.transform.position = new Vector3(followCamera.gameObject.transform.position.x, followCamera.gameObject.transform.position.y);
            arrow3.gameObject.transform.position = new Vector3(followCamera.gameObject.transform.position.x, followCamera.gameObject.transform.position.y);
            arrow4.gameObject.transform.position = new Vector3(followCamera.gameObject.transform.position.x, followCamera.gameObject.transform.position.y);
            arrow5.gameObject.transform.position = new Vector3(followCamera.gameObject.transform.position.x, followCamera.gameObject.transform.position.y);
            arrow6.gameObject.transform.position = new Vector3(followCamera.gameObject.transform.position.x, followCamera.gameObject.transform.position.y);
            arrow7.gameObject.transform.position = new Vector3(followCamera.gameObject.transform.position.x, followCamera.gameObject.transform.position.y);
            arrow8.gameObject.transform.position = new Vector3(followCamera.gameObject.transform.position.x, followCamera.gameObject.transform.position.y);
            arrow1.gameObject.SetActive(true);
            arrow2.gameObject.SetActive(true);
            arrow3.gameObject.SetActive(true);
            arrow4.gameObject.SetActive(true);
            arrow5.gameObject.SetActive(true);
            arrow6.gameObject.SetActive(true);
            arrow7.gameObject.SetActive(true);
            arrow8.gameObject.SetActive(true);
            
            arrow_time = 0;
        }

        //보호막
        if(Data.Instance.gameData.shieldlv>0)
        {
            cardbouble_shield.gameObject.SetActive(true);
            shield_time += Time.deltaTime;
            if (shield_cnt > 0)
            {
                if (is_wolf == true)
                {
                    shield_effect.gameObject.transform.position = new Vector3(wolf.gameObject.transform.position.x, wolf.gameObject.transform.position.y);
                }
                else if (is_slime == true)
                {
                    shield_effect.gameObject.transform.position = new Vector3(slime.gameObject.transform.position.x, slime.gameObject.transform.position.y);
                }
                else if (is_skeleton == true)
                {
                    shield_effect.gameObject.transform.position = new Vector3(skeleton.gameObject.transform.position.x, skeleton.gameObject.transform.position.y);
                }
                else if (is_golem == true)
                {
                    shield_effect.gameObject.transform.position = new Vector3(golem.gameObject.transform.position.x, golem.gameObject.transform.position.y);
                }
                else if (is_reaper == true)
                {
                    shield_effect.gameObject.transform.position = new Vector3(reaper.gameObject.transform.position.x, reaper.gameObject.transform.position.y);
                }
                shield.gameObject.SetActive(true);
                shield_effect.gameObject.SetActive(true);
                shield_broke.gameObject.SetActive(false);
            }
            else if (shield_cnt == 0)
            {
                shield.gameObject.SetActive(false);
                shield_effect.gameObject.SetActive(false);
                shield_broke.gameObject.SetActive(true);
            }
        }
        if(shield_time>=15f)
        {
            if(Data.Instance.gameData.shieldlv==1)
            {
                if(shield_cnt==0)
                {
                    shield_cnt++;
                    shield_time = 0;
                }
            }
            else if(Data.Instance.gameData.shieldlv == 2)
            {
                if (shield_cnt < 2)
                {
                    shield_cnt++;
                    shield_time = 0;
                }
            }
            else if (Data.Instance.gameData.shieldlv == 3)
            {
                if (shield_cnt < 3)
                {
                    shield_cnt++;
                    shield_time = 0;
                }
            }
            else if (Data.Instance.gameData.shieldlv == 4)
            {
                if (shield_cnt < 4)
                {
                    shield_cnt++;
                    shield_time = 0;
                }
            }
            else if (Data.Instance.gameData.shieldlv == 5)
            {
                if (shield_cnt < 5)
                {
                    shield_cnt++;
                    shield_time = 0;
                }
            }
        }

        
    }

    public void Gold_Reborn()
    {
        if(Data.Instance.gameData.gold<1000)
        {
            return;
        }
        else
        {
            Data.Instance.gameData.gold -= 1000;
            if(is_wolf==true)
            {
                wolf.wolf_hp = Data.Instance.gameData.wolf_hp;
                wing.gameObject.SetActive(true);
            }
            else if (is_skeleton == true)
            {
                skeleton.skeleton_hp = Data.Instance.gameData.skeleton_hp;
                wing.gameObject.SetActive(true);
            }
            else if (is_slime == true)
            {
                slime.slime_hp = Data.Instance.gameData.slime_hp;
                wing.gameObject.SetActive(true);
            }
            else if (is_golem == true)
            {
                golem.golem_hp = Data.Instance.gameData.golem_hp;
                wing.gameObject.SetActive(true);
            }
            else if (is_reaper == true)
            {
                reaper.reaper_hp = Data.Instance.gameData.reaper_hp;
                wing.gameObject.SetActive(true);
            }
            Data.Instance.gameData.reborn = true;
            Time.timeScale = 1;
            reborn.gameObject.SetActive(false);
        }
    }
    //광고 보기 버튼을 누르면 발동되는 함수
    const string rewardTestID = "ca-app-pub-3940256099942544/5224354917";
    const string rewardID = "ca-app-pub-7537224848353526/2299336728";
    RewardedAd rewardAd;

    void LoadRewardAd()
    {
        rewardAd = new RewardedAd(isTestMode ? rewardTestID : rewardID);
        rewardAd.LoadAd(GetAdRequest());
        rewardAd.OnUserEarnedReward += (sender, e) =>
        {
            if (is_wolf == true)
            {
                wolf.wolf_hp = Data.Instance.gameData.wolf_hp;
                wing.gameObject.SetActive(true);
            }
            else if (is_skeleton == true)
            {
                skeleton.skeleton_hp = Data.Instance.gameData.skeleton_hp;
                wing.gameObject.SetActive(true);
            }
            else if (is_slime == true)
            {
                slime.slime_hp = Data.Instance.gameData.slime_hp;
                wing.gameObject.SetActive(true);
            }
            else if (is_golem == true)
            {
                golem.golem_hp = Data.Instance.gameData.golem_hp;
                wing.gameObject.SetActive(true);
            }
            else if (is_reaper == true)
            {
                reaper.reaper_hp = Data.Instance.gameData.reaper_hp;
                wing.gameObject.SetActive(true);
            }
            Data.Instance.gameData.reborn = true;
            Time.timeScale = 1;
            reborn.gameObject.SetActive(false);
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
    public void GiveUp()
    {
        Time.timeScale = 1;
        Data.Instance.gameData.reborn = true;
        reborn.gameObject.SetActive(false);
        game_end.gameObject.SetActive(true);
    }
    
}
