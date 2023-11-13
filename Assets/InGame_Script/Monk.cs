using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Monk : MonoBehaviour
{
    public AudioSource attack;//공격
    public AudioSource hit;//피격

    public SpriteRenderer spriteRenderer;

    public float speed;
    public float atkCoolTime = 2.5f;
    public float atkDelay;

    public Character player_position;//울프플레이어 위치
    public Skeleton skeleton;//스켈레톤 플레이어
    public Golem golem;//골렘 플레이어
    public Slime_In slime;//슬라임 플레이어
    public Reaper reaper;//사신 플레이어

    public CapsuleCollider2D st1;
    public CapsuleCollider2D st2;
    public CapsuleCollider2D wk1;
    public CapsuleCollider2D wk2;
    public CapsuleCollider2D wk3;
    public CapsuleCollider2D wk4;
    public CapsuleCollider2D ak1;
    public CapsuleCollider2D ak2;
    public CapsuleCollider2D ak3;

    public PolygonCollider2D ef1;

    public int vampire_percent;
    //hp바
    public Slider monk_hp;

    public GameObject damage_label;
    public TextMeshProUGUI damage;
    //이펙트 위치
    public GameObject monk_effect_Pos;
    //애니매이션
    public Animator monk_effect_anima;
    //어택존
    public FollowCamera attack_zone;
    private void Awake()
    {
        player_position = GameObject.Find("Unit").transform.Find("Player").GetComponent<Character>();
        skeleton = GameObject.Find("Unit").transform.Find("Player_Skeleton").GetComponent<Skeleton>();
        attack_zone = GameObject.Find("Main Camera").GetComponent<FollowCamera>();
        golem = GameObject.Find("Unit").transform.Find("Golem").GetComponent<Golem>();
        slime = GameObject.Find("Unit").transform.Find("Slime").GetComponent<Slime_In>();
        reaper = GameObject.Find("Unit").transform.Find("Reaper").GetComponent<Reaper>();
    }
    void Start()
    {
        damage.text = null;
        monk_hp.maxValue = Data.Instance.gameData.monk_hp;
        speed = Data.Instance.gameData.monk_speed;
        monk_hp.value = monk_hp.maxValue;

        atkDelay = 2.5f;

        st1.enabled = true;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;

        ef1.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Data.Instance.gameData.sound == false)
        {
            attack.gameObject.GetComponent<AudioSource>().enabled = false;
            hit.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else if (Data.Instance.gameData.sound == true)
        {
            attack.gameObject.GetComponent<AudioSource>().enabled = true;
            hit.gameObject.GetComponent<AudioSource>().enabled = true;
        }

        if (monk_hp.value == 0)
        {
            if (Data.Instance.gameData.vampirelv > 0)
            {
                vampire_percent = Random.Range(1, 11);
                if (vampire_percent <= 3)
                {
                    attack_zone.vampire.gameObject.SetActive(true);
                    if (Data.Instance.gameData.vampirelv == 1)
                    {
                        if (player_position.wolf_hp < Data.Instance.gameData.wolf_hp)
                            player_position.wolf_hp++;
                        else if (skeleton.skeleton_hp < Data.Instance.gameData.skeleton_hp)
                            skeleton.skeleton_hp++;
                        else if (slime.slime_hp < Data.Instance.gameData.slime_hp)
                            slime.slime_hp++;
                        else if (golem.golem_hp < Data.Instance.gameData.golem_hp)
                            golem.golem_hp++;
                        else if (reaper.reaper_hp < Data.Instance.gameData.reaper_hp)
                            reaper.reaper_hp++;
                    }
                    else if (Data.Instance.gameData.vampirelv == 2)
                    {

                        if (player_position.wolf_hp + 1 == Data.Instance.gameData.wolf_hp)
                            player_position.wolf_hp += 1;
                        else if (player_position.wolf_hp + 2 <= Data.Instance.gameData.wolf_hp)
                            player_position.wolf_hp += 2;

                        if (skeleton.skeleton_hp + 1 == Data.Instance.gameData.skeleton_hp)
                            skeleton.skeleton_hp += 1;
                        else if (skeleton.skeleton_hp + 2 <= Data.Instance.gameData.skeleton_hp)
                            skeleton.skeleton_hp += 2;


                        if (slime.slime_hp + 1 == Data.Instance.gameData.slime_hp)
                            slime.slime_hp += 1;
                        else if (slime.slime_hp + 2 <= Data.Instance.gameData.slime_hp)
                            slime.slime_hp += 2;

                        if (golem.golem_hp + 1 == Data.Instance.gameData.golem_hp)
                            golem.golem_hp += 1;
                        else if (golem.golem_hp + 2 <= Data.Instance.gameData.golem_hp)
                            golem.golem_hp += 2;

                        if (reaper.reaper_hp + 1 == Data.Instance.gameData.reaper_hp)
                            reaper.reaper_hp += 1;
                        else if (reaper.reaper_hp + 2 <= Data.Instance.gameData.reaper_hp)
                            reaper.reaper_hp += 2;
                    }
                    else if (Data.Instance.gameData.vampirelv == 3)
                    {
                        if (player_position.wolf_hp + 1 == Data.Instance.gameData.wolf_hp)
                            player_position.wolf_hp += 1;
                        else if (player_position.wolf_hp + 2 == Data.Instance.gameData.wolf_hp)
                            player_position.wolf_hp += 2;
                        else if (player_position.wolf_hp + 3 <= Data.Instance.gameData.wolf_hp)
                            player_position.wolf_hp += 3;

                        if (skeleton.skeleton_hp + 1 == Data.Instance.gameData.skeleton_hp)
                            skeleton.skeleton_hp += 1;
                        else if (skeleton.skeleton_hp + 2 == Data.Instance.gameData.skeleton_hp)
                            skeleton.skeleton_hp += 2;
                        else if (skeleton.skeleton_hp + 3 <= Data.Instance.gameData.skeleton_hp)
                            skeleton.skeleton_hp += 3;

                        if (slime.slime_hp + 1 == Data.Instance.gameData.slime_hp)
                            slime.slime_hp += 1;
                        else if (slime.slime_hp + 2 == Data.Instance.gameData.slime_hp)
                            slime.slime_hp += 2;
                        else if (slime.slime_hp + 3 <= Data.Instance.gameData.slime_hp)
                            slime.slime_hp += 3;

                        if (golem.golem_hp + 1 == Data.Instance.gameData.golem_hp)
                            golem.golem_hp += 1;
                        else if (golem.golem_hp + 2 == Data.Instance.gameData.golem_hp)
                            golem.golem_hp += 2;
                        else if (golem.golem_hp + 3 <= Data.Instance.gameData.golem_hp)
                            golem.golem_hp += 3;

                        if (reaper.reaper_hp + 1 == Data.Instance.gameData.reaper_hp)
                            reaper.reaper_hp += 1;
                        else if (reaper.reaper_hp + 2 == Data.Instance.gameData.reaper_hp)
                            reaper.reaper_hp += 2;
                        else if (reaper.reaper_hp + 3 <= Data.Instance.gameData.reaper_hp)
                            reaper.reaper_hp += 3;
                    }
                    else if (Data.Instance.gameData.vampirelv == 4)
                    {
                        if (player_position.wolf_hp + 1 == Data.Instance.gameData.wolf_hp)
                            player_position.wolf_hp += 1;
                        else if (player_position.wolf_hp + 2 == Data.Instance.gameData.wolf_hp)
                            player_position.wolf_hp += 2;
                        else if (player_position.wolf_hp + 3 == Data.Instance.gameData.wolf_hp)
                            player_position.wolf_hp += 3;
                        else if (player_position.wolf_hp + 4 <= Data.Instance.gameData.wolf_hp)
                            player_position.wolf_hp += 4;

                        if (skeleton.skeleton_hp + 1 == Data.Instance.gameData.skeleton_hp)
                            skeleton.skeleton_hp += 1;
                        else if (skeleton.skeleton_hp + 2 == Data.Instance.gameData.skeleton_hp)
                            skeleton.skeleton_hp += 2;
                        else if (skeleton.skeleton_hp + 3 == Data.Instance.gameData.skeleton_hp)
                            skeleton.skeleton_hp += 3;
                        else if (skeleton.skeleton_hp + 4 <= Data.Instance.gameData.skeleton_hp)
                            skeleton.skeleton_hp += 4;

                        if (slime.slime_hp + 1 == Data.Instance.gameData.slime_hp)
                            slime.slime_hp += 1;
                        else if (slime.slime_hp + 2 == Data.Instance.gameData.slime_hp)
                            slime.slime_hp += 2;
                        else if (slime.slime_hp + 3 == Data.Instance.gameData.slime_hp)
                            slime.slime_hp += 3;
                        else if (slime.slime_hp + 4 <= Data.Instance.gameData.slime_hp)
                            slime.slime_hp += 4;


                        if (golem.golem_hp + 1 == Data.Instance.gameData.golem_hp)
                            golem.golem_hp += 1;
                        else if (golem.golem_hp + 2 == Data.Instance.gameData.golem_hp)
                            golem.golem_hp += 2;
                        else if (golem.golem_hp + 3 == Data.Instance.gameData.golem_hp)
                            golem.golem_hp += 3;
                        else if (golem.golem_hp + 4 <= Data.Instance.gameData.golem_hp)
                            golem.golem_hp += 4;

                        if (reaper.reaper_hp + 1 == Data.Instance.gameData.reaper_hp)
                            reaper.reaper_hp += 1;
                        else if (reaper.reaper_hp + 2 == Data.Instance.gameData.reaper_hp)
                            reaper.reaper_hp += 2;
                        else if (reaper.reaper_hp + 3 == Data.Instance.gameData.reaper_hp)
                            reaper.reaper_hp += 3;
                        else if (reaper.reaper_hp + 4 <= Data.Instance.gameData.reaper_hp)
                            reaper.reaper_hp += 4;
                    }
                    else if (Data.Instance.gameData.vampirelv == 5)
                    {
                        if (player_position.wolf_hp + 1 == Data.Instance.gameData.wolf_hp)
                            player_position.wolf_hp += 1;
                        else if (player_position.wolf_hp + 2 == Data.Instance.gameData.wolf_hp)
                            player_position.wolf_hp += 2;
                        else if (player_position.wolf_hp + 3 == Data.Instance.gameData.wolf_hp)
                            player_position.wolf_hp += 3;
                        else if (player_position.wolf_hp + 4 == Data.Instance.gameData.wolf_hp)
                            player_position.wolf_hp += 4;
                        else if (player_position.wolf_hp + 5 <= Data.Instance.gameData.wolf_hp)
                            player_position.wolf_hp += 5;


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
            }
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
            attack_zone.score += 4;
            if (attack_zone.death_cnt > 0)
                attack_zone.death_cnt--;
            Destroy(gameObject);
        }
        if (monk_hp.value == monk_hp.maxValue)
            monk_hp.gameObject.SetActive(false);
        else
            monk_hp.gameObject.SetActive(true);

        if (Vector2.Distance(attack_zone.mob_attack_zone_left.position, gameObject.transform.position) <= 1.5f ||
             Vector2.Distance(attack_zone.mob_attack_zone_right.position, gameObject.transform.position) <= 1.5f)
        {
            if (atkDelay >= 0)
                atkDelay -= Time.deltaTime;
        }

        monk_hp.transform.position = gameObject.transform.localPosition + new Vector3(0f, 1f, 0f);
        //위치 및 크기
        if (gameObject.transform.position.x - attack_zone.origin.transform.position.x > 0)
        {
            transform.localScale = new Vector3(3f, 3f, 1f);
            monk_effect_Pos.gameObject.transform.position = new Vector3(gameObject.transform.position.x - 2f, gameObject.transform.position.y + 0.1f, 0f);
            ef1.gameObject.transform.position = new Vector3(gameObject.transform.position.x - 2f, gameObject.transform.position.y + 0.1f, 0f);
            damage_label.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-3f, 3f, 1f);
            monk_effect_Pos.gameObject.transform.position = new Vector3(gameObject.transform.position.x + 2f, gameObject.transform.position.y + 0.1f, 0f);
            ef1.gameObject.transform.position = new Vector3(gameObject.transform.position.x + 2f, gameObject.transform.position.y + 0.1f, 0f);
            damage_label.gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }


        damage_label.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2f);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //뭉크가 공격했을 때
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Monk")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Attack_Monk_Wolf();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Skeleton" && gameObject.tag == "Monk")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Attack_Monk_Skeleton();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Golem" && gameObject.tag == "Monk")
        {
            hit.Play();
            if (golem.skillEffect.activeSelf == false && attack_zone.gm.shield_cnt < 1)
                Attack_Monk_Golem();
            else if (attack_zone.gm.shield_cnt >= 1 && golem.skillEffect.activeSelf == false)
            {
                attack_zone.gm.shield_cnt--;
            }
            if (golem.skillEffect.activeSelf == true)
                Shield_Golem();
        }
        if (collision.gameObject.tag == "Slime" && gameObject.tag == "Monk")
        {
            hit.Play();
            if (slime.sk1.enabled == false && attack_zone.gm.shield_cnt < 1)
                Attack_Monk_Slime();
            else if (attack_zone.gm.shield_cnt >= 1)
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Reaper" && gameObject.tag == "Monk")
        {
            hit.Play();
            if (attack_zone.gm.shield_cnt < 1)
                Attack_Monk_Reaper();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        //울프한테 맞았을때
        if (collision.gameObject.tag == "PlayerEffect_W1" || collision.gameObject.tag == "PlayerEffect_W2")
        {
            hit.Play();
            OnDamageW1();
        }
        else if (collision.gameObject.tag == "PlayerEffect_W3")
        {
            hit.Play();
            OnDamageW3();
        }
        if (collision.gameObject.tag == "PlayerSkillEffect_Wolf")
        {
            hit.Play();
            OnDamageSkillWolf();
        }
        //스켈레톤한테 맞았을때
        else if (collision.gameObject.tag == "PlayerEffect_S1" || collision.gameObject.tag == "PlayerEffect_S2")
        {
            hit.Play();
            OnDamageS1();
        }
        else if (collision.gameObject.tag == "PlayerEffect_S3")
        {
            hit.Play();
            OnDamageS3();
        }
        //스켈레톤 스킬에 맞았을 때
        else if (collision.gameObject.tag == "PlayerSkillEffect_S")
        {
            hit.Play();
            OnDamageSkillS();
        }
        //골렘한테 맞았을때
        else if (collision.gameObject.tag == "PlayerEffect_G1" || collision.gameObject.tag == "PlayerEffect_G2")
        {
            hit.Play();
            OnDamageG1();
        }
        else if (collision.gameObject.tag == "PlayerEffect_G3")
        {
            hit.Play();
            OnDamageG3();
        }
        //슬라임한테 맞았을ㄸ
        else if (collision.gameObject.tag == "PlayerEffect_Slime")
        {
            hit.Play();
            OnDamageSlime();
        }
        //슬라임 스킬에 맞았을 때
        else if (collision.gameObject.tag == "PlayerSkillEffect_Slime")
        {
            hit.Play();
            OnDamageSkillSlime();
        }
        //사신한테 맞았을때
        else if (collision.gameObject.tag == "PlayerEffect_R1")
        {
            hit.Play();
            OnDamageR1();
        }
        else if (collision.gameObject.tag == "PlayerEffect_R2")
        {
            hit.Play();
            OnDamageR2();
        }
        //사신 스킬에 맞았을 때
        else if (collision.gameObject.tag == "PlayerSkillEffect_Reaper")
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

    //낙뢰데미지
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
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        monk_hp.value -= 10;

        Invoke("offDamaged", 0.75f);

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
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        if (Data.Instance.gameData.arrowlv == 1)
        {
            monk_hp.value -= 4;
            damage.text = 4.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 2)
        {
            monk_hp.value -= 5;
            damage.text = 5.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 3)
        {
            monk_hp.value -= 6;
            damage.text = 6.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 4)
        {
            monk_hp.value -= 7;
            damage.text = 7.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 5)
        {
            monk_hp.value -= 8;
            damage.text = 8.ToString();
        }

        Invoke("offDamaged", 0.75f);
    }
    void Attack_Monk_Wolf()
    {
        player_position.damage_label.text = Data.Instance.gameData.monk_damage.ToString();
        player_position.wolf_hp -= Data.Instance.gameData.monk_damage;
        player_position.gameObject.layer = 8;
        player_position.st1.gameObject.layer = 8;
        player_position.st2.gameObject.layer = 8;
        player_position.wk1.gameObject.layer = 8;
        player_position.wk2.gameObject.layer = 8;
        player_position.ak1_1.gameObject.layer = 8;
        player_position.ak1_2.gameObject.layer = 8;
        player_position.ak1_3.gameObject.layer = 8;
        player_position.ak2_1.gameObject.layer = 8;
        player_position.ak2_2.gameObject.layer = 8;
        player_position.ak2_3.gameObject.layer = 8;
        player_position.ak3_1.gameObject.layer = 8;
        player_position.ak3_2.gameObject.layer = 8;
        player_position.ak3_3.gameObject.layer = 8;

        player_position.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = player_position.transform.position.x - transform.position.x > 0 ? 1 : -1;
        player_position.rigid.AddForce(new Vector2(dirc, 0f) * 15f, ForceMode2D.Impulse);

        Invoke("offBack", 0.2f);
        Invoke("offDamage", 1.2f);
    }
    void offBack()
    {
        player_position.rigid.velocity = Vector3.zero;
    }
    void offDamage()
    {
        player_position.damage_label.text = null;
        player_position.gameObject.layer = 7;
        player_position.st1.gameObject.layer = 7;
        player_position.st2.gameObject.layer = 7;
        player_position.wk1.gameObject.layer = 7;
        player_position.wk2.gameObject.layer = 7;
        player_position.ak1_1.gameObject.layer = 7;
        player_position.ak1_2.gameObject.layer = 7;
        player_position.ak1_3.gameObject.layer = 7;
        player_position.ak2_1.gameObject.layer = 7;
        player_position.ak2_2.gameObject.layer = 7;
        player_position.ak2_3.gameObject.layer = 7;
        player_position.ak3_1.gameObject.layer = 7;
        player_position.ak3_2.gameObject.layer = 7;
        player_position.ak3_3.gameObject.layer = 7;
        player_position.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void Attack_Monk_Skeleton()
    {
        skeleton.damage_label.text = Data.Instance.gameData.monk_damage.ToString();
        skeleton.skeleton_hp -= Data.Instance.gameData.monk_damage;
        skeleton.gameObject.layer = 8;
        skeleton.st1.gameObject.layer = 8;
        skeleton.st2.gameObject.layer = 8;
        skeleton.wk1.gameObject.layer = 8;
        skeleton.wk2.gameObject.layer = 8;
        skeleton.wk3.gameObject.layer = 8;
        skeleton.wk4.gameObject.layer = 8;
        skeleton.ak1_1.gameObject.layer = 8;
        skeleton.ak1_2.gameObject.layer = 8;
        skeleton.ak1_3.gameObject.layer = 8;
        skeleton.ak2_1.gameObject.layer = 8;
        skeleton.ak2_2.gameObject.layer = 8;
        skeleton.ak2_3.gameObject.layer = 8;
        skeleton.ak3_1.gameObject.layer = 8;
        skeleton.ak3_2.gameObject.layer = 8;
        skeleton.ak3_3.gameObject.layer = 8;
        skeleton.ak3_4.gameObject.layer = 8;
        skeleton.ak3_5.gameObject.layer = 8;
        skeleton.ak3_6.gameObject.layer = 8;
        skeleton.ak3_7.gameObject.layer = 8;

        skeleton.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = skeleton.transform.position.x - transform.position.x > 0 ? 1 : -1;
        skeleton.rigid.AddForce(new Vector2(dirc, 0f) * 15f, ForceMode2D.Impulse);

        Invoke("offBackSkeleton", 0.2f);
        Invoke("offDamageSkeleton", 1.2f);
    }
    
    void offBackSkeleton()
    {
        skeleton.rigid.velocity = Vector3.zero;
    }
    void offDamageSkeleton()
    {
        skeleton.damage_label.text = null;
        skeleton.gameObject.layer = 7;
        skeleton.st1.gameObject.layer = 7;
        skeleton.st2.gameObject.layer = 7;
        skeleton.wk1.gameObject.layer = 7;
        skeleton.wk2.gameObject.layer = 7;
        skeleton.wk3.gameObject.layer = 7;
        skeleton.wk4.gameObject.layer = 7;
        skeleton.ak1_1.gameObject.layer = 7;
        skeleton.ak1_2.gameObject.layer = 7;
        skeleton.ak1_3.gameObject.layer = 7;
        skeleton.ak2_1.gameObject.layer = 7;
        skeleton.ak2_2.gameObject.layer = 7;
        skeleton.ak2_3.gameObject.layer = 7;
        skeleton.ak3_1.gameObject.layer = 7;
        skeleton.ak3_2.gameObject.layer = 7;
        skeleton.ak3_3.gameObject.layer = 7;
        skeleton.ak3_4.gameObject.layer = 7;
        skeleton.ak3_5.gameObject.layer = 7;
        skeleton.ak3_6.gameObject.layer = 7;
        skeleton.ak3_7.gameObject.layer = 7;
        skeleton.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void Attack_Monk_Golem()
    {
        golem.damage_label.text = Data.Instance.gameData.monk_damage.ToString();
        golem.golem_hp -= Data.Instance.gameData.monk_damage;
        golem.gameObject.layer = 8;
        golem.st1.gameObject.layer = 8;
        golem.st2.gameObject.layer = 8;
        golem.wk1.gameObject.layer = 8;
        golem.wk2.gameObject.layer = 8;
        golem.wk3.gameObject.layer = 8;
        golem.wk4.gameObject.layer = 8;
        golem.wk5.gameObject.layer = 8;
        golem.wk6.gameObject.layer = 8;
        golem.wk7.gameObject.layer = 8;
        golem.ak1_1.gameObject.layer = 8;
        golem.ak1_2.gameObject.layer = 8;
        golem.ak1_3.gameObject.layer = 8;
        golem.ak2_1.gameObject.layer = 8;
        golem.ak2_2.gameObject.layer = 8;
        golem.ak2_3.gameObject.layer = 8;
        golem.ak3_1.gameObject.layer = 8;
        golem.ak3_2.gameObject.layer = 8;
        golem.ak3_3.gameObject.layer = 8;

        golem.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = golem.transform.position.x - transform.position.x > 0 ? 1 : -1;
        golem.rigid.AddForce(new Vector2(dirc, 0f) * 30f, ForceMode2D.Impulse);

        Invoke("offBackGolem", 0.2f);
        Invoke("offDamageGolem", 1.2f);
    }
    void offBackGolem()
    {
        golem.rigid.velocity = Vector3.zero;
    }
    void offDamageGolem()
    {
        golem.damage_label.text = null;
        golem.gameObject.layer = 7;
        golem.st1.gameObject.layer = 7;
        golem.st2.gameObject.layer = 7;
        golem.wk1.gameObject.layer = 7;
        golem.wk2.gameObject.layer = 7;
        golem.wk3.gameObject.layer = 7;
        golem.wk4.gameObject.layer = 7;
        golem.wk5.gameObject.layer = 7;
        golem.wk6.gameObject.layer = 7;
        golem.wk7.gameObject.layer = 7;
        golem.ak1_1.gameObject.layer = 7;
        golem.ak1_2.gameObject.layer = 7;
        golem.ak1_3.gameObject.layer = 7;
        golem.ak2_1.gameObject.layer = 7;
        golem.ak2_2.gameObject.layer = 7;
        golem.ak2_3.gameObject.layer = 7;
        golem.ak3_1.gameObject.layer = 7;
        golem.ak3_2.gameObject.layer = 7;
        golem.ak3_3.gameObject.layer = 7;

        golem.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void Shield_Golem()
    {

    }
    //슬라임한테 공격 받았을 때
    void Attack_Monk_Slime()
    {
        slime.damage_label.text = Data.Instance.gameData.monk_damage.ToString();
        slime.slime_hp -= Data.Instance.gameData.monk_damage;
        slime.gameObject.layer = 8;
        slime.st1.gameObject.layer = 8;
        slime.st2.gameObject.layer = 8;
        slime.wk1.gameObject.layer = 8;
        slime.wk2.gameObject.layer = 8;
        slime.ak1.gameObject.layer = 8;
        slime.ak2.gameObject.layer = 8;
        slime.ak3.gameObject.layer = 8;
        slime.ak4.gameObject.layer = 8;
        slime.ak5.gameObject.layer = 8;
        slime.ak6.gameObject.layer = 8;
        slime.sk1.gameObject.layer = 8;

        slime.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = slime.transform.position.x - transform.position.x > 0 ? 1 : -1;
        slime.rigid.AddForce(new Vector2(dirc, 0f) * 20f, ForceMode2D.Impulse);

        Invoke("offBackSlime", 0.2f);
        Invoke("offDamageSlime", 1.2f);
    }
    void offBackSlime()
    {
        slime.rigid.velocity = Vector3.zero;
    }
    void offDamageSlime()
    {
        slime.damage_label.text = null;
        slime.gameObject.layer = 7;
        slime.gameObject.layer = 7;
        slime.st1.gameObject.layer = 7;
        slime.st2.gameObject.layer = 7;
        slime.wk1.gameObject.layer = 7;
        slime.wk2.gameObject.layer = 7;
        slime.ak1.gameObject.layer = 7;
        slime.ak2.gameObject.layer = 7;
        slime.ak3.gameObject.layer = 7;
        slime.ak4.gameObject.layer = 7;
        slime.ak5.gameObject.layer = 7;
        slime.ak6.gameObject.layer = 7;
        slime.sk1.gameObject.layer = 7;
        slime.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    //사신
    void Attack_Monk_Reaper()
    {
        reaper.damage_label.text = Data.Instance.gameData.monk_damage.ToString();
        reaper.reaper_hp -= Data.Instance.gameData.monk_damage;
        reaper.gameObject.layer = 8;
        reaper.st1.gameObject.layer = 8;
        reaper.st2.gameObject.layer = 8;
        reaper.st3.gameObject.layer = 8;
        reaper.st4.gameObject.layer = 8;
        reaper.ak1_1.gameObject.layer = 8;
        reaper.ak1_2.gameObject.layer = 8;
        reaper.ak1_3.gameObject.layer = 8;
        reaper.ak2_1.gameObject.layer = 8;
        reaper.ak2_2.gameObject.layer = 8;
        reaper.ak2_3.gameObject.layer = 8;

        reaper.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = reaper.transform.position.x - transform.position.x > 0 ? 1 : -1;
        reaper.rigid.AddForce(new Vector2(dirc, 0f) * 20f, ForceMode2D.Impulse);

        Invoke("offBackReaper", 0.2f);
        Invoke("offDamageReaper", 1.2f);
    }
    void offBackReaper()
    {
        reaper.rigid.velocity = Vector3.zero;
    }
    void offDamageReaper()
    {
        reaper.damage_label.text = null;
        reaper.gameObject.layer = 7;
        reaper.st1.gameObject.layer = 7;
        reaper.st2.gameObject.layer = 7;
        reaper.st3.gameObject.layer = 7;
        reaper.st4.gameObject.layer = 7;
        reaper.ak1_1.gameObject.layer = 7;
        reaper.ak1_2.gameObject.layer = 7;
        reaper.ak1_3.gameObject.layer = 7;
        reaper.ak2_1.gameObject.layer = 7;
        reaper.ak2_2.gameObject.layer = 7;
        reaper.ak2_3.gameObject.layer = 7;
        reaper.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    //뭉크가 늑대한테 공격 받았을 때
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
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        monk_hp.value -= Data.Instance.gameData.wolf_damage;


        Invoke("offDamaged", 0.75f);
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
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        monk_hp.value -= Data.Instance.gameData.wolf_last_damage;


        Invoke("offDamaged", 0.75f);
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
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;

        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        monk_hp.value -= Data.Instance.gameData.wolf_skill_damage;


        Invoke("offDamaged", 0.5f);
    }
    //뭉크가 스켈레톤한테 공격 받았을 때
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
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        monk_hp.value -= Data.Instance.gameData.skeleton_damage;


        Invoke("offDamaged", 1f);
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
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        monk_hp.value -= Data.Instance.gameData.skeleton_last_damage;


        Invoke("offDamaged", 1f);
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
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;

        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        monk_hp.value -= Data.Instance.gameData.skeleton_skill_damage;


        Invoke("offDamaged", 0.6f);
    }
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
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        monk_hp.value -= Data.Instance.gameData.golem_damage;


        Invoke("offDamaged", 0.75f);
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
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        monk_hp.value -= Data.Instance.gameData.goelm_last_damage;


        Invoke("offDamaged", 0.75f);
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
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        monk_hp.value -= Data.Instance.gameData.slime_damage;


        Invoke("offDamaged", 0.5f);
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
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;

        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        monk_hp.value -= Data.Instance.gameData.sllime_skill_damage;


        Invoke("offDamaged", 1.5f);
    }
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
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        monk_hp.value -= Data.Instance.gameData.reaper_damage;


        Invoke("offDamaged", 0.7f);
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
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;
        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        monk_hp.value -= Data.Instance.gameData.reaper_damage;


        Invoke("offDamaged", 0.7f);
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
        ak1.gameObject.layer = 17;
        ak2.gameObject.layer = 17;
        ak3.gameObject.layer = 17;

        spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        monk_hp.value -= Data.Instance.gameData.reaper_skill_damage;


        Invoke("offDamaged", 0.75f);
    }
    void offDamaged()
    {
        damage.text = null;
        gameObject.layer = 11;
        st1.gameObject.layer = 11;
        st2.gameObject.layer = 11;
        wk1.gameObject.layer = 11;
        wk2.gameObject.layer = 11;
        wk3.gameObject.layer = 11;
        wk4.gameObject.layer = 11;
        ak1.gameObject.layer = 11;
        ak2.gameObject.layer = 11;
        ak3.gameObject.layer = 11;

        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    //도적 애니메이션에 따른 콜라이더
    public void Monk_St1()
    {
        gameObject.layer = 0;
        gameObject.tag = "Untagged";

        st1.enabled = true;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
    }
    public void Monk_St2()
    {
        gameObject.layer = 0;
        gameObject.tag = "Untagged";

        st1.enabled = false;
        st2.enabled = true;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
    }
    public void Monk_Wk1()
    {
        gameObject.layer = 0;
        gameObject.tag = "Untagged";

        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = true;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
    }
    public void Monk_Wk2()
    {
        gameObject.layer = 0;
        gameObject.tag = "Untagged";

        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = true;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
    }
    public void Monk_Wk3()
    {
        gameObject.layer = 0;
        gameObject.tag = "Untagged";

        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = true;
        wk4.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
    }
    public void Monk_Wk4()
    {
        gameObject.layer = 0;
        gameObject.tag = "Untagged";

        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = true;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = false;
    }
    public void Monk_Ak1()
    {
        gameObject.layer = 0;
        gameObject.tag = "Untagged";

        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1.enabled = true;
        ak2.enabled = false;
        ak3.enabled = false;
    }
    public void Monk_Ak2()
    {
        gameObject.layer = 0;
        gameObject.tag = "Untagged";

        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1.enabled = false;
        ak2.enabled = true;
        ak3.enabled = false;
    }
    public void Monk_Ak3()
    {
        gameObject.layer = 0;
        gameObject.tag = "Untagged";

        st1.enabled = false;
        st2.enabled = false;
        wk1.enabled = false;
        wk2.enabled = false;
        wk3.enabled = false;
        wk4.enabled = false;
        ak1.enabled = false;
        ak2.enabled = false;
        ak3.enabled = true;
    }
    public void Monk_Ef1()
    {
        attack.Play();
        gameObject.layer = 11;
        gameObject.tag = "Monk";

        ef1.enabled = true;
    }
    public void Monk_Ef2()
    {
        gameObject.layer = 11;
        gameObject.tag = "Monk";

        ef1.enabled = true;
    }
    public void Monk_Ef3()
    {
        gameObject.layer = 11;
        gameObject.tag = "Monk";

        ef1.enabled = true;
    }
    public void Monk_Ef4()
    {
        gameObject.layer = 11;
        gameObject.tag = "Monk";

        ef1.enabled = true;
    }

    public void Monk_Ef5()
    {
        ef1.enabled = false;
    }
}
