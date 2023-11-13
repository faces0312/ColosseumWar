using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;
using TMPro;

public class Reaper : MonoBehaviour
{
    public AudioSource attack1;
    public AudioSource attack2;
    public AudioSource skill_sound;

    public Gm_InGame gm;
    //능력치 관련
    public int reaper_hp;
    public int reaper_dm;
    public int reaper_skill_dm;
    public float reaper_speed;

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
    public PolygonCollider2D st3;
    public PolygonCollider2D st4;
    public PolygonCollider2D ak1_1;
    public PolygonCollider2D ak1_2;
    public PolygonCollider2D ak1_3;
    public PolygonCollider2D ak2_1;
    public PolygonCollider2D ak2_2;
    public PolygonCollider2D ak2_3;
    
    //사신 히트 이펙트
    public GameObject reaper_hit_effect1;
    public GameObject reaper_hit_effect2;


    //스킬 (사신)
    public Animator skill;
    //스킬 이펙트
    public Animator skillEffect;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        damage_label.text = null;
        gameObject.tag = "Reaper";
        skillbutton_black.gameObject.SetActive(false);
        gameObject.transform.position = new Vector2(0, 0);
        reaper_hp = Data.Instance.gameData.reaper_hp;
        total_hp.text = "/ " + Data.Instance.gameData.reaper_hp.ToString();
        now_hp.text = reaper_hp.ToString();

        st1.enabled = true;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;

        skill.gameObject.SetActive(false);
        skillEffect.gameObject.SetActive(false);

    }
    private void Update()
    {
        if (Data.Instance.gameData.sound == false)
        {
            attack1.gameObject.GetComponent<AudioSource>().enabled = false;
            attack2.gameObject.GetComponent<AudioSource>().enabled = false;
            skill_sound.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else if (Data.Instance.gameData.sound == true)
        {
            attack1.gameObject.GetComponent<AudioSource>().enabled = true;
            attack2.gameObject.GetComponent<AudioSource>().enabled = false;
            skill_sound.gameObject.GetComponent<AudioSource>().enabled = true;
        }

        now_hp.text = reaper_hp.ToString();
        if (reaper_hp <= 0)
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
        
        if (gameObject.activeSelf == true)
        {
            skill.gameObject.SetActive(true);
            
            if (gameObject.transform.localScale.x>0)
            {
                skill.gameObject.transform.localScale = new Vector3(10, 10, 1);
                skillEffect.gameObject.transform.localScale = new Vector3(10, 10, 1);
                skill.gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y + 2f, 0f);
                skillEffect.gameObject.transform.position = new Vector3(gameObject.transform.position.x + 4f, gameObject.transform.position.y + 1f, 0f);
            }
            else if(gameObject.transform.localScale.x < 0)
            {
                skill.gameObject.transform.localScale = new Vector3(-10, 10, 1);
                skillEffect.gameObject.transform.localScale = new Vector3(-10, 10, 1);
                skill.gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y + 2f, 0f);
                skillEffect.gameObject.transform.position = new Vector3(gameObject.transform.position.x - 4f, gameObject.transform.position.y + 1f, 0f);
            }

            skillbutton_black.gameObject.SetActive(true);
            skill.Play("Reaper_Skill");
            
            st1.enabled = true;
            st2.enabled = false;
            st3.enabled = false;
            st4.enabled = false;
            ak1_1.enabled = false;
            ak1_2.enabled = false;
            ak1_3.enabled = false;
            ak2_1.enabled = false;
            ak2_2.enabled = false;
            ak2_3.enabled = false;

            Invoke("OffSkill", 1f);
            Invoke("SkillEffect", 0.3f);
        }

    }
    public void SkillEffect()
    {
        skillEffect.gameObject.SetActive(true);
        skillEffect.Play("Reaper_SkillEffect");
        skill_sound.Play();
    }
    public void OffSkill()
    {skill_sound.Play();
        if (gameObject.activeSelf == true)
        {
            skill.gameObject.SetActive(false);
            skillEffect.gameObject.SetActive(false);
            st1.enabled = true;
            st2.enabled = false;
            st3.enabled = false;
            st4.enabled = false;
            ak1_1.enabled = false;
            ak1_2.enabled = false;
            ak1_3.enabled = false;
            ak2_1.enabled = false;
            ak2_2.enabled = false;
            ak2_3.enabled = false;
        }

    }

    //공격버튼
    public void AttackButton()
    {
        if (cnt_combo == 0)
        {
            anim.Play("Reaper_Attack1");
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
            anim.Play("Reaper_Attack2");
            attack2.Play();
        }

    }
    public void ComboReset()
    {
        is_combo = false;
        cnt_combo = 0;
    }

    //웨어 울프 애니메이션에 따른 콜라이더
    public void Reaper_St1()
    {
        st1.enabled = true;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
    }
    public void Reaper_St2()
    {
        st1.enabled = false;
        st2.enabled = true;
        st3.enabled = false;
        st4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
    }
    public void Reaper_St3()
    {
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = true;
        st4.enabled = false;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
    }
    public void Reaper_St4()
    {
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = true;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
    }
    public void Reaper_Ak1_1()
    {
        is_combo = true;
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = true;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
    }
    public void Reaper_Ak1_2()
    {
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = true;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
    }
    public void Reaper_Ak1_3()
    {
        if (gameObject.transform.localScale.x > 0)
        {
            if(Data.Instance.gameData.reaper_characteristic==false)
            {
                reaper_hit_effect1.transform.localScale = new Vector3(12f, 12f, 1f);
                reaper_hit_effect1.gameObject.transform.position = gameObject.transform.position + new Vector3(2f, 0f);
            }
            else if (Data.Instance.gameData.reaper_characteristic == true)
            {
                reaper_hit_effect1.transform.localScale = new Vector3(15f, 15f, 1f);
                reaper_hit_effect1.gameObject.transform.position = gameObject.transform.position + new Vector3(2f, 0f);
            }
        }
        else if (gameObject.transform.localScale.x < 0)
        {
            if (Data.Instance.gameData.reaper_characteristic == false)
            {
                reaper_hit_effect1.transform.localScale = new Vector3(-12f, 12f, 1f);
                reaper_hit_effect1.gameObject.transform.position = gameObject.transform.position + new Vector3(-2f, 0f);
            }
            else if(Data.Instance.gameData.reaper_characteristic==true)
            {
                reaper_hit_effect1.transform.localScale = new Vector3(-15f, 15f, 1f);
                reaper_hit_effect1.gameObject.transform.position = gameObject.transform.position + new Vector3(-2f, 0f);
            }
        }

        Instantiate(reaper_hit_effect1);

        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = true;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;

        is_combo = false;
    }
    public void Reaper_Ak2_1()
    {
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = true;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
    }
    public void Reaper_Ak2_2()
    {
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = true;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;
    }
    public void Reaper_Ak2_3()
    {
        if (gameObject.transform.localScale.x > 0)
        {
            if(Data.Instance.gameData.reaper_characteristic==false)
            {
                reaper_hit_effect2.transform.localScale = new Vector3(12f, 12f, 1f);
                reaper_hit_effect2.gameObject.transform.position = gameObject.transform.position + new Vector3(2f, 0f);
            }
            else if(Data.Instance.gameData.reaper_characteristic==true)
            {
                reaper_hit_effect2.transform.localScale = new Vector3(15f, 15f, 1f);
                reaper_hit_effect2.gameObject.transform.position = gameObject.transform.position + new Vector3(2f, 0f);
            }
        }
        else if (gameObject.transform.localScale.x < 0)
        {
            if(Data.Instance.gameData.reaper_characteristic==false)
            {
                reaper_hit_effect2.transform.localScale = new Vector3(-12f, 12f, 1f);
                reaper_hit_effect2.gameObject.transform.position = gameObject.transform.position + new Vector3(-2f, 0f);
            }
            else if(Data.Instance.gameData.reaper_characteristic==true)
            {
                reaper_hit_effect2.transform.localScale = new Vector3(-15f, 15f, 1f);
                reaper_hit_effect2.gameObject.transform.position = gameObject.transform.position + new Vector3(-2f, 0f);
            }
            
        }

        Instantiate(reaper_hit_effect2);

        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = true;
        ak1_1.enabled = false;
        ak1_2.enabled = false;
        ak1_3.enabled = false;
        ak2_1.enabled = false;
        ak2_2.enabled = false;
        ak2_3.enabled = false;

        is_combo = false;
    }
}
