using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skeleton : MonoBehaviour
{
    public AudioSource attack1;
    public AudioSource attack2;
    public AudioSource attack3;
    public AudioSource reborn;

    public Gm_InGame gm;
    //능력치 관련
    public int skeleton_hp;
    public int skeleton_dm;
    public int skeleton_last_dm;
    public int skeleton_skill_dm;
    public float skeleton_speed;
    public TextMeshProUGUI now_hp;
    public TextMeshProUGUI total_hp;

    public GameObject damage_la;
    public TextMeshProUGUI damage_label;
    //적위치(넉백의 위치를 알기 위함)

    public Image skillbutton_black; 
    public SpriteRenderer spriteRenderer;
    public Animator anim;
    public Rigidbody2D rigid;
    public bool is_combo;
    public int cnt_combo;

    //애니메이션 자르기
    public PolygonCollider2D st1;
    public PolygonCollider2D st2;
    public PolygonCollider2D wk1;
    public PolygonCollider2D wk2;
    public PolygonCollider2D wk3;
    public PolygonCollider2D wk4;
    public PolygonCollider2D ak1_1;
    public PolygonCollider2D ak1_2;
    public PolygonCollider2D ak1_3;
    public PolygonCollider2D ak2_1;
    public PolygonCollider2D ak2_2;
    public PolygonCollider2D ak2_3;
    public PolygonCollider2D ak3_1;
    public PolygonCollider2D ak3_2;
    public PolygonCollider2D ak3_3;
    public PolygonCollider2D ak3_4;
    public PolygonCollider2D ak3_5;
    public PolygonCollider2D ak3_6;
    public PolygonCollider2D ak3_7;
    public PolygonCollider2D skill1_1;
    //스킬 이펙트
    public GameObject skillEffect;
    //스켈레톤 히트 이펙트
    public GameObject skeleton_hit_effect1;
    public GameObject skeleton_hit_effect2;
    public GameObject skeleton_hit_effect3;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        damage_label.text = null;
        skillbutton_black.gameObject.SetActive(false);
        gameObject.transform.position = new Vector2(0, 0);
        skeleton_hp = Data.Instance.gameData.skeleton_hp;
        total_hp.text = "/ "+ Data.Instance.gameData.skeleton_hp.ToString();
        now_hp.text = skeleton_hp.ToString();

        st1.enabled = true;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;

        skillEffect.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Data.Instance.gameData.sound == false)
        {
            attack1.gameObject.GetComponent<AudioSource>().enabled = false;
            attack2.gameObject.GetComponent<AudioSource>().enabled = false;
            attack3.gameObject.GetComponent<AudioSource>().enabled = false;
            reborn.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else if (Data.Instance.gameData.sound == true)
        {
            attack1.gameObject.GetComponent<AudioSource>().enabled = true;
            attack2.gameObject.GetComponent<AudioSource>().enabled = true;
            attack3.gameObject.GetComponent<AudioSource>().enabled = true;
            reborn.gameObject.GetComponent<AudioSource>().enabled = true;
        }

        now_hp.text = skeleton_hp.ToString();
        if (skeleton_hp <= 0)
        {
            if(Data.Instance.gameData.skeleton_characteristic==true)
            {
                gm.wing.gameObject.SetActive(true);
                skeleton_hp = Data.Instance.gameData.skeleton_hp / 2;
                Data.Instance.gameData.skeleton_characteristic = false;
                reborn.Play();
            }
            else
            {
                Time.timeScale = 0;
                if (Data.Instance.gameData.reborn == true)
                {
                    gm.reborn.gameObject.SetActive(false);
                    gm.game_end.SetActive(true);
                }
                else if (Data.Instance.gameData.reborn == false)
                {
                    gm.reborn.gameObject.SetActive(true);
                    gm.game_end.SetActive(false);
                }
            }
        }
        

        skillEffect.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
    }
    void LateUpdate()
    {
        if(gameObject.activeSelf==true)
        {
            if (skillbutton_black.fillAmount <= 0)
            {
                skillbutton_black.gameObject.SetActive(false);
                skillbutton_black.fillAmount = 1;
            }
            if (skillbutton_black.gameObject.activeSelf == true)
            {
                skillbutton_black.fillAmount -= 0.2f * Time.deltaTime;
            }
        }
        damage_la.gameObject.transform.localPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 120f);
    }
    
    

    //스킬버튼
    public void SkillButton()
    {
        if (gameObject.activeSelf == true)
        {
            skeleton_speed = 0;
            skillbutton_black.gameObject.SetActive(true);
            anim.SetBool("Is_Skill", true);
            st1.enabled = false;
            st2.enabled = false;
            wk1.enabled = false;
            wk2.enabled = false;
            wk3.enabled = false;
            wk4.enabled = false;
            ak1_1.enabled = false;
            ak1_2.enabled = false;
            ak1_3.enabled = false;
            ak2_1.enabled = false;
            ak2_2.enabled = false;
            ak2_3.enabled = false;
            ak3_1.enabled = false;
            ak3_2.enabled = false;
            ak3_3.enabled = false;
            ak3_4.enabled = false;
            ak3_5.enabled = false;
            ak3_6.enabled = false;
            ak3_7.enabled = false;
            skill1_1.enabled = true;

            skillEffect.gameObject.SetActive(true);

            Invoke("OffSkill", 0.5f);
        }
            
    }
    public void OffSkill()
    {
        if (gameObject.activeSelf == true)
        {
            skeleton_speed = Data.Instance.gameData.skeleton_speed;
            anim.SetBool("Is_Skill", false);
            st1.enabled = true;
            st2.enabled = false;
            wk1.enabled = false;
            wk2.enabled = false;
            wk3.enabled = false;
            wk4.enabled = false;
            ak1_1.enabled = false;
            ak1_2.enabled = false;
            ak1_3.enabled = false;
            ak2_1.enabled = false;
            ak2_2.enabled = false;
            ak2_3.enabled = false;
            ak3_1.enabled = false;
            ak3_2.enabled = false;
            ak3_3.enabled = false;
            ak3_4.enabled = false;
            ak3_5.enabled = false;
            ak3_6.enabled = false;
            ak3_7.enabled = false;
            skill1_1.enabled = false;

            skillEffect.gameObject.SetActive(false);
        }
            
    }

    //공격버튼
    public void AttackButton()
    {
        if (cnt_combo == 0)
        {
            anim.Play("Skeleton_Attack1");
            attack1.Play();
            cnt_combo = 1;
            return;
        }
        else
        {
            if (is_combo)
            {
                cnt_combo += 1;
                is_combo = false;
            }
        }
    }

    public void Combo()
    {
        if (cnt_combo == 2)
        {
            anim.Play("Skeleton_Attack2");
            attack2.Play();
        }
        if (cnt_combo == 3)
        {
            anim.Play("Skeleton_Attack3");
            attack3.Play();
        }
    }
    public void ComboReset()
    {
        is_combo = false;
        cnt_combo = 0;
    }

    //웨어 울프 애니메이션에 따른 콜라이더
    public void Skeleton_St1()
    {
        st1.enabled = true;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;
    }
    public void Skeleton_St2()
    {
        st1.enabled = false;
        st2.enabled = true;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;
    }
    public void Skeleton_Wk1()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = true;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;
    }
    public void Skeleton_Wk2()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = true;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;
    }
    public void Skeleton_Wk3()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = true;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;
    }
    public void Skeleton_Wk4()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = true;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;
    }
    public void Skeleton_Ak1_1()
    {
        is_combo = true;
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = true;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;
    }
    public void Skeleton_Ak1_2()
    {
        if (gameObject.transform.localScale.x > 0)
        {
            skeleton_hit_effect1.transform.localScale = new Vector3(8f, 8f, 1f);
            skeleton_hit_effect1.gameObject.transform.position = gameObject.transform.position + new Vector3(3f, 0f);
        }
        else if (gameObject.transform.localScale.x < 0)
        {
            skeleton_hit_effect1.transform.localScale = new Vector3(-8f, 8f, 1f);
            skeleton_hit_effect1.gameObject.transform.position = gameObject.transform.position + new Vector3(-3f, 0f);
        }

        Instantiate(skeleton_hit_effect1);
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = true;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;
    }
    public void Skeleton_Ak1_3()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = true;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;

        is_combo = false;
    }
    public void Skeleton_Ak2_1()
    {
        is_combo = true;
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = true;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;
    }
    public void Skeleton_Ak2_2()
    {
        if (gameObject.transform.localScale.x > 0)
        {
            skeleton_hit_effect2.transform.localScale = new Vector3(10f, 10f, 1f);
            skeleton_hit_effect2.gameObject.transform.position = gameObject.transform.position + new Vector3(2f, 0f);
        }
        else if (gameObject.transform.localScale.x < 0)
        {
            skeleton_hit_effect2.transform.localScale = new Vector3(-10f, 10f, 1f);
            skeleton_hit_effect2.gameObject.transform.position = gameObject.transform.position + new Vector3(-2f, 0f);
        }
        Instantiate(skeleton_hit_effect2);
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = true;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;
    }
    public void Skeleton_Ak2_3()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = true;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;

        is_combo = false;
    }
    public void Skeleton_Ak3_1()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = true;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;
    }
    public void Skeleton_Ak3_2()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = true;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;
    }
    public void Skeleton_Ak3_3()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = true;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;
    }
    public void Skeleton_Ak3_4()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = true;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
    }
    public void Skeleton_Ak3_5()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = true;
        ak3_6.enabled = false;
        ak3_7.enabled = false;
        skill1_1.enabled = false;
    }
    public void Skeleton_Ak3_6()
    {
        if (gameObject.transform.localScale.x > 0)
        {
            skeleton_hit_effect3.transform.localScale = new Vector3(8f, 8f, 1f);
            skeleton_hit_effect3.gameObject.transform.position = gameObject.transform.position + new Vector3(3f, 0f);
        }
        else if (gameObject.transform.localScale.x < 0)
        {
            skeleton_hit_effect3.transform.localScale = new Vector3(-8f, 8f, 1f);
            skeleton_hit_effect3.gameObject.transform.position = gameObject.transform.position + new Vector3(-3f, 0f);
        }
        Instantiate(skeleton_hit_effect3);
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = true;
        ak3_7.enabled = false;
        skill1_1.enabled = false;
    }
    public void Skeleton_Ak3_7()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        ak3_4.enabled = false;
        ak3_5.enabled = false;
        ak3_6.enabled = false;
        ak3_7.enabled = true;
        skill1_1.enabled = false;

        is_combo = false;
    }
    
}
