using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Atk_Effect : MonoBehaviour
{

    public Character wolf_obj;//플레이어 위치
    public Skeleton skeleton_obj;//스켈레톤 플레이어
    public Golem golem_obj;//골렘 플레이어
    public Slime_In slime_obj;//슬라임 플레이어
    public Reaper reaper_obj;//사신 플레이어

    public GameObject ak_ef;//마법진
    public Animator ak;//공격이펙트
    //어택존
    public FollowCamera attack_zone;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Mage_Atk";
        ak.gameObject.tag = "Mage_Atk";

        wolf_obj = GameObject.Find("Unit").transform.Find("Player").GetComponent<Character>();
        skeleton_obj = GameObject.Find("Unit").transform.Find("Player_Skeleton").GetComponent<Skeleton>();
        golem_obj = GameObject.Find("Unit").transform.Find("Golem").GetComponent<Golem>();
        slime_obj = GameObject.Find("Unit").transform.Find("Slime").GetComponent<Slime_In>();
        reaper_obj = GameObject.Find("Unit").transform.Find("Reaper").GetComponent<Reaper>();
        attack_zone = GameObject.Find("Main Camera").GetComponent<FollowCamera>();

        if (wolf_obj.gameObject.activeSelf == true)
        {
            ak_ef.gameObject.transform.position = new Vector3(wolf_obj.gameObject.transform.position.x,
                wolf_obj.gameObject.transform.position.y - 1f, wolf_obj.gameObject.transform.position.z);

            ak.gameObject.transform.position = new Vector3(wolf_obj.gameObject.transform.position.x,
                wolf_obj.gameObject.transform.position.y + 1f, wolf_obj.gameObject.transform.position.z);
        }
        if (skeleton_obj.gameObject.activeSelf == true)
        {
            ak_ef.gameObject.transform.position = new Vector3(skeleton_obj.gameObject.transform.position.x,
                skeleton_obj.gameObject.transform.position.y - 1f, skeleton_obj.gameObject.transform.position.z);

            ak.gameObject.transform.position = new Vector3(skeleton_obj.gameObject.transform.position.x,
                skeleton_obj.gameObject.transform.position.y + 1f, skeleton_obj.gameObject.transform.position.z);
        }
        if (golem_obj.gameObject.activeSelf == true)
        {
            ak_ef.gameObject.transform.position = new Vector3(golem_obj.gameObject.transform.position.x,
                golem_obj.gameObject.transform.position.y - 1f, golem_obj.gameObject.transform.position.z);

            ak.gameObject.transform.position = new Vector3(golem_obj.gameObject.transform.position.x,
                golem_obj.gameObject.transform.position.y + 1f, golem_obj.gameObject.transform.position.z);
        }
        if (slime_obj.gameObject.activeSelf == true)
        {
            ak_ef.gameObject.transform.position = new Vector3(slime_obj.gameObject.transform.position.x,
                slime_obj.gameObject.transform.position.y - 1f, slime_obj.gameObject.transform.position.z);

            ak.gameObject.transform.position = new Vector3(slime_obj.gameObject.transform.position.x,
                slime_obj.gameObject.transform.position.y + 1f, slime_obj.gameObject.transform.position.z);
        }
        if (reaper_obj.gameObject.activeSelf == true)
        {
            ak_ef.gameObject.transform.position = new Vector3(reaper_obj.gameObject.transform.position.x,
                reaper_obj.gameObject.transform.position.y - 1f, reaper_obj.gameObject.transform.position.z);

            ak.gameObject.transform.position = new Vector3(reaper_obj.gameObject.transform.position.x,
                reaper_obj.gameObject.transform.position.y + 1f, reaper_obj.gameObject.transform.position.z);
        }

        ak.gameObject.SetActive(false);

        Invoke("Attack_Effect", 1f);
    }

    public void Attack_Effect()
    {
        ak.gameObject.SetActive(true);
        Invoke("Dis_Attack_Effect", 1f);
    }
    public void Dis_Attack_Effect()
    {
        offBack();
        offDamaged();
        offBackSkeleton();
        offDamageSkeleton();
        offBackGolem();
        offDamageGolem();
        offBackSlime();
        offDamageSlime();
        offBackReaper();
        offDamageReaper();
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //공격
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Mage_Atk")
        {
            if (attack_zone.gm.shield_cnt < 1)
                Attack_Mage();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Skeleton" && gameObject.tag == "Mage_Atk")
        {
            if (attack_zone.gm.shield_cnt < 1)
                Attack_Mage_Skeleton();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Golem" && gameObject.tag == "Mage_Atk")
        {
            if (golem_obj.skillEffect.activeSelf == false && attack_zone.gm.shield_cnt < 1)
                Attack_Mage_Golem();
            else if (attack_zone.gm.shield_cnt >= 1 && golem_obj.skillEffect.activeSelf == false)
            {
                attack_zone.gm.shield_cnt--;
            }
            if (golem_obj.skillEffect.activeSelf == true)
                Shield_Golem();

        }
        if (collision.gameObject.tag == "Slime" && gameObject.tag == "Mage_Atk")
        {
            if (slime_obj.sk1.enabled == false && attack_zone.gm.shield_cnt < 1)
                Attack_Mage_Slime();
            else if (attack_zone.gm.shield_cnt >= 1)
            {
                attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Reaper" && gameObject.tag == "Mage_Atk")
        {
            if (attack_zone.gm.shield_cnt < 1)
                Attack_Mage_Reaper();
            else
            {
                attack_zone.gm.shield_cnt--;
            }
        }
    }

    //늑대인간
    void Attack_Mage()
    {
        wolf_obj.wolf_hp -= Data.Instance.gameData.mage_damage;
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
    void Attack_Mage_Skeleton()
    {
        skeleton_obj.skeleton_hp -= Data.Instance.gameData.mage_damage;
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
    void Attack_Mage_Golem()
    {
        golem_obj.golem_hp -= Data.Instance.gameData.mage_damage;
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
    void Attack_Mage_Slime()
    {
        slime_obj.slime_hp -= Data.Instance.gameData.mage_damage;
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
    void Attack_Mage_Reaper()
    {
        reaper_obj.reaper_hp -= Data.Instance.gameData.mage_damage;
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
}
