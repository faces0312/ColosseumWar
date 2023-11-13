using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Assassin : MonoBehaviour
{
    public AudioSource attack;//공격
    public AudioSource hit;//피격
    public AudioSource skill;//스킬

    public SpriteRenderer spriteRenderer;

    public Character wolf_obj;//플레이어 위치
    public Skeleton skeleton_obj;//스켈레톤 플레이어
    public Golem golem_obj;//골렘 플레이어
    public Slime_In slime_obj;//슬라임 플레이어
    public Reaper reaper_obj;//사신 플레이어

    public float speed;//보스 이동속도
    
    public float skillCoolTime = 15f;
    public float skillDelay;
    public float atkCoolTime = 3f;
    public float atkDelay;

    //모션
    public PolygonCollider2D st1;
    public PolygonCollider2D st2;
    public PolygonCollider2D wk1;
    public PolygonCollider2D wk2;
    public PolygonCollider2D wk3;
    public PolygonCollider2D wk4;
    public PolygonCollider2D wk5;
    public PolygonCollider2D wk6;
    public PolygonCollider2D ak1;
    public PolygonCollider2D ak2;
    public PolygonCollider2D ak3;
    public PolygonCollider2D ak4;
    public PolygonCollider2D ak5;
    public PolygonCollider2D ak6;
    public PolygonCollider2D sk9;

    //스킬 이펙트 및 라인
    public Animator sk_ef1;
    public Animator sk_ef2;
    public Animator sk_ef3;
    public Animator sk_ef4;
    public Animator sk_ef5;
    public Animator sk_ef6;
    public Animator sk_ef7;
    public Animator sk_ef8;
    public GameObject line1;
    public GameObject line2;
    public GameObject line3;
    public GameObject line4;
    public GameObject line5;
    public GameObject line6;
    public GameObject line7;
    public GameObject line8;
    public SpriteRenderer line1_color;
    public SpriteRenderer line2_color;
    public SpriteRenderer line3_color;
    public SpriteRenderer line4_color;
    public SpriteRenderer line5_color;
    public SpriteRenderer line6_color;
    public SpriteRenderer line7_color;
    public SpriteRenderer line8_color;
    public float lineColor;

    //공격 이펙트
    public Animator ak_ef;

    //체력바
    public Slider boss_assassin_hp;
    
    public GameObject damage_label;
    public TextMeshProUGUI damage;
    //어택존, 점수
    public FollowCamera attack_zone;
    // Start is called before the first frame update
    void Start()
    {

        attack_zone = GameObject.Find("Main Camera").GetComponent<FollowCamera>();

        wolf_obj = GameObject.Find("Unit").transform.Find("Player").GetComponent<Character>();
        skeleton_obj = GameObject.Find("Unit").transform.Find("Player_Skeleton").GetComponent<Skeleton>();
        golem_obj = GameObject.Find("Unit").transform.Find("Golem").GetComponent<Golem>();
        slime_obj = GameObject.Find("Unit").transform.Find("Slime").GetComponent<Slime_In>();
        reaper_obj = GameObject.Find("Unit").transform.Find("Reaper").GetComponent<Reaper>();

        damage.text = null;

        st1.enabled = true;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = false;

        sk_ef1.gameObject.SetActive(false);
        sk_ef2.gameObject.SetActive(false);
        sk_ef3.gameObject.SetActive(false);
        sk_ef4.gameObject.SetActive(false);
        sk_ef5.gameObject.SetActive(false);
        sk_ef6.gameObject.SetActive(false);
        sk_ef7.gameObject.SetActive(false);
        sk_ef8.gameObject.SetActive(false);

        line1.gameObject.SetActive(false);
        line2.gameObject.SetActive(false);
        line3.gameObject.SetActive(false);
        line4.gameObject.SetActive(false);
        line5.gameObject.SetActive(false);
        line6.gameObject.SetActive(false);
        line7.gameObject.SetActive(false);
        line8.gameObject.SetActive(false);

        ak_ef.gameObject.SetActive(false);

        boss_assassin_hp.maxValue = Data.Instance.gameData.assassin_hp;
        speed = Data.Instance.gameData.assassin_speed;
        boss_assassin_hp.value = boss_assassin_hp.maxValue;

        atkDelay = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Data.Instance.gameData.sound == false)
        {
            attack.gameObject.GetComponent<AudioSource>().enabled = false;
            hit.gameObject.GetComponent<AudioSource>().enabled = false;
            skill.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else if (Data.Instance.gameData.sound == true)
        {
            attack.gameObject.GetComponent<AudioSource>().enabled = true;
            hit.gameObject.GetComponent<AudioSource>().enabled = true;
            skill.gameObject.GetComponent<AudioSource>().enabled = true;
        }

        if (boss_assassin_hp.value == 0)
        {
            
            offBack();
            offBackGolem();
            offBackReaper();
            offBackSkeleton();
            offBackSlime();
            offDamage();
            offDamageGolem();
            offDamageReaper();
            offDamageSkeleton();
            offDamageSlime();
            attack_zone.score += 100;
            if (attack_zone.death_cnt > 0)
                attack_zone.death_cnt--;

            attack_zone.card.gameObject.SetActive(true);
            attack_zone.card.GetComponent<Card_select>().Card();
            Time.timeScale = 0;
            Destroy(gameObject);
        }
            

        //skillDelay = skillCoolTime;
        if (skillDelay >= 0)
            skillDelay -= Time.deltaTime;
        if (Vector2.Distance(attack_zone.assassin_attack_zone_left.position, gameObject.transform.position) <= 3f ||
             Vector2.Distance(attack_zone.assassin_attack_zone_right.position, gameObject.transform.position) <= 3f)
        {
            if (atkDelay >= 0)
                atkDelay -= Time.deltaTime;
        }
        //
        lineColor += Time.deltaTime;
        if (line1.gameObject.activeSelf == true)
            line1_color.color = new Color(1, 1, 1, lineColor);
        else
        {
            lineColor = 0;
            line1_color.color = new Color(1, 1, 1, 0);
        }
        if (line2.gameObject.activeSelf == true)
            line2_color.color = new Color(1, 1, 1, lineColor);
        else
        {
            lineColor = 0;
            line2_color.color = new Color(1, 1, 1, 0);
        }
        if (line3.gameObject.activeSelf == true)
            line3_color.color = new Color(1, 1, 1, lineColor);
        else
        {
            lineColor = 0;
            line3_color.color = new Color(1, 1, 1, 0);
        }
        if (line4.gameObject.activeSelf == true)
            line4_color.color = new Color(1, 1, 1, lineColor);
        else
        {
            lineColor = 0;
            line4_color.color = new Color(1, 1, 1, 0);
        }
        if (line5.gameObject.activeSelf == true)
            line5_color.color = new Color(1, 1, 1, lineColor);
        else
        {
            lineColor = 0;
            line5_color.color = new Color(1, 1, 1, 0);
        }
        if (line6.gameObject.activeSelf == true)
            line6_color.color = new Color(1, 1, 1, lineColor);
        else
        {
            lineColor = 0;
            line6_color.color = new Color(1, 1, 1, 0);
        }
        if (line7.gameObject.activeSelf == true)
            line7_color.color = new Color(1, 1, 1, lineColor);
        else
        {
            lineColor = 0;
            line7_color.color = new Color(1, 1, 1, 0);
        }
        if (line8.gameObject.activeSelf == true)
            line8_color.color = new Color(1, 1, 1, lineColor);
        else
        {
            lineColor = 0;
            line8_color.color = new Color(1, 1, 1, 0);
        }
        //
        if (sk_ef1.gameObject.activeSelf == true)
        {
            sk_ef1.transform.Translate(Vector3.left * Time.deltaTime * 50f);
            sk_ef2.transform.Translate(Vector3.left * Time.deltaTime * 50f);
            sk_ef3.transform.Translate(Vector3.left * Time.deltaTime * 50f);
            sk_ef4.transform.Translate(Vector3.left * Time.deltaTime * 50f);
            sk_ef5.transform.Translate(Vector3.left * Time.deltaTime * 50f);
            sk_ef6.transform.Translate(Vector3.left * Time.deltaTime * 50f);
            sk_ef7.transform.Translate(Vector3.left * Time.deltaTime * 50f);
            sk_ef8.transform.Translate(Vector3.left * Time.deltaTime * 50f);
        }
        else
        {
            sk_ef1.transform.localPosition = new Vector3(0, 0, 0);
            sk_ef2.transform.localPosition = new Vector3(0, 0, 0);
            sk_ef3.transform.localPosition = new Vector3(0, 0, 0);
            sk_ef4.transform.localPosition = new Vector3(0, 0, 0);
            sk_ef5.transform.localPosition = new Vector3(0, 0, 0);
            sk_ef6.transform.localPosition = new Vector3(0, 0, 0);
            sk_ef7.transform.localPosition = new Vector3(0, 0, 0);
            sk_ef8.transform.localPosition = new Vector3(0, 0, 0);
        }
        //

        if(gameObject.transform.position.x - attack_zone.origin.gameObject.transform.position.x > 0)
        {
            transform.localScale = new Vector3(-6f, 6f, 1f);
            damage_label.gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(+6f, 6f, 1f);
            damage_label.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
        boss_assassin_hp.transform.position = transform.position + new Vector3(0.5f, 2.7f, 0f);
        damage_label.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //어쌔신 몸에 부딪혔을때
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Assassin")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Body_Assassin();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Skeleton" && gameObject.tag == "Assassin")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Body_Assassin_Skeleton();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Golem" && gameObject.tag == "Assassin")
        {
            hit.Play();
            if (golem_obj.skillEffect.activeSelf == false && attack_zone.gm.shield_cnt < 1)
                Body_Assassin_Golem();
            else if (attack_zone.gm.shield_cnt >= 1 && golem_obj.skillEffect.activeSelf == false)
            {
                attack_zone.gm.shield_cnt--;
            }
            if (golem_obj.skillEffect.activeSelf == true)
                Shield_Golem();
        }
        if (collision.gameObject.tag == "Slime" && gameObject.tag == "Assassin")
        {
            hit.Play();
            if (slime_obj.sk1.enabled == false && attack_zone.gm.shield_cnt < 1)
                Body_Assassin_Slime();
            else if (attack_zone.gm.shield_cnt >= 1)
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Reaper" && gameObject.tag == "Assassin")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Body_Assassin_Reaper();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        //공격
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Assassin_Atk")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Attack_Assassin();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Skeleton" && gameObject.tag == "Assassin_Atk")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Attack_Assassin_Skeleton();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Golem" && gameObject.tag == "Assassin_Atk")
        {
            hit.Play();
            if (golem_obj.skillEffect.activeSelf == false && attack_zone.gm.shield_cnt < 1)
                Attack_Assassin_Golem();
            else if (attack_zone.gm.shield_cnt >= 1 && golem_obj.skillEffect.activeSelf == false)
            {
                attack_zone.gm.shield_cnt--;
            }
            if (golem_obj.skillEffect.activeSelf == true)
                Shield_Golem();

        }
        if (collision.gameObject.tag == "Slime" && gameObject.tag == "Assassin_Atk")
        {
            hit.Play();
            if (slime_obj.sk1.enabled == false && attack_zone.gm.shield_cnt < 1)
                Attack_Assassin_Slime();
            else if (attack_zone.gm.shield_cnt >= 1)
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Reaper" && gameObject.tag == "Assassin_Atk")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Attack_Assassin_Reaper();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }

        //스킬
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Assassin_Skill")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Skill_Assassin();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Skeleton" && gameObject.tag == "Assassin_Skill")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Skill_Assassin_Skeleton();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Golem" && gameObject.tag == "Assassin_Skill")
        {
            hit.Play();
            if (golem_obj.skillEffect.activeSelf == false && attack_zone.gm.shield_cnt < 1)
                Skill_Assassin_Golem();
            else if (attack_zone.gm.shield_cnt >= 1 && golem_obj.skillEffect.activeSelf == false)
            {
                attack_zone.gm.shield_cnt--;
            }
            if (golem_obj.skillEffect.activeSelf == true)
                Shield_Golem();
        }
        if (collision.gameObject.tag == "Slime" && gameObject.tag == "Assassin_Skill")
        {
            hit.Play();
            if (slime_obj.sk1.enabled == false && attack_zone.gm.shield_cnt < 1)
                Skill_Assassin_Slime();
            else if (attack_zone.gm.shield_cnt >= 1)
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Reaper" && gameObject.tag == "Assassin_Skill")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Skill_Assassin_Reaper();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }


        if (collision.gameObject.tag == "PlayerEffect_W1")
        {
            hit.Play();
            OnDamageW1();
        }
        if (collision.gameObject.tag == "PlayerEffect_W2")
        {
            hit.Play();
            OnDamageW2();
        }
        if (collision.gameObject.tag == "PlayerEffect_W3")
        {
            hit.Play();
            OnDamageW3();
        }
        if (collision.gameObject.tag == "PlayerSkillEffect_Wolf")
        {
            hit.Play();
            OnDamageSkillWolf();
        }
        if (collision.gameObject.tag == "PlayerEffect_S1")
        {
            hit.Play();
            OnDamageS1();
        }
        if (collision.gameObject.tag == "PlayerEffect_S2")
        {
            hit.Play();
            OnDamageS2();
        }
        if (collision.gameObject.tag == "PlayerEffect_S3")
        {
            hit.Play();
            OnDamageS3();
        }
        //스켈레톤 스킬에 맞았을 때
        if (collision.gameObject.tag == "PlayerSkillEffect_S")
        {
            hit.Play();
            OnDamageSkillS();
        }
        //골렘한테 맞았을때
        if (collision.gameObject.tag == "PlayerEffect_G1")
        {
            hit.Play();
            OnDamageG1();
        }
        if (collision.gameObject.tag == "PlayerEffect_G2")
        {
            hit.Play();
            OnDamageG2();
        }
        if (collision.gameObject.tag == "PlayerEffect_G3")
        {
            hit.Play();
            OnDamageG3();
        }
        //슬라임한테 맞았을ㄸ
        if (collision.gameObject.tag == "PlayerEffect_Slime")
        {
            hit.Play();
            OnDamageSlime();
        }
        //슬라임 스킬에 맞았을 때
        if (collision.gameObject.tag == "PlayerSkillEffect_Slime")
        {
            hit.Play();
            OnDamageSkillSlime();
        }
        //사신한테 맞았을때
        if (collision.gameObject.tag == "PlayerEffect_R1")
        {
            hit.Play();
            OnDamageR1();
        }
        if (collision.gameObject.tag == "PlayerEffect_R2")
        {
            hit.Play();
            OnDamageR2();
        }
        //사신 스킬에 맞았을 때
        if (collision.gameObject.tag == "PlayerSkillEffect_Reaper")
        {
            hit.Play();
            OnDamageSkillReaper();
        }
        else if (collision.gameObject.tag == "Lightning")
        {
            hit.Play();
            OnDamageLightning();
        }
        else if (collision.gameObject.tag == "Arrow")
        {
            hit.Play();
            OnDamageArrow();
        }
    }
    //늑대인간
    void Body_Assassin()
    {
        wolf_obj.damage_label.text = Data.Instance.gameData.assassin_body_damage.ToString();
        wolf_obj.wolf_hp -= Data.Instance.gameData.assassin_body_damage;
        wolf_obj.gameObject.layer = 8;
        wolf_obj.st1.gameObject.layer = 8;
        wolf_obj.st2.gameObject.layer = 8;
        wolf_obj.wk1.gameObject.layer = 8;
        wolf_obj.wk2.gameObject.layer = 8;
        wolf_obj.ak1_1.gameObject.layer = 8;
        wolf_obj.ak1_2.gameObject.layer = 8;
        wolf_obj.ak1_3.gameObject.layer = 8;
        wolf_obj.ak2_1.gameObject.layer = 8;
        wolf_obj.ak2_2.gameObject.layer = 8;
        wolf_obj.ak2_3.gameObject.layer = 8;
        wolf_obj.ak3_1.gameObject.layer = 8;
        wolf_obj.ak3_2.gameObject.layer = 8;
        wolf_obj.ak3_3.gameObject.layer = 8;

        wolf_obj.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = wolf_obj.transform.position.x - transform.position.x > 0 ? 1 : -1;
        wolf_obj.rigid.AddForce(new Vector2(dirc, 0f) * 15f, ForceMode2D.Impulse);

        Invoke("offBack", 0.2f);
        Invoke("offDamaged", 1.2f);
    }
    void Attack_Assassin()
    {
        wolf_obj.damage_label.text = Data.Instance.gameData.assassin_damage.ToString();
        wolf_obj.wolf_hp -= Data.Instance.gameData.assassin_damage;
        wolf_obj.gameObject.layer = 8;
        wolf_obj.st1.gameObject.layer = 8;
        wolf_obj.st2.gameObject.layer = 8;
        wolf_obj.wk1.gameObject.layer = 8;
        wolf_obj.wk2.gameObject.layer = 8;
        wolf_obj.ak1_1.gameObject.layer = 8;
        wolf_obj.ak1_2.gameObject.layer = 8;
        wolf_obj.ak1_3.gameObject.layer = 8;
        wolf_obj.ak2_1.gameObject.layer = 8;
        wolf_obj.ak2_2.gameObject.layer = 8;
        wolf_obj.ak2_3.gameObject.layer = 8;
        wolf_obj.ak3_1.gameObject.layer = 8;
        wolf_obj.ak3_2.gameObject.layer = 8;
        wolf_obj.ak3_3.gameObject.layer = 8;

        wolf_obj.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = wolf_obj.transform.position.x - transform.position.x > 0 ? 1 : -1;
        wolf_obj.rigid.AddForce(new Vector2(dirc, 0f) * 15f, ForceMode2D.Impulse);

        Invoke("offBack", 0.2f);
        Invoke("offDamaged", 1.2f);
    }
    void Skill_Assassin()
    {
        wolf_obj.damage_label.text = Data.Instance.gameData.assassin_skill_damage.ToString();
        wolf_obj.wolf_hp -= Data.Instance.gameData.assassin_skill_damage;
        wolf_obj.gameObject.layer = 8;
        wolf_obj.st1.gameObject.layer = 8;
        wolf_obj.st2.gameObject.layer = 8;
        wolf_obj.wk1.gameObject.layer = 8;
        wolf_obj.wk2.gameObject.layer = 8;
        wolf_obj.ak1_1.gameObject.layer = 8;
        wolf_obj.ak1_2.gameObject.layer = 8;
        wolf_obj.ak1_3.gameObject.layer = 8;
        wolf_obj.ak2_1.gameObject.layer = 8;
        wolf_obj.ak2_2.gameObject.layer = 8;
        wolf_obj.ak2_3.gameObject.layer = 8;
        wolf_obj.ak3_1.gameObject.layer = 8;
        wolf_obj.ak3_2.gameObject.layer = 8;
        wolf_obj.ak3_3.gameObject.layer = 8;

        wolf_obj.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = wolf_obj.transform.position.x - transform.position.x > 0 ? 1 : -1;
        wolf_obj.rigid.AddForce(new Vector2(dirc, 0f) * 15f, ForceMode2D.Impulse);

        Invoke("offBack", 0.2f);
        Invoke("offDamaged", 1.2f);
    }
    void offBack()
    {
        wolf_obj.rigid.velocity = Vector3.zero;
    }
    void offDamaged()
    {
        wolf_obj.damage_label.text = null;
        wolf_obj.gameObject.layer = 7;
        wolf_obj.st1.gameObject.layer = 7;
        wolf_obj.st2.gameObject.layer = 7;
        wolf_obj.wk1.gameObject.layer = 7;
        wolf_obj.wk2.gameObject.layer = 7;
        wolf_obj.ak1_1.gameObject.layer = 7;
        wolf_obj.ak1_2.gameObject.layer = 7;
        wolf_obj.ak1_3.gameObject.layer = 7;
        wolf_obj.ak2_1.gameObject.layer = 7;
        wolf_obj.ak2_2.gameObject.layer = 7;
        wolf_obj.ak2_3.gameObject.layer = 7;
        wolf_obj.ak3_1.gameObject.layer = 7;
        wolf_obj.ak3_2.gameObject.layer = 7;
        wolf_obj.ak3_3.gameObject.layer = 7;
        wolf_obj.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    //스켈레톤
    void Body_Assassin_Skeleton()
    {
        skeleton_obj.damage_label.text = Data.Instance.gameData.assassin_body_damage.ToString();
        skeleton_obj.skeleton_hp -= Data.Instance.gameData.assassin_body_damage;
        skeleton_obj.gameObject.layer = 8;
        skeleton_obj.st1.gameObject.layer = 8;
        skeleton_obj.st2.gameObject.layer = 8;
        skeleton_obj.wk1.gameObject.layer = 8;
        skeleton_obj.wk2.gameObject.layer = 8;
        skeleton_obj.wk3.gameObject.layer = 8;
        skeleton_obj.wk4.gameObject.layer = 8;
        skeleton_obj.ak1_1.gameObject.layer = 8;
        skeleton_obj.ak1_2.gameObject.layer = 8;
        skeleton_obj.ak1_3.gameObject.layer = 8;
        skeleton_obj.ak2_1.gameObject.layer = 8;
        skeleton_obj.ak2_2.gameObject.layer = 8;
        skeleton_obj.ak2_3.gameObject.layer = 8;
        skeleton_obj.ak3_1.gameObject.layer = 8;
        skeleton_obj.ak3_2.gameObject.layer = 8;
        skeleton_obj.ak3_3.gameObject.layer = 8;
        skeleton_obj.ak3_4.gameObject.layer = 8;
        skeleton_obj.ak3_5.gameObject.layer = 8;
        skeleton_obj.ak3_6.gameObject.layer = 8;
        skeleton_obj.ak3_7.gameObject.layer = 8;


        skeleton_obj.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = skeleton_obj.transform.position.x - transform.position.x > 0 ? 1 : -1;
        skeleton_obj.rigid.AddForce(new Vector2(dirc, 0f) * 15f, ForceMode2D.Impulse);

        Invoke("offBackSkeleton", 0.2f);
        Invoke("offDamageSkeleton", 1.2f);
    }
    void Attack_Assassin_Skeleton()
    {
        skeleton_obj.damage_label.text = Data.Instance.gameData.assassin_damage.ToString();
        skeleton_obj.skeleton_hp -= Data.Instance.gameData.assassin_damage;
        skeleton_obj.gameObject.layer = 8;
        skeleton_obj.st1.gameObject.layer = 8;
        skeleton_obj.st2.gameObject.layer = 8;
        skeleton_obj.wk1.gameObject.layer = 8;
        skeleton_obj.wk2.gameObject.layer = 8;
        skeleton_obj.wk3.gameObject.layer = 8;
        skeleton_obj.wk4.gameObject.layer = 8;
        skeleton_obj.ak1_1.gameObject.layer = 8;
        skeleton_obj.ak1_2.gameObject.layer = 8;
        skeleton_obj.ak1_3.gameObject.layer = 8;
        skeleton_obj.ak2_1.gameObject.layer = 8;
        skeleton_obj.ak2_2.gameObject.layer = 8;
        skeleton_obj.ak2_3.gameObject.layer = 8;
        skeleton_obj.ak3_1.gameObject.layer = 8;
        skeleton_obj.ak3_2.gameObject.layer = 8;
        skeleton_obj.ak3_3.gameObject.layer = 8;
        skeleton_obj.ak3_4.gameObject.layer = 8;
        skeleton_obj.ak3_5.gameObject.layer = 8;
        skeleton_obj.ak3_6.gameObject.layer = 8;
        skeleton_obj.ak3_7.gameObject.layer = 8;


        skeleton_obj.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = skeleton_obj.transform.position.x - transform.position.x > 0 ? 1 : -1;
        skeleton_obj.rigid.AddForce(new Vector2(dirc, 0f) * 15f, ForceMode2D.Impulse);

        Invoke("offBackSkeleton", 0.2f);
        Invoke("offDamageSkeleton", 1.2f);
    }
    void Skill_Assassin_Skeleton()
    {
        skeleton_obj.damage_label.text = Data.Instance.gameData.assassin_skill_damage.ToString();
        skeleton_obj.skeleton_hp -= Data.Instance.gameData.assassin_skill_damage;
        skeleton_obj.gameObject.layer = 8;
        skeleton_obj.st1.gameObject.layer = 8;
        skeleton_obj.st2.gameObject.layer = 8;
        skeleton_obj.wk1.gameObject.layer = 8;
        skeleton_obj.wk2.gameObject.layer = 8;
        skeleton_obj.wk3.gameObject.layer = 8;
        skeleton_obj.wk4.gameObject.layer = 8;
        skeleton_obj.ak1_1.gameObject.layer = 8;
        skeleton_obj.ak1_2.gameObject.layer = 8;
        skeleton_obj.ak1_3.gameObject.layer = 8;
        skeleton_obj.ak2_1.gameObject.layer = 8;
        skeleton_obj.ak2_2.gameObject.layer = 8;
        skeleton_obj.ak2_3.gameObject.layer = 8;
        skeleton_obj.ak3_1.gameObject.layer = 8;
        skeleton_obj.ak3_2.gameObject.layer = 8;
        skeleton_obj.ak3_3.gameObject.layer = 8;
        skeleton_obj.ak3_4.gameObject.layer = 8;
        skeleton_obj.ak3_5.gameObject.layer = 8;
        skeleton_obj.ak3_6.gameObject.layer = 8;
        skeleton_obj.ak3_7.gameObject.layer = 8;


        skeleton_obj.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = skeleton_obj.transform.position.x - transform.position.x > 0 ? 1 : -1;
        skeleton_obj.rigid.AddForce(new Vector2(dirc, 0f) * 15f, ForceMode2D.Impulse);

        Invoke("offBackSkeleton", 0.2f);
        Invoke("offDamageSkeleton", 1.2f);
    }
    void offBackSkeleton()
    {
        skeleton_obj.rigid.velocity = Vector3.zero;
    }
    void offDamageSkeleton()
    {
        skeleton_obj.damage_label.text = null;
        skeleton_obj.gameObject.layer = 7;
        skeleton_obj.st1.gameObject.layer = 7;
        skeleton_obj.st2.gameObject.layer = 7;
        skeleton_obj.wk1.gameObject.layer = 7;
        skeleton_obj.wk2.gameObject.layer = 7;
        skeleton_obj.wk3.gameObject.layer = 7;
        skeleton_obj.wk4.gameObject.layer = 7;
        skeleton_obj.ak1_1.gameObject.layer = 7;
        skeleton_obj.ak1_2.gameObject.layer = 7;
        skeleton_obj.ak1_3.gameObject.layer = 7;
        skeleton_obj.ak2_1.gameObject.layer = 7;
        skeleton_obj.ak2_2.gameObject.layer = 7;
        skeleton_obj.ak2_3.gameObject.layer = 7;
        skeleton_obj.ak3_1.gameObject.layer = 7;
        skeleton_obj.ak3_2.gameObject.layer = 7;
        skeleton_obj.ak3_3.gameObject.layer = 7;
        skeleton_obj.ak3_4.gameObject.layer = 7;
        skeleton_obj.ak3_5.gameObject.layer = 7;
        skeleton_obj.ak3_6.gameObject.layer = 7;
        skeleton_obj.ak3_7.gameObject.layer = 7;
        skeleton_obj.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    //골렘
    void Body_Assassin_Golem()
    {
        golem_obj.damage_label.text = Data.Instance.gameData.assassin_body_damage.ToString();
        golem_obj.golem_hp -= Data.Instance.gameData.assassin_body_damage;
        golem_obj.gameObject.layer = 8;
        golem_obj.st1.gameObject.layer = 8;
        golem_obj.st2.gameObject.layer = 8;
        golem_obj.wk1.gameObject.layer = 8;
        golem_obj.wk2.gameObject.layer = 8;
        golem_obj.wk3.gameObject.layer = 8;
        golem_obj.wk4.gameObject.layer = 8;
        golem_obj.wk5.gameObject.layer = 8;
        golem_obj.wk6.gameObject.layer = 8;
        golem_obj.wk7.gameObject.layer = 8;
        golem_obj.ak1_1.gameObject.layer = 8;
        golem_obj.ak1_2.gameObject.layer = 8;
        golem_obj.ak1_3.gameObject.layer = 8;
        golem_obj.ak2_1.gameObject.layer = 8;
        golem_obj.ak2_2.gameObject.layer = 8;
        golem_obj.ak2_3.gameObject.layer = 8;
        golem_obj.ak3_1.gameObject.layer = 8;
        golem_obj.ak3_2.gameObject.layer = 8;
        golem_obj.ak3_3.gameObject.layer = 8;

        golem_obj.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = golem_obj.transform.position.x - transform.position.x > 0 ? 1 : -1;
        golem_obj.rigid.AddForce(new Vector2(dirc, 0f) * 30f, ForceMode2D.Impulse);

        Invoke("offBackGolem", 0.2f);
        Invoke("offDamageGolem", 1.2f);
    }
    void Attack_Assassin_Golem()
    {
        golem_obj.damage_label.text = Data.Instance.gameData.assassin_damage.ToString();
        golem_obj.golem_hp -= Data.Instance.gameData.assassin_damage;
        golem_obj.gameObject.layer = 8;
        golem_obj.st1.gameObject.layer = 8;
        golem_obj.st2.gameObject.layer = 8;
        golem_obj.wk1.gameObject.layer = 8;
        golem_obj.wk2.gameObject.layer = 8;
        golem_obj.wk3.gameObject.layer = 8;
        golem_obj.wk4.gameObject.layer = 8;
        golem_obj.wk5.gameObject.layer = 8;
        golem_obj.wk6.gameObject.layer = 8;
        golem_obj.wk7.gameObject.layer = 8;
        golem_obj.ak1_1.gameObject.layer = 8;
        golem_obj.ak1_2.gameObject.layer = 8;
        golem_obj.ak1_3.gameObject.layer = 8;
        golem_obj.ak2_1.gameObject.layer = 8;
        golem_obj.ak2_2.gameObject.layer = 8;
        golem_obj.ak2_3.gameObject.layer = 8;
        golem_obj.ak3_1.gameObject.layer = 8;
        golem_obj.ak3_2.gameObject.layer = 8;
        golem_obj.ak3_3.gameObject.layer = 8;

        golem_obj.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = golem_obj.transform.position.x - transform.position.x > 0 ? 1 : -1;
        golem_obj.rigid.AddForce(new Vector2(dirc, 0f) * 30f, ForceMode2D.Impulse);

        Invoke("offBackGolem", 0.2f);
        Invoke("offDamageGolem", 1.2f);
    }
    void Skill_Assassin_Golem()
    {
        golem_obj.damage_label.text = Data.Instance.gameData.assassin_skill_damage.ToString();
        golem_obj.golem_hp -= Data.Instance.gameData.assassin_skill_damage;
        golem_obj.gameObject.layer = 8;
        golem_obj.st1.gameObject.layer = 8;
        golem_obj.st2.gameObject.layer = 8;
        golem_obj.wk1.gameObject.layer = 8;
        golem_obj.wk2.gameObject.layer = 8;
        golem_obj.wk3.gameObject.layer = 8;
        golem_obj.wk4.gameObject.layer = 8;
        golem_obj.wk5.gameObject.layer = 8;
        golem_obj.wk6.gameObject.layer = 8;
        golem_obj.wk7.gameObject.layer = 8;
        golem_obj.ak1_1.gameObject.layer = 8;
        golem_obj.ak1_2.gameObject.layer = 8;
        golem_obj.ak1_3.gameObject.layer = 8;
        golem_obj.ak2_1.gameObject.layer = 8;
        golem_obj.ak2_2.gameObject.layer = 8;
        golem_obj.ak2_3.gameObject.layer = 8;
        golem_obj.ak3_1.gameObject.layer = 8;
        golem_obj.ak3_2.gameObject.layer = 8;
        golem_obj.ak3_3.gameObject.layer = 8;

        golem_obj.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = golem_obj.transform.position.x - transform.position.x > 0 ? 1 : -1;
        golem_obj.rigid.AddForce(new Vector2(dirc, 0f) * 30f, ForceMode2D.Impulse);

        Invoke("offBackGolem", 0.2f);
        Invoke("offDamageGolem", 1.2f);
    }
    void Shield_Golem()
    {

    }
    void offBackGolem()
    {
        golem_obj.rigid.velocity = Vector3.zero;
    }
    void offDamageGolem()
    {
        golem_obj.damage_label.text = null;
        golem_obj.gameObject.layer = 7;
        golem_obj.st1.gameObject.layer = 7;
        golem_obj.st2.gameObject.layer = 7;
        golem_obj.wk1.gameObject.layer = 7;
        golem_obj.wk2.gameObject.layer = 7;
        golem_obj.wk3.gameObject.layer = 7;
        golem_obj.wk4.gameObject.layer = 7;
        golem_obj.wk5.gameObject.layer = 7;
        golem_obj.wk6.gameObject.layer = 7;
        golem_obj.wk7.gameObject.layer = 7;
        golem_obj.ak1_1.gameObject.layer = 7;
        golem_obj.ak1_2.gameObject.layer = 7;
        golem_obj.ak1_3.gameObject.layer = 7;
        golem_obj.ak2_1.gameObject.layer = 7;
        golem_obj.ak2_2.gameObject.layer = 7;
        golem_obj.ak2_3.gameObject.layer = 7;
        golem_obj.ak3_1.gameObject.layer = 7;
        golem_obj.ak3_2.gameObject.layer = 7;
        golem_obj.ak3_3.gameObject.layer = 7;

        golem_obj.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    //슬라임
    void Body_Assassin_Slime()
    {
        slime_obj.damage_label.text = Data.Instance.gameData.assassin_body_damage.ToString();
        slime_obj.slime_hp -= Data.Instance.gameData.assassin_body_damage;
        slime_obj.gameObject.layer = 8;
        slime_obj.st1.gameObject.layer = 8;
        slime_obj.st2.gameObject.layer = 8;
        slime_obj.wk1.gameObject.layer = 8;
        slime_obj.wk2.gameObject.layer = 8;
        slime_obj.ak1.gameObject.layer = 8;
        slime_obj.ak2.gameObject.layer = 8;
        slime_obj.ak3.gameObject.layer = 8;
        slime_obj.ak4.gameObject.layer = 8;
        slime_obj.ak5.gameObject.layer = 8;
        slime_obj.ak6.gameObject.layer = 8;
        slime_obj.sk1.gameObject.layer = 8;

        slime_obj.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = slime_obj.transform.position.x - transform.position.x > 0 ? 1 : -1;
        slime_obj.rigid.AddForce(new Vector2(dirc, 0f) * 20f, ForceMode2D.Impulse);

        Invoke("offBackSlime", 0.2f);
        Invoke("offDamageSlime", 1.2f);
    }
    void Attack_Assassin_Slime()
    {
        slime_obj.damage_label.text = Data.Instance.gameData.assassin_damage.ToString();
        slime_obj.slime_hp -= Data.Instance.gameData.assassin_damage;
        slime_obj.gameObject.layer = 8;
        slime_obj.st1.gameObject.layer = 8;
        slime_obj.st2.gameObject.layer = 8;
        slime_obj.wk1.gameObject.layer = 8;
        slime_obj.wk2.gameObject.layer = 8;
        slime_obj.ak1.gameObject.layer = 8;
        slime_obj.ak2.gameObject.layer = 8;
        slime_obj.ak3.gameObject.layer = 8;
        slime_obj.ak4.gameObject.layer = 8;
        slime_obj.ak5.gameObject.layer = 8;
        slime_obj.ak6.gameObject.layer = 8;
        slime_obj.sk1.gameObject.layer = 8;

        slime_obj.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = slime_obj.transform.position.x - transform.position.x > 0 ? 1 : -1;
        slime_obj.rigid.AddForce(new Vector2(dirc, 0f) * 20f, ForceMode2D.Impulse);

        Invoke("offBackSlime", 0.2f);
        Invoke("offDamageSlime", 1.2f);
    }
    void Skill_Assassin_Slime()
    {
        slime_obj.damage_label.text = Data.Instance.gameData.assassin_skill_damage.ToString();
        slime_obj.slime_hp -= Data.Instance.gameData.assassin_skill_damage;
        slime_obj.gameObject.layer = 8;
        slime_obj.st1.gameObject.layer = 8;
        slime_obj.st2.gameObject.layer = 8;
        slime_obj.wk1.gameObject.layer = 8;
        slime_obj.wk2.gameObject.layer = 8;
        slime_obj.ak1.gameObject.layer = 8;
        slime_obj.ak2.gameObject.layer = 8;
        slime_obj.ak3.gameObject.layer = 8;
        slime_obj.ak4.gameObject.layer = 8;
        slime_obj.ak5.gameObject.layer = 8;
        slime_obj.ak6.gameObject.layer = 8;
        slime_obj.sk1.gameObject.layer = 8;

        slime_obj.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = slime_obj.transform.position.x - transform.position.x > 0 ? 1 : -1;
        slime_obj.rigid.AddForce(new Vector2(dirc, 0f) * 20f, ForceMode2D.Impulse);

        Invoke("offBackSlime", 0.2f);
        Invoke("offDamageSlime", 1.2f);
    }
    void offBackSlime()
    {
        slime_obj.rigid.velocity = Vector3.zero;
    }
    void offDamageSlime()
    {
        slime_obj.damage_label.text = null;
        slime_obj.gameObject.layer = 7;
        slime_obj.st1.gameObject.layer = 7;
        slime_obj.st2.gameObject.layer = 7;
        slime_obj.wk1.gameObject.layer = 7;
        slime_obj.wk2.gameObject.layer = 7;
        slime_obj.ak1.gameObject.layer = 7;
        slime_obj.ak2.gameObject.layer = 7;
        slime_obj.ak3.gameObject.layer = 7;
        slime_obj.ak4.gameObject.layer = 7;
        slime_obj.ak5.gameObject.layer = 7;
        slime_obj.ak6.gameObject.layer = 7;
        slime_obj.sk1.gameObject.layer = 7;
        slime_obj.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    //사신
    void Body_Assassin_Reaper()
    {
        reaper_obj.damage_label.text = Data.Instance.gameData.assassin_body_damage.ToString();
        reaper_obj.reaper_hp -= Data.Instance.gameData.assassin_body_damage;
        reaper_obj.gameObject.layer = 8;
        reaper_obj.st1.gameObject.layer = 8;
        reaper_obj.st2.gameObject.layer = 8;
        reaper_obj.st3.gameObject.layer = 8;
        reaper_obj.st4.gameObject.layer = 8;
        reaper_obj.ak1_1.gameObject.layer = 8;
        reaper_obj.ak1_2.gameObject.layer = 8;
        reaper_obj.ak1_3.gameObject.layer = 8;
        reaper_obj.ak2_1.gameObject.layer = 8;
        reaper_obj.ak2_2.gameObject.layer = 8;
        reaper_obj.ak2_3.gameObject.layer = 8;

        reaper_obj.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = reaper_obj.transform.position.x - transform.position.x > 0 ? 1 : -1;
        reaper_obj.rigid.AddForce(new Vector2(dirc, 0f) * 20f, ForceMode2D.Impulse);

        Invoke("offBackReaper", 0.2f);
        Invoke("offDamageReaper", 1.2f);
    }
    void Attack_Assassin_Reaper()
    {
        reaper_obj.damage_label.text = Data.Instance.gameData.assassin_damage.ToString();
        reaper_obj.reaper_hp -= Data.Instance.gameData.assassin_damage;
        reaper_obj.gameObject.layer = 8;
        reaper_obj.st1.gameObject.layer = 8;
        reaper_obj.st2.gameObject.layer = 8;
        reaper_obj.st3.gameObject.layer = 8;
        reaper_obj.st4.gameObject.layer = 8;
        reaper_obj.ak1_1.gameObject.layer = 8;
        reaper_obj.ak1_2.gameObject.layer = 8;
        reaper_obj.ak1_3.gameObject.layer = 8;
        reaper_obj.ak2_1.gameObject.layer = 8;
        reaper_obj.ak2_2.gameObject.layer = 8;
        reaper_obj.ak2_3.gameObject.layer = 8;

        reaper_obj.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = reaper_obj.transform.position.x - transform.position.x > 0 ? 1 : -1;
        reaper_obj.rigid.AddForce(new Vector2(dirc, 0f) * 20f, ForceMode2D.Impulse);

        Invoke("offBackReaper", 0.2f);
        Invoke("offDamageReaper", 1.2f);
    }
    void Skill_Assassin_Reaper()
    {
        reaper_obj.damage_label.text = Data.Instance.gameData.assassin_skill_damage.ToString();
        reaper_obj.reaper_hp -= Data.Instance.gameData.assassin_skill_damage;
        reaper_obj.gameObject.layer = 8;
        reaper_obj.st1.gameObject.layer = 8;
        reaper_obj.st2.gameObject.layer = 8;
        reaper_obj.st3.gameObject.layer = 8;
        reaper_obj.st4.gameObject.layer = 8;
        reaper_obj.ak1_1.gameObject.layer = 8;
        reaper_obj.ak1_2.gameObject.layer = 8;
        reaper_obj.ak1_3.gameObject.layer = 8;
        reaper_obj.ak2_1.gameObject.layer = 8;
        reaper_obj.ak2_2.gameObject.layer = 8;
        reaper_obj.ak2_3.gameObject.layer = 8;

        reaper_obj.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = reaper_obj.transform.position.x - transform.position.x > 0 ? 1 : -1;
        reaper_obj.rigid.AddForce(new Vector2(dirc, 0f) * 20f, ForceMode2D.Impulse);

        Invoke("offBackReaper", 0.2f);
        Invoke("offDamageReaper", 1.2f);
    }
    void offBackReaper()
    {
        reaper_obj.rigid.velocity = Vector3.zero;
    }
    void offDamageReaper()
    {
        reaper_obj.damage_label.text = null;
        reaper_obj.gameObject.layer = 7;
        reaper_obj.st1.gameObject.layer = 7;
        reaper_obj.st2.gameObject.layer = 7;
        reaper_obj.st3.gameObject.layer = 7;
        reaper_obj.st4.gameObject.layer = 7;
        reaper_obj.ak1_1.gameObject.layer = 7;
        reaper_obj.ak1_2.gameObject.layer = 7;
        reaper_obj.ak1_3.gameObject.layer = 7;
        reaper_obj.ak2_1.gameObject.layer = 7;
        reaper_obj.ak2_2.gameObject.layer = 7;
        reaper_obj.ak2_3.gameObject.layer = 7;
        reaper_obj.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    //
    void OnDamageLightning()
    {
        damage.text = 10.ToString();

        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);


        boss_assassin_hp.value -= 10;
        Invoke("offDamage", 0.75f);
    }
    void OnDamageArrow()
    {
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);


        if (Data.Instance.gameData.arrowlv == 1)
        {
            boss_assassin_hp.value -= 4;
            damage.text = 4.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 2)
        {
            boss_assassin_hp.value -= 5;
            damage.text = 5.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 3)
        {
            boss_assassin_hp.value -= 6;
            damage.text = 6.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 4)
        {
            boss_assassin_hp.value -= 7;
            damage.text = 7.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 5)
        {
            boss_assassin_hp.value -= 8;
            damage.text = 8.ToString();
        }
        Invoke("offDamage", 0.75f);
    }
    //울프한테 공격 받았을 때
    void OnDamageW1()
    {
        damage.text = Data.Instance.gameData.wolf_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        
        boss_assassin_hp.value -= Data.Instance.gameData.wolf_damage;
        Invoke("offDamage", 0.75f);
    }
    void OnDamageW2()
    {
        damage.text = Data.Instance.gameData.wolf_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);
        boss_assassin_hp.value -= Data.Instance.gameData.wolf_damage;
        Invoke("offDamage", 0.75f);
    }
    void OnDamageW3()
    {
        damage.text = Data.Instance.gameData.wolf_last_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);
        boss_assassin_hp.value -= Data.Instance.gameData.wolf_last_damage;
        Invoke("offDamage", 0.75f);
    }
    void OnDamageSkillWolf()
    {
        damage.text = Data.Instance.gameData.wolf_skill_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        boss_assassin_hp.value -= Data.Instance.gameData.wolf_skill_damage;


        Invoke("offDamage", 0.5f);
    }
    //스켈레톤한테 공격받았을 때
    void OnDamageS1()
    {
        damage.text = Data.Instance.gameData.skeleton_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);
        boss_assassin_hp.value -= Data.Instance.gameData.skeleton_damage;
        Invoke("offDamage", 1f);
    }
    void OnDamageS2()
    {
        damage.text = Data.Instance.gameData.skeleton_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);
        boss_assassin_hp.value -= Data.Instance.gameData.skeleton_damage;
        Invoke("offDamage", 1f);
    }
    void OnDamageS3()
    {
        damage.text = Data.Instance.gameData.skeleton_last_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);
        boss_assassin_hp.value -= Data.Instance.gameData.skeleton_last_damage;
        Invoke("offDamage", 1f);
    }
    void OnDamageSkillS()
    {
        damage.text = Data.Instance.gameData.skeleton_skill_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        boss_assassin_hp.value -= Data.Instance.gameData.skeleton_skill_damage;


        Invoke("offDamage", 0.6f);
    }
    //골렘한테 맞았을때
    void OnDamageG1()
    {
        damage.text = Data.Instance.gameData.golem_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17; 
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_assassin_hp.value -= Data.Instance.gameData.golem_damage;


        Invoke("offDamage", 0.75f);
    }
    void OnDamageG2()
    {
        damage.text = Data.Instance.gameData.golem_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17; 
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_assassin_hp.value -= Data.Instance.gameData.golem_damage;


        Invoke("offDamage", 0.75f);
    }
    void OnDamageG3()
    {
        damage.text = Data.Instance.gameData.goelm_last_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17; 
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_assassin_hp.value -= Data.Instance.gameData.goelm_last_damage;


        Invoke("offDamage", 0.75f);
    }
    void OnDamageSlime()
    {
        damage.text = Data.Instance.gameData.slime_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17; 
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_assassin_hp.value -= Data.Instance.gameData.slime_damage;


        Invoke("offDamage", 0.5f);
    }
    void OnDamageSkillSlime()
    {
        damage.text = Data.Instance.gameData.sllime_skill_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17; 
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_assassin_hp.value -= Data.Instance.gameData.sllime_skill_damage;


        Invoke("offDamage", 1.5f);
    }
    //사신
    void OnDamageR1()
    {
        damage.text = Data.Instance.gameData.reaper_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17; 
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_assassin_hp.value -= Data.Instance.gameData.reaper_damage;


        Invoke("offDamage", 0.7f);
    }
    void OnDamageR2()
    {
        damage.text = Data.Instance.gameData.reaper_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_assassin_hp.value -= Data.Instance.gameData.reaper_damage;


        Invoke("offDamage", 0.7f);
    }
    void OnDamageSkillReaper()
    {
        damage.text = Data.Instance.gameData.reaper_skill_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        wk1.gameObject.layer = 17;
        wk2.gameObject.layer = 17;
        wk3.gameObject.layer = 17;
        wk4.gameObject.layer = 17;
        wk5.gameObject.layer = 17;
        wk6.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        ak5.gameObject.layer = 17;
        ak6.gameObject.layer = 17;
        sk9.gameObject.layer = 17; 
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_assassin_hp.value -= Data.Instance.gameData.reaper_skill_damage;


        Invoke("offDamage", 0.75f);
    }
    void offDamage()
    {
        damage.text = null;
        gameObject.layer = 6;
        st1.gameObject.layer = 6;
        st2.gameObject.layer = 6;
        wk1.gameObject.layer = 6;
        wk2.gameObject.layer = 6;
        wk3.gameObject.layer = 6;
        wk4.gameObject.layer = 6;
        wk5.gameObject.layer = 6;
        wk6.gameObject.layer = 6;
        ak1.gameObject.layer = 6;
        ak2.gameObject.layer = 6;
        ak3.gameObject.layer = 6;
        ak4.gameObject.layer = 6;
        ak5.gameObject.layer = 6;
        ak6.gameObject.layer = 6;
        sk9.gameObject.layer = 6;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    //
    public void Assassin_Stand1()
    {
        gameObject.tag = "Assassin";
        st1.enabled = true;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = false;
    }
    public void Assassin_Stand2()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = true;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = false;
    }
    public void Assassin_Walk1()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = true;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = false;
    }
    public void Assassin_Walk2()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = true;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = false;
    }
    public void Assassin_Walk3()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = true;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = false;
    }
    public void Assassin_Walk4()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = true;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = false;
    }
    public void Assassin_Walk5()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = true;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = false;
    }
    public void Assassin_Walk6()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = true;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = false;
    }
    public void Assassin_Atk1()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = true;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = false;
    }
    public void Assassin_Atk2()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = true;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = false;
    }
    public void Assassin_Atk3()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = true;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = false;
    }
    public void Assassin_Atk4()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = true;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = false;
    }
    public void Assassin_Atk5()
    {
        gameObject.tag = "Assassin_Atk";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = true;
        ak6.enabled = false;
        sk9.enabled = false;
    }
    public void Assassin_Atk6()
    {
        gameObject.tag = "Assassin_Atk";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = true;
        sk9.enabled = false;
    }
    public void Assassin_Skill1()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = true;

        skill.Play();
    }
    public void Assassin_Skill2()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = true;
    }
    public void Assassin_Skill3()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = true;
    }
    public void Assassin_Skill4()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = true;
    }
    public void Assassin_Skill5()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = true;
    }
    public void Assassin_Skill6()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = true;
    }
    public void Assassin_Skill7()
    {
        gameObject.tag = "Assassin";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = true;
    }
    public void Assassin_Skill8()
    {
        gameObject.tag = "Assassin_Skill";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = true;
    }
    public void Assassin_Skill9()
    {
        gameObject.tag = "Assassin_Skill";
        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        wk5.enabled = false;
        wk6.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        ak5.enabled = false;
        ak6.enabled = false;
        sk9.enabled = true;
    }

    //
    public void Assassin_Line()
    { 
        Vector2 heading = attack_zone.origin.gameObject.transform.localPosition - gameObject.transform.localPosition;

        if (heading.x < 0)
            heading *= -1;
       
        float angle = Mathf.Atan2(heading.y, heading.x) * Mathf.Rad2Deg;

        sk_ef1.gameObject.transform.eulerAngles = new Vector3(0, 0, angle);
        sk_ef2.gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 45);
        sk_ef3.gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 90);
        sk_ef4.gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 135);
        sk_ef5.gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 180);
        sk_ef6.gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 225);
        sk_ef7.gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 270);
        sk_ef8.gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 315);
        //
        line1.gameObject.transform.eulerAngles = new Vector3(0, 0, angle);
        line2.gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 45);
        line3.gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 90);
        line4.gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 135);
        line5.gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 180);
        line6.gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 225);
        line7.gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 270);
        line8.gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 315);
        
        line1.gameObject.SetActive(true);
        line2.gameObject.SetActive(true);
        line3.gameObject.SetActive(true);
        line4.gameObject.SetActive(true);
        line5.gameObject.SetActive(true);
        line6.gameObject.SetActive(true);
        line7.gameObject.SetActive(true);
        line8.gameObject.SetActive(true);
    }
    //
    public void Assassin_Skill_Effect()
    {
        sk_ef1.gameObject.SetActive(true);
        sk_ef2.gameObject.SetActive(true);
        sk_ef3.gameObject.SetActive(true);
        sk_ef4.gameObject.SetActive(true);
        sk_ef5.gameObject.SetActive(true);
        sk_ef6.gameObject.SetActive(true);
        sk_ef7.gameObject.SetActive(true);
        sk_ef8.gameObject.SetActive(true);

        sk_ef1.SetTrigger("Is_SkillEffect");
        sk_ef2.SetTrigger("Is_SkillEffect");
        sk_ef3.SetTrigger("Is_SkillEffect");
        sk_ef4.SetTrigger("Is_SkillEffect");
        sk_ef5.SetTrigger("Is_SkillEffect");
        sk_ef6.SetTrigger("Is_SkillEffect");
        sk_ef7.SetTrigger("Is_SkillEffect");
        sk_ef8.SetTrigger("Is_SkillEffect");
    }
    //
    public void Dis_Assassin_Skill_Effect()
    {
        line1.gameObject.SetActive(false);
        line2.gameObject.SetActive(false);
        line3.gameObject.SetActive(false);
        line4.gameObject.SetActive(false);
        line5.gameObject.SetActive(false);
        line6.gameObject.SetActive(false);
        line7.gameObject.SetActive(false);
        line8.gameObject.SetActive(false);

        sk_ef1.gameObject.SetActive(false);
        sk_ef2.gameObject.SetActive(false);
        sk_ef3.gameObject.SetActive(false);
        sk_ef4.gameObject.SetActive(false);
        sk_ef5.gameObject.SetActive(false);
        sk_ef6.gameObject.SetActive(false);
        sk_ef7.gameObject.SetActive(false);
        sk_ef8.gameObject.SetActive(false);
    }
    //
    public void Assassin_Atk_Effect()
    {
        ak_ef.gameObject.SetActive(true);
        ak_ef.SetBool("Is_Effect", true);

        attack.Play();
    }

}
