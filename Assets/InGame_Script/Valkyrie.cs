using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Valkyrie : MonoBehaviour
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
    //이펙트애니매이션
    public Animator valkyrie_effect_anima;
    public GameObject valkyrie_Effect;
    public float skillCoolTime = 15f;
    public float skillDelay;
    public float atkCoolTime = 3f;
    public float atkDelay;
    public float lineColor;

    public PolygonCollider2D st1;
    public PolygonCollider2D st2;
    public PolygonCollider2D st3;
    public PolygonCollider2D st4;
    public PolygonCollider2D st5;
    public PolygonCollider2D ak1;
    public PolygonCollider2D ak2;
    public PolygonCollider2D ak3;
    public PolygonCollider2D ak4;
    public PolygonCollider2D sk1;
    public PolygonCollider2D sk2;
    public PolygonCollider2D sk3;
    public PolygonCollider2D sk4;
    public PolygonCollider2D sk5;
    public PolygonCollider2D sk6;
    public PolygonCollider2D sk7;
    public GameObject sk8;
    public GameObject sk9;
    public GameObject sk10;

    public BoxCollider2D sk_ef1;
    public PolygonCollider2D ef1;

    public Slider boss_valkyrie_hp;

    public GameObject damage_label;
    public TextMeshProUGUI damage;
    public GameObject valkyrie_line1;
    
    public GameObject valkyrie_skil1;//스킬 이펙트
    

    public SpriteRenderer line1;

    //어택존
    public FollowCamera attack_zone;
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
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;

        ef1.enabled = false;
        sk_ef1.enabled = false;

        boss_valkyrie_hp.maxValue = Data.Instance.gameData.valkyrie_hp;
        speed = Data.Instance.gameData.valkyrie_speed;
        boss_valkyrie_hp.value = boss_valkyrie_hp.maxValue;

        valkyrie_line1.gameObject.SetActive(false);
        valkyrie_skil1.gameObject.SetActive(false);

        valkyrie_Effect.gameObject.SetActive(false);
        
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

        if (boss_valkyrie_hp.value == 0)
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

        if (Vector2.Distance(attack_zone.valkyrie_attack_zone_left.position, gameObject.transform.position) <= 3f ||
             Vector2.Distance(attack_zone.valkyrie_attack_zone_right.position, gameObject.transform.position) <= 3f)
        {
            if (atkDelay >= 0)
                atkDelay -= Time.deltaTime;
        }
        lineColor += Time.deltaTime;

        if (valkyrie_line1.gameObject.activeSelf == true)
            line1.color = new Color(1, 1, 1, lineColor / 3f);
        else
        {
            lineColor = 0;
            line1.color = new Color(1, 1, 1, 0);
        }
        


        if (sk_ef1.gameObject.activeSelf == true)
            sk_ef1.transform.Translate(Vector3.left * Time.deltaTime * 50f);
        else
        {
            sk_ef1.transform.localPosition = new Vector3(0, 0, 0);
        }

        if (gameObject.transform.position.x - attack_zone.origin.gameObject.transform.position.x > 0)
        {
            transform.localScale = new Vector3(10f, 10f, 1f);
            damage_label.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            ef1.gameObject.transform.position = new Vector3(gameObject.transform.position.x - 3f, gameObject.transform.position.y, 0f);
            if (ef1.enabled == true)
                valkyrie_Effect.gameObject.transform.position = new Vector3(gameObject.transform.position.x - 3f, gameObject.transform.position.y, 0f);
        }
        else
        {
            transform.localScale = new Vector3(-10f, 10f, 1f);
            damage_label.gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
            ef1.gameObject.transform.position = new Vector3(gameObject.transform.position.x + 3f, gameObject.transform.position.y, 0f);
            if (ef1.enabled == true)
                valkyrie_Effect.gameObject.transform.position = new Vector3(gameObject.transform.position.x + 3f, gameObject.transform.position.y, 0f);
        }
    }
    private void LateUpdate()
    {
        if (ef1.enabled == false)
            valkyrie_Effect.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);


        boss_valkyrie_hp.transform.position = transform.position + new Vector3(0, 4f, 0f);
        damage_label.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //발키리 몸에 부딪혔을때
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Valkyrie")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Body_Valkyrie();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Skeleton" && gameObject.tag == "Valkyrie")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Body_Valkyrie_Skeleton();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Golem" && gameObject.tag == "Valkyrie")
        {
            hit.Play();
            if (golem_obj.skillEffect.activeSelf == false && attack_zone.gm.shield_cnt < 1)
                Body_Valkyrie_Golem();
            else if (attack_zone.gm.shield_cnt >= 1 && golem_obj.skillEffect.activeSelf == false)
            {
                attack_zone.gm.shield_cnt--;
            }
            if (golem_obj.skillEffect.activeSelf == true)
                Shield_Golem();

        }
        if (collision.gameObject.tag == "Slime" && gameObject.tag == "Valkyrie")
        {
            hit.Play();
            if (slime_obj.sk1.enabled == false && attack_zone.gm.shield_cnt < 1)
                Body_Valkyrie_Slime();
            else if (attack_zone.gm.shield_cnt >= 1)
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Reaper" && gameObject.tag == "Valkyrie")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Body_Valkyrie_Reaper();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        //공격

        if (collision.gameObject.tag == "Player" && gameObject.tag == "Valkyrie_Atk")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Attack_Valkyrie();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Skeleton" && gameObject.tag == "Valkyrie_Atk")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Attack_Valkyrie_Skeleton();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Golem" && gameObject.tag == "Valkyrie_Atk")
        {
            hit.Play();
            if (golem_obj.skillEffect.activeSelf == false && attack_zone.gm.shield_cnt < 1)
                Attack_Valkyrie_Golem();
            else if (attack_zone.gm.shield_cnt >= 1 && golem_obj.skillEffect.activeSelf == false)
            {
                attack_zone.gm.shield_cnt--;
            }
            if (golem_obj.skillEffect.activeSelf == true)
                Shield_Golem();

        }
        if (collision.gameObject.tag == "Slime" && gameObject.tag == "Valkyrie_Atk")
        {
            hit.Play();
            if (slime_obj.sk1.enabled == false && attack_zone.gm.shield_cnt < 1)
                Attack_Valkyrie_Slime();
            else if (attack_zone.gm.shield_cnt >= 1)
            {
                attack_zone.gm.shield_cnt--;
            };
        }
        if (collision.gameObject.tag == "Reaper" && gameObject.tag == "Valkyrie_Atk")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Attack_Valkyrie_Reaper();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }

        //스킬
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Valkyrie_Skill")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Skill_Valkyrie();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Skeleton" && gameObject.tag == "Valkyrie_Skill")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Skill_Valkyrie_Skeleton();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Golem" && gameObject.tag == "Valkyrie_Skill")
        {
            hit.Play();
            if (golem_obj.skillEffect.activeSelf == false && attack_zone.gm.shield_cnt < 1)
                Skill_Valkyrie_Golem();
            else if (attack_zone.gm.shield_cnt >= 1 && golem_obj.skillEffect.activeSelf == false)
            {
                attack_zone.gm.shield_cnt--;
            }
            if (golem_obj.skillEffect.activeSelf == true)
                Shield_Golem();
        }
        if (collision.gameObject.tag == "Slime" && gameObject.tag == "Valkyrie_Skill")
        {
            hit.Play();
            if (slime_obj.sk1.enabled == false && attack_zone.gm.shield_cnt < 1)
                Skill_Valkyrie_Slime();
            else if (attack_zone.gm.shield_cnt >= 1)
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Reaper" && gameObject.tag == "Valkyrie_Skill")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Skill_Valkyrie_Reaper();
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
    void Body_Valkyrie()
    {
        wolf_obj.damage_label.text = Data.Instance.gameData.valkyrie_body_damage.ToString();
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
        wolf_obj.wolf_hp -= Data.Instance.gameData.valkyrie_body_damage;
        Invoke("offBack", 0.2f);
        Invoke("offDamaged", 1.2f);
    }
    void Body_Valkyrie_Skeleton()
    {
        skeleton_obj.damage_label.text = Data.Instance.gameData.valkyrie_body_damage.ToString();
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
        skeleton_obj.skeleton_hp -= Data.Instance.gameData.valkyrie_body_damage;
        Invoke("offBackSkeleton", 0.2f);
        Invoke("offDamageSkeleton", 1.2f);
    }
    void Body_Valkyrie_Golem()
    {
        golem_obj.damage_label.text = Data.Instance.gameData.valkyrie_body_damage.ToString();
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
        golem_obj.golem_hp -= Data.Instance.gameData.valkyrie_body_damage;
        Invoke("offBackGolem", 0.2f);
        Invoke("offDamageGolem", 1.2f);
    }
    //슬라임한테 공격할때
    void Body_Valkyrie_Slime()
    {
        slime_obj.damage_label.text = Data.Instance.gameData.valkyrie_body_damage.ToString();
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
        slime_obj.slime_hp -= Data.Instance.gameData.valkyrie_body_damage;
        Invoke("offBackSlime", 0.2f);
        Invoke("offDamageSlime", 1.2f);
    }
    //사신
    void Body_Valkyrie_Reaper()
    {
        reaper_obj.damage_label.text = Data.Instance.gameData.valkyrie_body_damage.ToString();
        reaper_obj.reaper_hp -= Data.Instance.gameData.valkyrie_body_damage;
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
    void Attack_Valkyrie()
    {
        wolf_obj.damage_label.text = Data.Instance.gameData.valkyrie_damage.ToString();
        wolf_obj.wolf_hp -= Data.Instance.gameData.valkyrie_damage;
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
    void Attack_Valkyrie_Skeleton()
    {
        skeleton_obj.damage_label.text = Data.Instance.gameData.valkyrie_damage.ToString();
        skeleton_obj.skeleton_hp -= Data.Instance.gameData.valkyrie_damage;
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

    void Attack_Valkyrie_Golem()
    {
        golem_obj.damage_label.text = Data.Instance.gameData.valkyrie_damage.ToString();
        golem_obj.golem_hp -= Data.Instance.gameData.valkyrie_damage;
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
    void Shield_Golem()
    {

    }
    //슬라임한테 공격할때
    void Attack_Valkyrie_Slime()
    {
        slime_obj.damage_label.text = Data.Instance.gameData.valkyrie_damage.ToString();
        slime_obj.slime_hp -= Data.Instance.gameData.valkyrie_damage;
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
    void Attack_Valkyrie_Reaper()
    {
        reaper_obj.damage_label.text = Data.Instance.gameData.valkyrie_damage.ToString();
        reaper_obj.reaper_hp -= Data.Instance.gameData.valkyrie_damage;
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
    void Skill_Valkyrie()
    {
        wolf_obj.damage_label.text = Data.Instance.gameData.valkyrie_skill_damage.ToString();
        wolf_obj.wolf_hp -= Data.Instance.gameData.valkyrie_skill_damage;
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
    void Skill_Valkyrie_Skeleton()
    {
        skeleton_obj.damage_label.text = Data.Instance.gameData.valkyrie_skill_damage.ToString();
        skeleton_obj.skeleton_hp -= Data.Instance.gameData.valkyrie_skill_damage;
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
    void Skill_Valkyrie_Golem()
    {
        golem_obj.damage_label.text = Data.Instance.gameData.valkyrie_skill_damage.ToString();
        golem_obj.golem_hp -= Data.Instance.gameData.valkyrie_skill_damage;
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
    //슬라임한테 공격할때
    void Skill_Valkyrie_Slime()
    {
        slime_obj.damage_label.text = Data.Instance.gameData.valkyrie_skill_damage.ToString();
        slime_obj.slime_hp -= Data.Instance.gameData.valkyrie_skill_damage;
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
    //사신
    void Skill_Valkyrie_Reaper()
    {
        reaper_obj.damage_label.text = Data.Instance.gameData.valkyrie_skill_damage.ToString();
        reaper_obj.reaper_hp -= Data.Instance.gameData.valkyrie_skill_damage;
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
    void OnDamageLightning()
    {
        damage.text = 10.ToString();

        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;

        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_valkyrie_hp.value -= 10;


        Invoke("offDamage", 0.75f);
    }
    void OnDamageArrow()
    {
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;

        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        if (Data.Instance.gameData.arrowlv == 1)
        {
            boss_valkyrie_hp.value -= 4;
            damage.text = 4.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 2)
        {
            boss_valkyrie_hp.value -= 5;
            damage.text = 5.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 3)
        {
            boss_valkyrie_hp.value -= 6;
            damage.text = 6.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 4)
        {
            boss_valkyrie_hp.value -= 7;
            damage.text = 7.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 5)
        {
            boss_valkyrie_hp.value -= 8;
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
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;

        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.wolf_damage;


        Invoke("offDamage", 0.75f);
    }
    void OnDamageW2()
    {
        damage.text = Data.Instance.gameData.wolf_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;

        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.wolf_damage;


        Invoke("offDamage", 0.75f);
    }
    void OnDamageW3()
    {
        damage.text = Data.Instance.gameData.wolf_last_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;

        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.wolf_last_damage;


        Invoke("offDamage", 0.75f);
    }
    void OnDamageSkillWolf()
    {
        damage.text = Data.Instance.gameData.wolf_skill_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;

        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.wolf_skill_damage;


        Invoke("offDamage", 0.5f);
    }
    //스켈레톤한테 공격받았을 때
    void OnDamageS1()
    {
        damage.text = Data.Instance.gameData.skeleton_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;

        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.skeleton_damage;


        Invoke("offDamage", 1f);
    }
    void OnDamageS2()
    {
        damage.text = Data.Instance.gameData.skeleton_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;

        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.skeleton_damage;


        Invoke("offDamage", 1f);
    }
    void OnDamageS3()
    {
        damage.text = Data.Instance.gameData.skeleton_last_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;

        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.skeleton_last_damage;


        Invoke("offDamage", 1f);
    }
    void OnDamageSkillS()
    {
        damage.text = Data.Instance.gameData.skeleton_skill_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;

        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.skeleton_skill_damage;


        Invoke("offDamage", 0.6f);
    }
    //골렘한테 맞았을때
    void OnDamageG1()
    {
        damage.text = Data.Instance.gameData.golem_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.golem_damage;


        Invoke("offDamage", 0.75f);
    }
    void OnDamageG2()
    {
        damage.text = Data.Instance.gameData.golem_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.golem_damage;

        Invoke("offDamage", 0.75f);
    }
    void OnDamageG3()
    {
        damage.text = Data.Instance.gameData.goelm_last_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.goelm_last_damage;


        Invoke("offDamage", 0.75f);
    }
    void OnDamageSlime()
    {
        damage.text = Data.Instance.gameData.slime_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.slime_damage;


        Invoke("offDamage", 0.5f);
    }
    void OnDamageSkillSlime()
    {
        damage.text = Data.Instance.gameData.sllime_skill_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.sllime_skill_damage;


        Invoke("offDamage", 1.5f);
    }
    void OnDamageR1()
    {
        damage.text = Data.Instance.gameData.reaper_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.reaper_damage;


        Invoke("offDamage", 0.7f);
    }
    void OnDamageR2()
    {
        damage.text = Data.Instance.gameData.reaper_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.reaper_damage;


        Invoke("offDamage", 0.7f);
    }
    void OnDamageSkillReaper()
    {
        damage.text = Data.Instance.gameData.reaper_skill_damage.ToString();
        gameObject.layer = 17;
        st1.gameObject.layer = 17;
        st2.gameObject.layer = 17;
        st3.gameObject.layer = 17;
        st4.gameObject.layer = 17;
        st5.gameObject.layer = 17;
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        ak4.gameObject.layer = 17;
        sk1.gameObject.layer = 17;
        sk2.gameObject.layer = 17;
        sk3.gameObject.layer = 17;
        sk4.gameObject.layer = 17;
        sk5.gameObject.layer = 17;
        sk6.gameObject.layer = 17;
        sk7.gameObject.layer = 17;
        sk8.gameObject.layer = 17;
        sk9.gameObject.layer = 17;
        sk10.gameObject.layer = 17;
        spriteRenderer.color = new Color(1, 1, 1, 0.8f);

        boss_valkyrie_hp.value -= Data.Instance.gameData.reaper_skill_damage;


        Invoke("offDamage", 0.75f);
    }
    void offDamage()
    {
        damage.text = null;
        gameObject.layer = 6;
        st1.gameObject.layer = 6;
        st2.gameObject.layer = 6;
        st3.gameObject.layer = 6;
        st4.gameObject.layer = 6;
        st5.gameObject.layer = 6;
        ak1.gameObject.layer = 6;
        ak2.gameObject.layer = 6;
        ak3.gameObject.layer = 6;
        ak4.gameObject.layer = 6;
        sk1.gameObject.layer = 6;
        sk2.gameObject.layer = 6;
        sk3.gameObject.layer = 6;
        sk4.gameObject.layer = 6;
        sk5.gameObject.layer = 6;
        sk6.gameObject.layer = 6;
        sk7.gameObject.layer = 6;
        sk8.gameObject.layer = 6;
        sk9.gameObject.layer = 6;
        sk10.gameObject.layer = 6;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    //워리어 보스 애니메이션에 따른 콜라이더
    public void Valkyrie_Stand1()
    {
        gameObject.tag = "Valkyrie";
        st1.enabled = true;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;
    }
    public void Valkyrie_Stand2()
    {
        gameObject.tag = "Valkyrie";
        st1.enabled = false;
        st2.enabled = true;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;
    }
    public void Valkyrie_Stand3()
    {
        gameObject.tag = "Valkyrie";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = true;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;
    }
    public void Valkyrie_Stand4()
    {
        gameObject.tag = "Valkyrie";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = true;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;
    }
    public void Valkyrie_Stand5()
    {
        gameObject.tag = "Valkyrie";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = true;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;
    }
    public void Valkyrie_Atk1()
    {
        gameObject.tag = "Valkyrie";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = true;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;
    }
    public void Valkyrie_Atk2()
    {
        gameObject.tag = "Valkyrie_Atk";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = true;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;
    }
    public void Valkyrie_Atk3()
    {
        gameObject.tag = "Valkyrie_Atk";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = true;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;
    }
    public void Valkyrie_Atk4()
    {
        gameObject.tag = "Valkyrie_Atk";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = true;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;


        valkyrie_effect_anima.SetBool("Is_Effect", false);
    }
    public void Valkyrie_Sk1()
    {
        gameObject.tag = "Valkyrie";
        valkyrie_effect_anima.SetBool("Is_Charging", true);

        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = true;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;

        skill.Play();
    }
    public void Valkyrie_Sk2()
    {
        gameObject.tag = "Valkyrie";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = true;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;
    }
    public void Valkyrie_Sk3()
    {
        gameObject.tag = "Valkyrie";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = true;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;
    }
    public void Valkyrie_Sk4()
    {
        gameObject.tag = "Valkyrie";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = true;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;
    }
    public void Valkyrie_Sk5()
    {
        gameObject.tag = "Valkyrie";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = true;
        sk6.enabled = false;
        sk7.enabled = false;
    }
    public void Valkyrie_Sk6()
    {
        gameObject.tag = "Valkyrie";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = true;
        sk7.enabled = false;
    }
    public void Valkyrie_Sk7()
    {
        gameObject.tag = "Valkyrie";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = true;
    }
    public void Valkyrie_Sk8()
    {
        gameObject.tag = "Valkyrie";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = true;
    }
    public void Valkyrie_Sk9()
    {
        gameObject.tag = "Valkyrie_Skill";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = true;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = false;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;

        valkyrie_line1.gameObject.SetActive(false);
        
    }
    public void Valkyrie_Sk10()
    {
        gameObject.tag = "Valkyrie_Skill";
        st1.enabled = false;
        st2.enabled = false;
        st3.enabled = false;
        st4.enabled = false;
        st5.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
        ak4.enabled = false;
        sk1.enabled = false;
        sk2.enabled = false;
        sk3.enabled = false;
        sk4.enabled = true;
        sk5.enabled = false;
        sk6.enabled = false;
        sk7.enabled = false;
    }

    public void Valkyrie_Line()
    {
        Vector2 heading = attack_zone.origin.gameObject.transform.localPosition - gameObject.transform.localPosition;
        
        if (heading.x < 0)
            heading *= -1;
        
        float angle = Mathf.Atan2(heading.y, heading.x) * Mathf.Rad2Deg;

        valkyrie_skil1.gameObject.transform.eulerAngles = new Vector3(0, 0, angle);
        valkyrie_line1.gameObject.transform.eulerAngles = new Vector3(0, 0, angle);

        valkyrie_line1.gameObject.SetActive(true);
       
    }
    public void Valkyrie_Skill_Effect()
    {
        Invoke("Dis_Valkyrie_Skill_Effect", 2f);
        valkyrie_skil1.gameObject.SetActive(true);
        sk_ef1.enabled = true;
        
    }

    public void Dis_Valkyrie_Skill_Effect()
    {
        valkyrie_skil1.gameObject.SetActive(false);
    }


    public void Valkyrie_Atk_Effect()
    {

        ef1.enabled = true;
        valkyrie_effect_anima.SetBool("Is_Effect", true);

        attack.Play();
    }
}
