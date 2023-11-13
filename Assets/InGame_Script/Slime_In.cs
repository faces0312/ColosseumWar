using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slime_In : MonoBehaviour
{
    public AudioSource attack1;
    public AudioSource skill;

    public Gm_InGame gm;
    //능력치 관련
    public int slime_hp;
    public int slime_dm;
    public int slime_skill_dm;
    public float slime_speed;

    public TextMeshProUGUI now_hp;
    public TextMeshProUGUI total_hp;

    public GameObject damage_la;
    public TextMeshProUGUI damage_label;
    //적위치(넉백의 위치를 알기 위함)

    public Image skillbutton_black;
    public SpriteRenderer spriteRenderer;
    public Animator anim;
    public Rigidbody2D rigid;
    


    //애니메이션 자르기
    public PolygonCollider2D st1;
    public PolygonCollider2D st2;
    public PolygonCollider2D wk1;
    public PolygonCollider2D wk2;
    public PolygonCollider2D ak1;
    public PolygonCollider2D ak2;
    public PolygonCollider2D ak3;
    public PolygonCollider2D ak4;
    public PolygonCollider2D ak5;
    public PolygonCollider2D ak6;
    public PolygonCollider2D sk1;

    //슬라임 원거리 공격각도
    
    //슬라임 원거리 공격 프리팹
    public GameObject slime_hit_effect;
    public GameObject slime_hit_effect2;
    public GameObject slime_hit_effect3;
    

    public Move_Slime move;

    public Button attack_button;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        damage_label.text = null;
        gameObject.tag = "Slime";
        skillbutton_black.gameObject.SetActive(false);
        gameObject.transform.position = new Vector2(0, 0);
        slime_hp = Data.Instance.gameData.slime_hp;
        total_hp.text = "/ " + Data.Instance.gameData.slime_hp.ToString();
        now_hp.text = slime_hp.ToString();

        st1.enabled = true;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk1.enabled = false;
    }
    private void Update()
    {
        if (Data.Instance.gameData.sound == false)
        {
            attack1.gameObject.GetComponent<AudioSource>().enabled = false;
            skill.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else if (Data.Instance.gameData.sound == true)
        {
            attack1.gameObject.GetComponent<AudioSource>().enabled = true;
            skill.gameObject.GetComponent<AudioSource>().enabled = true;
        }
        now_hp.text = slime_hp.ToString();
        if (slime_hp <= 0)
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
        damage_la.gameObject.transform.localPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 120f);
    }
    //스킬버튼
    public void SkillButton()
    {
        skill.Play();
        if (gameObject.activeSelf == true)
        {
            attack_button.gameObject.GetComponent<Button>().interactable = false;
            gameObject.tag = "PlayerSkillEffect_Slime";
            anim.SetBool("Is_Walk", false);
            anim.SetBool("Is_Skill", true);
            move.gameObject.GetComponent<Move_Slime>().enabled = false;
            slime_speed = 0;
            spriteRenderer.color = new Color(1, 1, 1, 1);
            skillbutton_black.gameObject.SetActive(true);
            gameObject.transform.localScale = new Vector3(15, 15, 1);
            st1.enabled = false;
            st2.enabled = false;
            wk1.enabled = false;
            wk2.enabled = false;
            ak1.enabled = false;
            ak2.enabled = false;
            ak3.enabled = false;
            ak4.enabled = false;
            ak5.enabled = false;
            ak6.enabled = false;
            sk1.enabled = true;

            Invoke("OffSkill", 0.6f);
        }

    }
    public void OffSkill()
    {
        if (gameObject.activeSelf == true)
        {
            attack_button.gameObject.GetComponent<Button>().interactable = true;
            gameObject.tag = "Slime";
            move.gameObject.GetComponent<Move_Slime>().enabled = true;
            gameObject.transform.localScale = new Vector3(5, 5, 1);
            anim.SetBool("Is_Skill", false);
            slime_speed = Data.Instance.gameData.slime_speed;
            st1.enabled = true;
            st2.enabled = false;
            wk1.enabled = false;
            wk2.enabled = false;
            ak1.enabled = false;
            ak2.enabled = false;
            ak3.enabled = false;
            ak4.enabled = false;
            ak5.enabled = false;
            ak6.enabled = false;
            sk1.enabled = false;
        }

    }

    //공격버튼
    public void AttackButton()
    {
        anim.Play("Slime_Attack");
        attack1.Play();
    }


    //웨어 울프 애니메이션에 따른 콜라이더
    public void Slime_St1()
    {
        st1.enabled = true;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk1.enabled = false;
    }
    public void Slime_St2()
    {
        st1.enabled = false;
        st2.enabled = true;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk1.enabled = false;
    }
    public void Slime_Wk1()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = true;
        wk2.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk1.enabled = false;
    }
    public void Slime_Wk2()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = true;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk1.enabled = false;
    }
    public void Slime_Ak1()
    {
        Instantiate(slime_hit_effect, transform.position, transform.rotation);
        if(Data.Instance.gameData.slime_characteristic==true)
        {
            Instantiate(slime_hit_effect2, transform.position, transform.rotation);
            Instantiate(slime_hit_effect3, transform.position, transform.rotation);
        }
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1.enabled = true;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk1.enabled = false;
    }
    public void Slime_Ak2()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1.enabled = false;
        ak2.enabled = true;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk1.enabled = false;
    }
    public void Slime_Ak3()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = true;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk1.enabled = false;
    }
    public void Slime_Ak4()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = true;
        ak5.enabled = false;
        ak6.enabled = false;
        sk1.enabled = false;
    }
    public void Slime_Ak5()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = true;
        ak6.enabled = false;
        sk1.enabled = false;
    }
    public void Slime_Ak6()
    {
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = true;
        sk1.enabled = false;
    }
    public void Slime_Sk1()
    {
        
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk1.enabled = true;

    }
}
