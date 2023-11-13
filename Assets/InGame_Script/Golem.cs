using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Golem : MonoBehaviour
{
    public AudioSource attack1;
    public AudioSource attack3;
    public AudioSource skill;

    public Gm_InGame gm;
    //능력치 관련
    public int golem_hp;
    public int golem_dm;
    public int golem_last_dm;
    public float golem_speed;

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
    public PolygonCollider2D wk5;
    public PolygonCollider2D wk6;
    public PolygonCollider2D wk7;
    public PolygonCollider2D ak1_1;
    public PolygonCollider2D ak1_2;
    public PolygonCollider2D ak1_3;
    public PolygonCollider2D ak2_1;
    public PolygonCollider2D ak2_2;
    public PolygonCollider2D ak2_3;
    public PolygonCollider2D ak3_1;
    public PolygonCollider2D ak3_2;
    public PolygonCollider2D ak3_3;
   
    public PolygonCollider2D skill1_1;
    //스킬 이펙트
    public GameObject skillEffect;
    //히트 이펙트
    public GameObject golem_hit_effect1;
    public GameObject golem_hit_effect2;
    public GameObject golem_hit_effect3;

    public GameObject golem_characteristic;
    public float golem_characteristic_time;
    public float dis_golem_characteristic;
    //스킬 중간에 공격 못하게 하기
    public bool is_attack;

    //스킬 최대 지속 시간
    public float skill_time;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        damage_label.text = null;
        golem_characteristic.gameObject.SetActive(false);
        golem_characteristic_time = 0;
        dis_golem_characteristic = 0;

        is_attack = true;
        skillbutton_black.gameObject.SetActive(false);
        gameObject.transform.position = new Vector2(0, 0);
        golem_hp = Data.Instance.gameData.golem_hp;
        total_hp.text = "/ "+ Data.Instance.gameData.golem_hp.ToString();
        now_hp.text = golem_hp.ToString();

        st1.enabled = true;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        
        skill1_1.enabled = false;


        skillEffect.gameObject.SetActive(false);
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

        if (golem_characteristic.gameObject.activeSelf==true)
            dis_golem_characteristic += Time.deltaTime;
        if (dis_golem_characteristic>0.5f)
        {
            skill.Play();
            golem_characteristic.gameObject.SetActive(false);
            dis_golem_characteristic = 0;
        }
        if(golem_characteristic_time>=10f)
        {
            
            golem_characteristic.gameObject.SetActive(true);
            golem_characteristic_time = 0;
        }
        if(skillEffect.gameObject.activeSelf==false)
        {
            anim.SetBool("Is_Skill", false);
            golem_speed = Data.Instance.gameData.golem_speed;
            rigid.constraints = RigidbodyConstraints2D.None| RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            anim.SetBool("Is_Skill", true);
            golem_speed = 0;
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        }
            
        now_hp.text = golem_hp.ToString();
        if (golem_hp <= 0)
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
        else if(golem_hp>0&&Data.Instance.gameData.golem_characteristic==true)
        {
            golem_characteristic_time += Time.deltaTime;
        }
        if(skill_time>=8f)
        {
            skillEffect.gameObject.SetActive(false);
            skill_time = 0;
        }
        if(skillEffect.gameObject.activeSelf==true)
        {
            skill_time += Time.deltaTime;
        }

        skillEffect.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
        golem_characteristic.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
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
            is_attack = false;
            st1.enabled = false;
            st2.enabled = false;
            wk1.enabled = false;
            wk2.enabled = false;
            wk3.enabled = false;
            wk4.enabled = false;
            wk5.enabled = false;
            wk6.enabled = false;
            wk7.enabled = false;
            ak1_1.enabled = false;
            ak1_2.enabled = false;
            ak1_3.enabled = false;
            ak2_1.enabled = false;
            ak2_2.enabled = false;
            ak2_3.enabled = false;
            ak3_1.enabled = false;
            ak3_2.enabled = false;
            ak3_3.enabled = false;

            skill1_1.enabled = true;

            skillEffect.gameObject.SetActive(true);
        }
    }
    public void OffSkill()
    {
        if (gameObject.activeSelf == true)
        {
            is_attack = true;
            skillbutton_black.gameObject.SetActive(true);
            st1.enabled = true;
            st2.enabled = false;
            wk1.enabled = false;
            wk2.enabled = false;
            wk3.enabled = false;
            wk4.enabled = false;
            wk5.enabled = false;
            wk6.enabled = false;
            wk7.enabled = false;
            ak1_1.enabled = false;
            ak1_2.enabled = false;
            ak1_3.enabled = false;
            ak2_1.enabled = false;
            ak2_2.enabled = false;
            ak2_3.enabled = false;
            ak3_1.enabled = false;
            ak3_2.enabled = false;
            ak3_3.enabled = false;

            skill1_1.enabled = false;

            skillEffect.gameObject.SetActive(false);
        }
    }

    //공격버튼
    public void AttackButton()
    {
        if(is_attack==true)
        {
            if (cnt_combo == 0)
            {
                anim.Play("Golem_Attack1");
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
    }
    public void Combo()
    {
        if (cnt_combo == 2)
        {
            anim.Play("Golem_Attack2");
            attack1.Play();
        }
        if (cnt_combo == 3)
        {
            anim.Play("Golem_Attack3");
            attack3.Play();
        }
    }
    public void ComboReset()
    {
        is_combo = false;
        cnt_combo = 0;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (skillEffect.activeSelf == false)
        {
            //마키엘한테 맞았을 때
            if (collision.gameObject.tag == "Michael")
                Damaged_Michael();
            //도적한테 맞았을 때
            if (collision.gameObject.tag == "Thief")
                Damaged_Thief();
            //수도승한테 맞았을 때
            if (collision.gameObject.tag == "Monk")
                Damaged_Monk();
            //궁수한테 맞았을 때
            if (collision.gameObject.tag == "Archer")
                Damaged_Archer();
            //마법사한테 맞았을 때
            if (collision.gameObject.tag == "Magician")
                Damaged_Magician();
            //해적한테 맞았을 때
            if (collision.gameObject.tag == "Pirate")
                Damaged_Pirate();
        }
        if (skillEffect.activeSelf == true)
        {
            //마키엘한테 맞았을 때
            if (collision.gameObject.tag == "Michael")
                Shield_Golem();
            //도적한테 맞았을 때
            if (collision.gameObject.tag == "Thief")
                Shield_Golem();
            //수도승한테 맞았을 때
            if (collision.gameObject.tag == "Monk")
                Shield_Golem();
            //궁수한테 맞았을 때
            if (collision.gameObject.tag == "Archer")
                Shield_Golem();
            //마법사한테 맞았을 때
            if (collision.gameObject.tag == "Magician")
                Shield_Golem();
            //해적한테 맞았을 때
            if (collision.gameObject.tag == "Pirate")
                Shield_Golem();
        }
        
    }
    private void Damaged_Michael()
    {
        golem_hp -= 1;
        gameObject.layer = 8;
        st1.gameObject.layer = 8;
        st2.gameObject.layer = 8;
        wk1.gameObject.layer = 8;
        wk2.gameObject.layer = 8;
        wk3.gameObject.layer = 8;
        wk4.gameObject.layer = 8;
        wk5.gameObject.layer = 8;
        wk6.gameObject.layer = 8;
        wk7.gameObject.layer = 8;
        ak1_1.gameObject.layer = 8;
        ak1_2.gameObject.layer = 8;
        ak1_3.gameObject.layer = 8;
        ak2_1.gameObject.layer = 8;
        ak2_2.gameObject.layer = 8;
        ak2_3.gameObject.layer = 8;
        ak3_1.gameObject.layer = 8;
        ak3_2.gameObject.layer = 8;
        ak3_3.gameObject.layer = 8;

        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        if (gameObject.transform.localScale.x > 0)
            rigid.AddForce(new Vector2(-1f, 0f) * 20f, ForceMode2D.Impulse);
        if (gameObject.transform.localScale.x < 0)
            rigid.AddForce(new Vector2(1f, 0f) * 20f, ForceMode2D.Impulse);


        Invoke("offBackGolem", 0.2f);
        Invoke("offDamageGolem", 1.2f);
    }
    private void Damaged_Thief()
    {
        golem_hp -= 1;
        gameObject.layer = 8;
        st1.gameObject.layer = 8;
        st2.gameObject.layer = 8;
        wk1.gameObject.layer = 8;
        wk2.gameObject.layer = 8;
        wk3.gameObject.layer = 8;
        wk4.gameObject.layer = 8;
        wk5.gameObject.layer = 8;
        wk6.gameObject.layer = 8;
        wk7.gameObject.layer = 8;
        ak1_1.gameObject.layer = 8;
        ak1_2.gameObject.layer = 8;
        ak1_3.gameObject.layer = 8;
        ak2_1.gameObject.layer = 8;
        ak2_2.gameObject.layer = 8;
        ak2_3.gameObject.layer = 8;
        ak3_1.gameObject.layer = 8;
        ak3_2.gameObject.layer = 8;
        ak3_3.gameObject.layer = 8;

        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        if (gameObject.transform.localScale.x > 0)
            rigid.AddForce(new Vector2(-1f, 0f) * 20f, ForceMode2D.Impulse);
        if (gameObject.transform.localScale.x < 0)
            rigid.AddForce(new Vector2(1f, 0f) * 20f, ForceMode2D.Impulse);


        Invoke("offBackGolem", 0.2f);
        Invoke("offDamageGolem", 1.2f);
    }
    private void Damaged_Monk()
    {
        golem_hp -= 1;
        gameObject.layer = 8;
        st1.gameObject.layer = 8;
        st2.gameObject.layer = 8;
        wk1.gameObject.layer = 8;
        wk2.gameObject.layer = 8;
        wk3.gameObject.layer = 8;
        wk4.gameObject.layer = 8;
        wk5.gameObject.layer = 8;
        wk6.gameObject.layer = 8;
        wk7.gameObject.layer = 8;
        ak1_1.gameObject.layer = 8;
        ak1_2.gameObject.layer = 8;
        ak1_3.gameObject.layer = 8;
        ak2_1.gameObject.layer = 8;
        ak2_2.gameObject.layer = 8;
        ak2_3.gameObject.layer = 8;
        ak3_1.gameObject.layer = 8;
        ak3_2.gameObject.layer = 8;
        ak3_3.gameObject.layer = 8;

        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        if (gameObject.transform.localScale.x > 0)
            rigid.AddForce(new Vector2(-1f, 0f) * 20f, ForceMode2D.Impulse);
        if (gameObject.transform.localScale.x < 0)
            rigid.AddForce(new Vector2(1f, 0f) * 20f, ForceMode2D.Impulse);


        Invoke("offBackGolem", 0.2f);
        Invoke("offDamageGolem", 1.2f);
    }
    private void Damaged_Archer()
    {
        golem_hp -= 1;
        gameObject.layer = 8;
        st1.gameObject.layer = 8;
        st2.gameObject.layer = 8;
        wk1.gameObject.layer = 8;
        wk2.gameObject.layer = 8;
        wk3.gameObject.layer = 8;
        wk4.gameObject.layer = 8;
        wk5.gameObject.layer = 8;
        wk6.gameObject.layer = 8;
        wk7.gameObject.layer = 8;
        ak1_1.gameObject.layer = 8;
        ak1_2.gameObject.layer = 8;
        ak1_3.gameObject.layer = 8;
        ak2_1.gameObject.layer = 8;
        ak2_2.gameObject.layer = 8;
        ak2_3.gameObject.layer = 8;
        ak3_1.gameObject.layer = 8;
        ak3_2.gameObject.layer = 8;
        ak3_3.gameObject.layer = 8;

        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        if (gameObject.transform.localScale.x > 0)
            rigid.AddForce(new Vector2(-1f, 0f) * 20f, ForceMode2D.Impulse);
        if (gameObject.transform.localScale.x < 0)
            rigid.AddForce(new Vector2(1f, 0f) * 20f, ForceMode2D.Impulse);


        Invoke("offBackGolem", 0.2f);
        Invoke("offDamageGolem", 1.2f);
    }
    private void Damaged_Magician()
    {
        golem_hp -= 1;
        gameObject.layer = 8;
        st1.gameObject.layer = 8;
        st2.gameObject.layer = 8;
        wk1.gameObject.layer = 8;
        wk2.gameObject.layer = 8;
        wk3.gameObject.layer = 8;
        wk4.gameObject.layer = 8;
        wk5.gameObject.layer = 8;
        wk6.gameObject.layer = 8;
        wk7.gameObject.layer = 8;
        ak1_1.gameObject.layer = 8;
        ak1_2.gameObject.layer = 8;
        ak1_3.gameObject.layer = 8;
        ak2_1.gameObject.layer = 8;
        ak2_2.gameObject.layer = 8;
        ak2_3.gameObject.layer = 8;
        ak3_1.gameObject.layer = 8;
        ak3_2.gameObject.layer = 8;
        ak3_3.gameObject.layer = 8;

        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        if (gameObject.transform.localScale.x > 0)
            rigid.AddForce(new Vector2(-1f, 0f) * 20f, ForceMode2D.Impulse);
        if (gameObject.transform.localScale.x < 0)
            rigid.AddForce(new Vector2(1f, 0f) * 20f, ForceMode2D.Impulse);


        Invoke("offBackGolem", 0.2f);
        Invoke("offDamageGolem", 1.2f);
    }
    private void Damaged_Pirate()
    {
        golem_hp -= 1;
        gameObject.layer = 8;
        st1.gameObject.layer = 8;
        st2.gameObject.layer = 8;
        wk1.gameObject.layer = 8;
        wk2.gameObject.layer = 8;
        wk3.gameObject.layer = 8;
        wk4.gameObject.layer = 8;
        wk5.gameObject.layer = 8;
        wk6.gameObject.layer = 8;
        wk7.gameObject.layer = 8;
        ak1_1.gameObject.layer = 8;
        ak1_2.gameObject.layer = 8;
        ak1_3.gameObject.layer = 8;
        ak2_1.gameObject.layer = 8;
        ak2_2.gameObject.layer = 8;
        ak2_3.gameObject.layer = 8;
        ak3_1.gameObject.layer = 8;
        ak3_2.gameObject.layer = 8;
        ak3_3.gameObject.layer = 8;

        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        if (gameObject.transform.localScale.x > 0)
            rigid.AddForce(new Vector2(-1f, 0f) * 20f, ForceMode2D.Impulse);
        if (gameObject.transform.localScale.x < 0)
            rigid.AddForce(new Vector2(1f, 0f) * 20f, ForceMode2D.Impulse);


        Invoke("offBackGolem", 0.2f);
        Invoke("offDamageGolem", 1.2f);
    }
    void offBackGolem()
    {
        rigid.velocity = Vector3.zero;
    }
    void offDamageGolem()
    {
        gameObject.layer = 7;
        st1.gameObject.layer = 7;
        st2.gameObject.layer = 7;
        wk1.gameObject.layer = 7;
        wk2.gameObject.layer = 7;
        wk3.gameObject.layer = 7;
        wk4.gameObject.layer = 7;
        wk5.gameObject.layer = 7;
        wk6.gameObject.layer = 7;
        wk7.gameObject.layer = 7;
        ak1_1.gameObject.layer = 7;
        ak1_2.gameObject.layer = 7;
        ak1_3.gameObject.layer = 7;
        ak2_1.gameObject.layer = 7;
        ak2_2.gameObject.layer = 7;
        ak2_3.gameObject.layer = 7;
        ak3_1.gameObject.layer = 7;
        ak3_2.gameObject.layer = 7;
        ak3_3.gameObject.layer = 7;

        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void Shield_Golem()
    {

    }
    //웨어 울프 애니메이션에 따른 콜라이더
    public void Golem_St1()
    {
        st1.enabled = true;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        
        skill1_1.enabled = false;
    }
    public void Golem_St2()
    {
        st1.enabled = false;
        st2.enabled = true;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        
        skill1_1.enabled = false;
    }
    public void Golem_Wk1()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = true;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        
        skill1_1.enabled = false;
    }
    public void Golem_Wk2()
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
        
        skill1_1.enabled = false;
    }
    public void Golem_Wk3()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = true;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        
        skill1_1.enabled = false;
    }
    public void Golem_Wk4()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = true;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        
        skill1_1.enabled = false;
    }
    public void Golem_Wk5()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = true;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;

        skill1_1.enabled = false;
    }
    public void Golem_Wk6()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = true;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;

        skill1_1.enabled = false;
    }
    public void Golem_Wk7()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = true;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;

        skill1_1.enabled = false;
    }
    public void Golem_Ak1_1()
    {
        is_combo = true;
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = true;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        
        skill1_1.enabled = false;
    }
    public void Golem_Ak1_2()
    {

        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = true;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        
        skill1_1.enabled = false;
    }
    public void Golem_Ak1_3()
    {
        if (gameObject.transform.localScale.x > 0)
        {
            golem_hit_effect1.transform.localScale = new Vector3(20f, 20f, 1f);
            golem_hit_effect1.gameObject.transform.position = gameObject.transform.position + new Vector3(2f, 0f);
        }
        else if (gameObject.transform.localScale.x < 0)
        {
            golem_hit_effect1.transform.localScale = new Vector3(-20f, 20f, 1f);
            golem_hit_effect1.gameObject.transform.position = gameObject.transform.position + new Vector3(-2f, 0f);
        }

        Instantiate(golem_hit_effect1);

        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = true;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        
        skill1_1.enabled = false;

        is_combo = false;
    }
    public void Golem_Ak2_1()
    {
        is_combo = true;
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = true;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        
        skill1_1.enabled = false;
    }
    public void Golem_Ak2_2()
    {

        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = true;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        
        skill1_1.enabled = false;
    }
    public void Golem_Ak2_3()
    {
        if (gameObject.transform.localScale.x > 0)
        {
            golem_hit_effect2.transform.localScale = new Vector3(20f, 20f, 1f);
            golem_hit_effect2.gameObject.transform.position = gameObject.transform.position + new Vector3(2f, 0f);
        }
        else if (gameObject.transform.localScale.x < 0)
        {
            golem_hit_effect2.transform.localScale = new Vector3(-20f, 20f, 1f);
            golem_hit_effect2.gameObject.transform.position = gameObject.transform.position + new Vector3(-2f, 0f);
        }

        Instantiate(golem_hit_effect2);

        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = true;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        
        skill1_1.enabled = false;

        is_combo = false;
    }
    public void Golem_Ak3_1()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = true;
        ak3_2.enabled = false;
        ak3_3.enabled = false;
        
        skill1_1.enabled = false;
    }
    public void Golem_Ak3_2()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = true;
        ak3_3.enabled = false;
        
        skill1_1.enabled = false;
    }
    public void Golem_Ak3_3()
    {
        if (gameObject.transform.localScale.x > 0)
        {
            golem_hit_effect3.transform.localScale = new Vector3(20f, 20f, 1f);
            golem_hit_effect3.gameObject.transform.position = gameObject.transform.position + new Vector3(2f, 0f);
        }
        else if (gameObject.transform.localScale.x < 0)
        {
            golem_hit_effect3.transform.localScale = new Vector3(-20f, 20f, 1f);
            golem_hit_effect3.gameObject.transform.position = gameObject.transform.position + new Vector3(-2f, 0f);
        }

        Instantiate(golem_hit_effect3);

        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        wk7.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
        ak3_1.enabled = false;
        ak3_2.enabled = false;
        ak3_3.enabled = true;
        
        skill1_1.enabled = false;

        is_combo = false;
    }
    
}
