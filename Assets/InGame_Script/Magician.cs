using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Magician : MonoBehaviour
{
    public AudioSource attack;//공격
    public AudioSource hit;//피격

    public Animator magician_effect_anima;
    public Magician_Effect magician_Effect;
    public SpriteRenderer spriteRenderer;

    public float speed;
    public float atkCoolTime = 5f;
    public float atkDelay;

    public Character player_position;//플레이어 위치
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

    public CircleCollider2D ef1;
    public GameObject ef2;
    public GameObject ef3;
    public GameObject ef4;


    //hp바
    public Slider magician_hp;

    public GameObject damage_label;
    public TextMeshProUGUI damage;
    //이펙트 위치
    public GameObject fire_line;
    //애니매이션
    //어택존
    public FollowCamera attack_zone;
    public int vampire_percent;
    private void Awake()
    {
        player_position = GameObject.Find("Unit").transform.Find("Player").GetComponent<Character>();
        skeleton = GameObject.Find("Unit").transform.Find("Player_Skeleton").GetComponent<Skeleton>();
        golem = GameObject.Find("Unit").transform.Find("Golem").GetComponent<Golem>();
        slime = GameObject.Find("Unit").transform.Find("Slime").GetComponent<Slime_In>();
        reaper = GameObject.Find("Unit").transform.Find("Reaper").GetComponent<Reaper>();
        attack_zone = GameObject.Find("Main Camera").GetComponent<FollowCamera>();

    }
    void Start()
    {
        damage.text = null;
        magician_hp.maxValue = Data.Instance.gameData.magician_hp;
        speed = Data.Instance.gameData.magician_speed;
        magician_hp.value = magician_hp.maxValue;

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

        ef1.gameObject.SetActive(false);
        ef2.gameObject.SetActive(false);
        ef3.gameObject.SetActive(false);
        ef4.gameObject.SetActive(false);
        fire_line.gameObject.SetActive(false);
        magician_Effect.gameObject.SetActive(false);


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

        if (magician_hp.value == 0)
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
            magician_Effect.offBack();
            magician_Effect.offBackGolem();
            magician_Effect.offBackReaper();
            magician_Effect.offBackSkeleton();
            magician_Effect.offBackSlime();
            magician_Effect.offDamage();
            magician_Effect.offDamageGolem();
            magician_Effect.offDamageReaper();
            magician_Effect.offDamageSkeleton();
            magician_Effect.offDamageSlime();
            attack_zone.score += 5;
            if (attack_zone.death_cnt > 0)
                attack_zone.death_cnt--;
            Destroy(gameObject);
        }

        magician_Effect.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        if (magician_hp.value == magician_hp.maxValue)
            magician_hp.gameObject.SetActive(false);
        else
            magician_hp.gameObject.SetActive(true);

        if (atkDelay >= 0)
            atkDelay -= Time.deltaTime;

        
        magician_hp.transform.position = gameObject.transform.localPosition + new Vector3(0f, 1f, 0f);
        //위치 및 크기
        if (gameObject.transform.position.x - attack_zone.origin.transform.position.x > 0)
        {
            transform.localScale = new Vector3(3f, 3f, 1f);
            damage_label.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-3f, 3f, 1f);
            damage_label.gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }



        //총알 나가기
        if (ef1.enabled == true)
            ef1.transform.Translate(Vector3.left * Time.deltaTime * 25f);
        else if (ef1.enabled == false)
            ef1.transform.localPosition = new Vector3(0, 0, 0);

        damage_label.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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

        magician_hp.value -= 10;

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
            magician_hp.value -= 4;
            damage.text = 4.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 2)
        {
            magician_hp.value -= 5;
            damage.text = 5.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 3)
        {
            magician_hp.value -= 6;
            damage.text = 6.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 4)
        {
            magician_hp.value -= 7;
            damage.text = 7.ToString();
        }
        else if (Data.Instance.gameData.arrowlv == 5)
        {
            magician_hp.value -= 8;
            damage.text = 8.ToString();
        }

        Invoke("offDamaged", 0.75f);
    }


    //도적이 공격 받았을 때
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

        magician_hp.value -= Data.Instance.gameData.wolf_damage;


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

        magician_hp.value -= Data.Instance.gameData.wolf_last_damage;


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

        magician_hp.value -= Data.Instance.gameData.wolf_skill_damage;


        Invoke("offDamaged", 0.5f);
    }
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

        magician_hp.value -= Data.Instance.gameData.skeleton_damage;


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

        magician_hp.value -= Data.Instance.gameData.skeleton_last_damage;


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

        magician_hp.value -= Data.Instance.gameData.skeleton_skill_damage;


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

        magician_hp.value -= Data.Instance.gameData.golem_damage;


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

        magician_hp.value -= Data.Instance.gameData.goelm_last_damage;


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

        magician_hp.value -= Data.Instance.gameData.slime_damage;


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

        magician_hp.value -= Data.Instance.gameData.sllime_skill_damage;


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

        magician_hp.value -= Data.Instance.gameData.reaper_damage;


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

        magician_hp.value -= Data.Instance.gameData.reaper_damage;


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

        magician_hp.value -= Data.Instance.gameData.reaper_skill_damage;


        Invoke("offDamaged", 0.75f);
    }
    void offDamaged()
    {
        damage.text = null;
        gameObject.layer = 15;
        st1.gameObject.layer = 15;
        st2.gameObject.layer = 15;
        wk1.gameObject.layer = 15;
        wk2.gameObject.layer = 15;
        wk3.gameObject.layer = 15;
        wk4.gameObject.layer = 15;
        ak1.gameObject.layer = 15;
        ak2.gameObject.layer = 15;
        ak3.gameObject.layer = 15;

        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    //도적 애니메이션에 따른 콜라이더
    public void Magician_St1()
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
    public void Magician_St2()
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
    public void Magician_Wk1()
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
    public void Magician_Wk2()
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
    public void Magician_Wk3()
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
    public void Magician_Wk4()
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
    public void Magician_Ak1()
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
    public void Magician_Ak2()
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
    public void Magician_Ak3()
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
        fire_line.gameObject.SetActive(false);
    }


    public void Magician_FireLine()
    {
        fire_line.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
        Vector2 heading = player_position.transform.localPosition - gameObject.transform.localPosition;
        if (heading.x < 0)
            heading *= -1;
        float angle = Mathf.Atan2(heading.y, heading.x) * Mathf.Rad2Deg;

        Vector2 heading2 = skeleton.transform.localPosition - gameObject.transform.localPosition;
        if (heading2.x < 0)
            heading2 *= -1;
        float angle2 = Mathf.Atan2(heading2.y, heading2.x) * Mathf.Rad2Deg;
        //골렘
        Vector2 heading3 = golem.transform.localPosition - gameObject.transform.localPosition;
        if (heading3.x < 0)
            heading3 *= -1;
        float angle3 = Mathf.Atan2(heading3.y, heading3.x) * Mathf.Rad2Deg;
        //슬라임
        Vector2 heading4 = slime.transform.localPosition - gameObject.transform.localPosition;
        if (heading4.x < 0)
            heading4 *= -1;
        float angle4 = Mathf.Atan2(heading4.y, heading4.x) * Mathf.Rad2Deg;
        //사신
        Vector2 heading5 = reaper.transform.localPosition - gameObject.transform.localPosition;
        if (heading5.x < 0)
            heading5 *= -1;
        float angle5 = Mathf.Atan2(heading5.y, heading5.x) * Mathf.Rad2Deg;

        if (player_position.gameObject.activeSelf == true)
        {
            ef1.gameObject.transform.eulerAngles = new Vector3(0, 0, angle);
            ef2.gameObject.transform.eulerAngles = new Vector3(0, 0, angle);
            ef3.gameObject.transform.eulerAngles = new Vector3(0, 0, angle);
            ef4.gameObject.transform.eulerAngles = new Vector3(0, 0, angle);
            fire_line.gameObject.transform.eulerAngles = new Vector3(0, 0, angle);
        }
        if (skeleton.gameObject.activeSelf == true)
        {
            ef1.gameObject.transform.eulerAngles = new Vector3(0, 0, angle2);
            ef2.gameObject.transform.eulerAngles = new Vector3(0, 0, angle2);
            ef3.gameObject.transform.eulerAngles = new Vector3(0, 0, angle2);
            ef4.gameObject.transform.eulerAngles = new Vector3(0, 0, angle2);
            fire_line.gameObject.transform.eulerAngles = new Vector3(0, 0, angle2);
        }
        if (golem.gameObject.activeSelf == true)
        {
            ef1.gameObject.transform.eulerAngles = new Vector3(0, 0, angle3);
            ef2.gameObject.transform.eulerAngles = new Vector3(0, 0, angle3);
            ef3.gameObject.transform.eulerAngles = new Vector3(0, 0, angle3);
            ef4.gameObject.transform.eulerAngles = new Vector3(0, 0, angle3);
            fire_line.gameObject.transform.eulerAngles = new Vector3(0, 0, angle3);
        }
        if (slime.gameObject.activeSelf == true)
        {
            ef1.gameObject.transform.eulerAngles = new Vector3(0, 0, angle4);
            ef2.gameObject.transform.eulerAngles = new Vector3(0, 0, angle4);
            ef3.gameObject.transform.eulerAngles = new Vector3(0, 0, angle4);
            ef4.gameObject.transform.eulerAngles = new Vector3(0, 0, angle4);
            fire_line.gameObject.transform.eulerAngles = new Vector3(0, 0, angle4);
        }
        if (reaper.gameObject.activeSelf == true)
        {
            ef1.gameObject.transform.eulerAngles = new Vector3(0, 0, angle5);
            ef2.gameObject.transform.eulerAngles = new Vector3(0, 0, angle5);
            ef3.gameObject.transform.eulerAngles = new Vector3(0, 0, angle5);
            ef4.gameObject.transform.eulerAngles = new Vector3(0, 0, angle5);
            fire_line.gameObject.transform.eulerAngles = new Vector3(0, 0, angle5);
        }

        ef1.gameObject.SetActive(false);
        ef2.gameObject.SetActive(false);
        ef3.gameObject.SetActive(false);
        ef4.gameObject.SetActive(false);

        fire_line.gameObject.SetActive(true);
        magician_Effect.gameObject.SetActive(true);
    }
    public void Magician_Fire1()
    {
        magician_Effect.gameObject.SetActive(true);
        ef1.gameObject.SetActive(true);

        attack.Play();

        ef1.enabled = true;


        ef1.gameObject.layer = 14;
        ef1.gameObject.tag = "Magician";
        ef2.gameObject.layer = 14;
        ef2.gameObject.tag = "Magician";
        ef3.gameObject.layer = 14;
        ef3.gameObject.tag = "Magician";
        ef4.gameObject.layer = 14;
        ef4.gameObject.tag = "Magician";
    }

    public void Magician_Fire2()
    {
        magician_Effect.gameObject.SetActive(true);
        ef1.gameObject.SetActive(true);

        ef1.enabled = true;


        ef1.gameObject.layer = 14;
        ef1.gameObject.tag = "Magician";
        ef2.gameObject.layer = 14;
        ef2.gameObject.tag = "Magician";
        ef3.gameObject.layer = 14;
        ef3.gameObject.tag = "Magician";
        ef4.gameObject.layer = 14;
        ef4.gameObject.tag = "Magician";
    }

    public void Magician_Fire3()
    {
        magician_Effect.gameObject.SetActive(true);
        ef1.gameObject.SetActive(true);

        ef1.enabled = true;


        ef1.gameObject.layer = 14;
        ef1.gameObject.tag = "Magician";
        ef2.gameObject.layer = 14;
        ef2.gameObject.tag = "Magician";
        ef3.gameObject.layer = 14;
        ef3.gameObject.tag = "Magician";
        ef4.gameObject.layer = 14;
        ef4.gameObject.tag = "Magician";
    }

    public void Magician_Fire4()
    {
        magician_Effect.gameObject.SetActive(true);
        ef1.gameObject.SetActive(true);

        ef1.enabled = true;


        ef1.gameObject.layer = 14;
        ef1.gameObject.tag = "Magician";
        ef2.gameObject.layer = 14;
        ef2.gameObject.tag = "Magician";
        ef3.gameObject.layer = 14;
        ef3.gameObject.tag = "Magician";
        ef4.gameObject.layer = 14;
        ef4.gameObject.tag = "Magician";
    }
}
