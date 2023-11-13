using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Character : MonoBehaviour
{
    public AudioSource attack1;
    public AudioSource attack3;
    public AudioSource skill;

    public Gm_InGame gm;
    //능력치 관련
    public int wolf_hp;
    public int wolf_dm;
    public int wolf_last_dm;
    public int wolf_skill_dm;
    public float wolf_speed;

    public TextMeshProUGUI now_hp;
    public TextMeshProUGUI total_hp;

    public GameObject damage_la;
    public TextMeshProUGUI damage_label;
    //적위치(넉백의 위치를 알기 위함)


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
    public PolygonCollider2D ak1_1;
    public PolygonCollider2D ak1_2;
    public PolygonCollider2D ak1_3;
    public PolygonCollider2D ak2_1;
    public PolygonCollider2D ak2_2;
    public PolygonCollider2D ak2_3;
    public PolygonCollider2D ak3_1;
    public PolygonCollider2D ak3_2;
    public PolygonCollider2D ak3_3;

    //울프 히트 이펙트
    public GameObject wolf_atk_effect1;
    public GameObject wolf_atk_effect2;
    public GameObject wolf_atk_effect3;

    //스킬
    public Animator skillEffect;
    public Image skillbutton_black;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        damage_label.text = null;
        gameObject.transform.position = new Vector2(0, 0);
        wolf_hp = Data.Instance.gameData.wolf_hp;
        total_hp.text = "/ "+ Data.Instance.gameData.wolf_hp.ToString();
        now_hp.text = wolf_hp.ToString();

        st1.enabled = true;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;

        skillEffect.gameObject.SetActive(false);
        skillbutton_black.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Data.Instance.gameData.sound == false)
        {
            attack1.gameObject.GetComponent<AudioSource>().enabled = false;
            attack3.gameObject.GetComponent<AudioSource>().enabled = false;
            skill.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else if (Data.Instance.gameData.sound == true)
        {
            attack1.gameObject.GetComponent<AudioSource>().enabled = true;
            attack3.gameObject.GetComponent<AudioSource>().enabled = false;
            skill.gameObject.GetComponent<AudioSource>().enabled = true;
        }

        now_hp.text = wolf_hp.ToString();
        if (wolf_hp <= 0)
        {
            Time.timeScale = 0;
            if(Data.Instance.gameData.reborn==true)
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


        damage_la.gameObject.transform.localPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 120f);

    }
    void LateUpdate()
    {
        if (gameObject.activeSelf == true)
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

        skillEffect.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    //스킬 버튼
    public void SkillButton()
    {
        if(gameObject.activeSelf==true)
        {
            wolf_speed = 0;
            skillbutton_black.gameObject.SetActive(true);
            skillEffect.gameObject.SetActive(true);
            if(Data.Instance.gameData.wolf_characteristic==true)
            {
                if(wolf_hp+1==Data.Instance.gameData.wolf_hp)
                {
                    wolf_hp += 1;
                }
                else if (wolf_hp + 2 == Data.Instance.gameData.wolf_hp)
                {
                    wolf_hp += 2;
                }
                else if (wolf_hp + 3 <= Data.Instance.gameData.wolf_hp)
                {
                    wolf_hp += 3;
                }
            }
            skill.Play();
            Invoke("OffSkill", 1f);
        }
    }
    public void OffSkill()
    {
        if (gameObject.activeSelf == true)
        {
            wolf_speed = Data.Instance.gameData.wolf_speed;
            skillEffect.gameObject.SetActive(false);
            skillEffect.gameObject.SetActive(false);
        }

    }
    //공격버튼
    public void AttackButton()
    {
        if (cnt_combo==0)
        {
            anim.Play("Wolf_Attack1");
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
        if(cnt_combo==2)
        {
            anim.Play("Wolf_Attack2");
            attack1.Play();
        }
        if (cnt_combo == 3)
        {
            anim.Play("Wolf_Attack3");
            attack3.Play();
        }
    }
    public void ComboReset()
    {
        is_combo = false;
        cnt_combo = 0;
    }
    
    //웨어 울프 애니메이션에 따른 콜라이더
    public void Wolf_St1()
    {
        st1.enabled = true;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
    }
    public void Wolf_St2()
    {
        st1.enabled = false;
        st2.enabled = true;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
    }
    public void Wolf_Wk1()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = true;
        wk2.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
    }
    public void Wolf_Wk2()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = true;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
    }
    public void Wolf_Ak1_1()
    {
        if (gameObject.transform.localScale.x > 0)
        {
            wolf_atk_effect1.transform.localScale = new Vector3(6f, 6f, 1f);
            wolf_atk_effect1.gameObject.transform.position = gameObject.transform.position + new Vector3(-3f, 0f);
        }
        else if(gameObject.transform.localScale.x<0)
        {
            wolf_atk_effect1.transform.localScale = new Vector3(-6f, 6f, 1f);
            wolf_atk_effect1.gameObject.transform.position = gameObject.transform.position + new Vector3(3f, 0f);
        }
        is_combo = true;
        Instantiate(wolf_atk_effect1);
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1_1.enabled = true;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
    }
    public void Wolf_Ak1_2()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = true;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
    }
    public void Wolf_Ak1_3()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = true;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        is_combo = false;
    }
    public void Wolf_Ak2_1()
    {
        if (gameObject.transform.localScale.x > 0)
        {
            wolf_atk_effect2.transform.localScale = new Vector3(6f, 6f, 1f);
            wolf_atk_effect2.gameObject.transform.position = gameObject.transform.position + new Vector3(-3f, 0f);
        }
        else if (gameObject.transform.localScale.x < 0)
        {
            wolf_atk_effect2.transform.localScale = new Vector3(-6f, 6f, 1f);
            wolf_atk_effect2.gameObject.transform.position = gameObject.transform.position + new Vector3(3f, 0f);
        }
        is_combo = true;
        Instantiate(wolf_atk_effect2);
        
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = true;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
    }
    public void Wolf_Ak2_2()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = true;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
    }
    public void Wolf_Ak2_3()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = true;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        is_combo = false;
    }
    public void Wolf_Ak3_1()
    {
        if (gameObject.transform.localScale.x > 0)
        {
            wolf_atk_effect3.transform.localScale = new Vector3(5f, 5f, 1f);
            wolf_atk_effect3.gameObject.transform.position = gameObject.transform.position + new Vector3(-3, 0f);
        }
        else if (gameObject.transform.localScale.x < 0)
        {
            wolf_atk_effect3.transform.localScale = new Vector3(-5f, 5f, 1f);
            wolf_atk_effect3.gameObject.transform.position = gameObject.transform.position + new Vector3(3f, 0f);
        }
        Instantiate(wolf_atk_effect3);
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = true;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
    }
    public void Wolf_Ak3_2()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = true;
        ak3_3.enabled = false;
    }
    public void Wolf_Ak3_3()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = true;
    }
    
}




