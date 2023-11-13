using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate_Effect : MonoBehaviour
{
    public Pirate pirate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Pirate")
        {
            pirate.hit.Play();
            if (pirate.attack_zone.gm.shield_cnt < 1)
                Attack_Pirate();
            else
            {
                pirate.attack_zone.gm.shield_cnt--;
            }
            pirate.ef1.enabled = false;
            pirate.bullet.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Skeleton" && gameObject.tag == "Pirate")
        {
            pirate.hit.Play();
            if (pirate.attack_zone.gm.shield_cnt < 1)
                Attack_Pirate_Skeleton();
            else
            {
                pirate.attack_zone.gm.shield_cnt--;
            }
            pirate.ef1.enabled = false;
            pirate.bullet.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Golem" && gameObject.tag == "Pirate")
        {
            pirate.hit.Play();
            pirate.ef1.enabled = false;
            pirate.bullet.gameObject.SetActive(false);
            if (pirate.golem.skillEffect.activeSelf == false && pirate.attack_zone.gm.shield_cnt < 1)
                Attack_Pirate_Golem();
            else if (pirate.attack_zone.gm.shield_cnt >= 1 && pirate.golem.skillEffect.activeSelf == false)
            {
                pirate.attack_zone.gm.shield_cnt--;
            }
            if (pirate.golem.skillEffect.activeSelf == true)
                Shield_Golem();
        }
        if (collision.gameObject.tag == "Slime" && gameObject.tag == "Pirate")
        {
            pirate.hit.Play();
            pirate.ef1.enabled = false;
            pirate.bullet.gameObject.SetActive(false);
            if (pirate.slime.sk1.enabled == false && pirate.attack_zone.gm.shield_cnt < 1)
                Attack_Pirate_Slime();
            else if (pirate.attack_zone.gm.shield_cnt >= 1)
            {
                pirate.attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Reaper" && gameObject.tag == "Pirate")
        {
            pirate.hit.Play();
            if (pirate.attack_zone.gm.shield_cnt < 1)
                Attack_Pirate_Reaper();
            else
            {
                pirate.attack_zone.gm.shield_cnt--;
            }
            pirate.ef1.enabled = false;
            pirate.bullet.gameObject.SetActive(false);
        }
    }

    void Attack_Pirate()
    {
        pirate.player_position.damage_label.text = Data.Instance.gameData.pirate_damage.ToString();
        pirate.player_position.wolf_hp -= Data.Instance.gameData.pirate_damage;
        pirate.player_position.gameObject.layer = 8;
        pirate.player_position.st1.gameObject.layer = 8;
        pirate.player_position.st2.gameObject.layer = 8;
        pirate.player_position.wk1.gameObject.layer = 8;
        pirate.player_position.wk2.gameObject.layer = 8;
        pirate.player_position.ak1_1.gameObject.layer = 8;
        pirate.player_position.ak1_2.gameObject.layer = 8;
        pirate.player_position.ak1_3.gameObject.layer = 8;
        pirate.player_position.ak2_1.gameObject.layer = 8;
        pirate.player_position.ak2_2.gameObject.layer = 8;
        pirate.player_position.ak2_3.gameObject.layer = 8;
        pirate.player_position.ak3_1.gameObject.layer = 8;
        pirate.player_position.ak3_2.gameObject.layer = 8;
        pirate.player_position.ak3_3.gameObject.layer = 8;

        pirate.player_position.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = pirate.player_position.transform.position.x - transform.position.x > 0 ? 1 : -1;
        pirate.player_position.rigid.AddForce(new Vector2(dirc, 0f) * 30f, ForceMode2D.Impulse);

        Invoke("offBack", 0.2f);
        Invoke("offDamage", 1.2f);
    }
    public void offBack()
    {
        pirate.player_position.rigid.velocity = Vector3.zero;
    }
    public void offDamage()
    {
        pirate.player_position.damage_label.text = null;
        pirate.player_position.gameObject.layer = 7;
        pirate.player_position.st1.gameObject.layer = 7;
        pirate.player_position.st2.gameObject.layer = 7;
        pirate.player_position.wk1.gameObject.layer = 7;
        pirate.player_position.wk2.gameObject.layer = 7;
        pirate.player_position.ak1_1.gameObject.layer = 7;
        pirate.player_position.ak1_2.gameObject.layer = 7;
        pirate.player_position.ak1_3.gameObject.layer = 7;
        pirate.player_position.ak2_1.gameObject.layer = 7;
        pirate.player_position.ak2_2.gameObject.layer = 7;
        pirate.player_position.ak2_3.gameObject.layer = 7;
        pirate.player_position.ak3_1.gameObject.layer = 7;
        pirate.player_position.ak3_2.gameObject.layer = 7;
        pirate.player_position.ak3_3.gameObject.layer = 7;
        pirate.player_position.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void Attack_Pirate_Skeleton()
    {
        pirate.skeleton.damage_label.text = Data.Instance.gameData.pirate_damage.ToString();
        pirate.skeleton.skeleton_hp -= Data.Instance.gameData.pirate_damage;
        pirate.skeleton.gameObject.layer = 8;
        pirate.skeleton.st1.gameObject.layer = 8;
        pirate.skeleton.st2.gameObject.layer = 8;
        pirate.skeleton.wk1.gameObject.layer = 8;
        pirate.skeleton.wk2.gameObject.layer = 8;
        pirate.skeleton.wk3.gameObject.layer = 8;
        pirate.skeleton.wk4.gameObject.layer = 8;
        pirate.skeleton.ak1_1.gameObject.layer = 8;
        pirate.skeleton.ak1_2.gameObject.layer = 8;
        pirate.skeleton.ak1_3.gameObject.layer = 8;
        pirate.skeleton.ak2_1.gameObject.layer = 8;
        pirate.skeleton.ak2_2.gameObject.layer = 8;
        pirate.skeleton.ak2_3.gameObject.layer = 8;
        pirate.skeleton.ak3_1.gameObject.layer = 8;
        pirate.skeleton.ak3_2.gameObject.layer = 8;
        pirate.skeleton.ak3_3.gameObject.layer = 8;
        pirate.skeleton.ak3_4.gameObject.layer = 8;
        pirate.skeleton.ak3_5.gameObject.layer = 8;
        pirate.skeleton.ak3_6.gameObject.layer = 8;
        pirate.skeleton.ak3_7.gameObject.layer = 8;

        pirate.skeleton.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = pirate.skeleton.transform.position.x - transform.position.x > 0 ? 1 : -1;
        pirate.skeleton.rigid.AddForce(new Vector2(dirc, 0f) * 15f, ForceMode2D.Impulse);

        Invoke("offBackSkeleton", 0.2f);
        Invoke("offDamageSkeleton", 1.2f);
    }
    public void offBackSkeleton()
    {
        pirate.skeleton.rigid.velocity = Vector3.zero;
    }
    public void offDamageSkeleton()
    {
        pirate.skeleton.damage_label.text = null;
        pirate.skeleton.gameObject.layer = 7;
        pirate.skeleton.st1.gameObject.layer = 7;
        pirate.skeleton.st2.gameObject.layer = 7;
        pirate.skeleton.wk1.gameObject.layer = 7;
        pirate.skeleton.wk2.gameObject.layer = 7;
        pirate.skeleton.ak1_1.gameObject.layer = 7;
        pirate.skeleton.ak1_2.gameObject.layer = 7;
        pirate.skeleton.ak1_3.gameObject.layer = 7;
        pirate.skeleton.ak2_1.gameObject.layer = 7;
        pirate.skeleton.ak2_2.gameObject.layer = 7;
        pirate.skeleton.ak2_3.gameObject.layer = 7;
        pirate.skeleton.ak3_1.gameObject.layer = 7;
        pirate.skeleton.ak3_2.gameObject.layer = 7;
        pirate.skeleton.ak3_3.gameObject.layer = 7;
        pirate.skeleton.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void Attack_Pirate_Golem()
    {
        pirate.golem.damage_label.text = Data.Instance.gameData.pirate_damage.ToString();
        pirate.golem.golem_hp -= Data.Instance.gameData.pirate_damage;
        pirate.golem.gameObject.layer = 8;
        pirate.golem.st1.gameObject.layer = 8;
        pirate.golem.st2.gameObject.layer = 8;
        pirate.golem.wk1.gameObject.layer = 8;
        pirate.golem.wk2.gameObject.layer = 8;
        pirate.golem.wk3.gameObject.layer = 8;
        pirate.golem.wk4.gameObject.layer = 8;
        pirate.golem.wk5.gameObject.layer = 8;
        pirate.golem.wk6.gameObject.layer = 8;
        pirate.golem.wk7.gameObject.layer = 8;
        pirate.golem.ak1_1.gameObject.layer = 8;
        pirate.golem.ak1_2.gameObject.layer = 8;
        pirate.golem.ak1_3.gameObject.layer = 8;
        pirate.golem.ak2_1.gameObject.layer = 8;
        pirate.golem.ak2_2.gameObject.layer = 8;
        pirate.golem.ak2_3.gameObject.layer = 8;
        pirate.golem.ak3_1.gameObject.layer = 8;
        pirate.golem.ak3_2.gameObject.layer = 8;
        pirate.golem.ak3_3.gameObject.layer = 8;

        pirate.golem.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = pirate.golem.transform.position.x - transform.position.x > 0 ? 1 : -1;
        pirate.golem.rigid.AddForce(new Vector2(dirc, 0f) * 30f, ForceMode2D.Impulse);

        Invoke("offBackGolem", 0.2f);
        Invoke("offDamageGolem", 1.2f);
    }
    public void offBackGolem()
    {
        pirate.golem.rigid.velocity = Vector3.zero;
    }
    public void offDamageGolem()
    {
        pirate.golem.damage_label.text = null;
        pirate.golem.gameObject.layer = 7;
        pirate.golem.st1.gameObject.layer = 7;
        pirate.golem.st2.gameObject.layer = 7;
        pirate.golem.wk1.gameObject.layer = 7;
        pirate.golem.wk2.gameObject.layer = 7;
        pirate.golem.wk3.gameObject.layer = 7;
        pirate.golem.wk4.gameObject.layer = 7;
        pirate.golem.wk5.gameObject.layer = 7;
        pirate.golem.wk6.gameObject.layer = 7;
        pirate.golem.wk7.gameObject.layer = 7;
        pirate.golem.ak1_1.gameObject.layer = 7;
        pirate.golem.ak1_2.gameObject.layer = 7;
        pirate.golem.ak1_3.gameObject.layer = 7;
        pirate.golem.ak2_1.gameObject.layer = 7;
        pirate.golem.ak2_2.gameObject.layer = 7;
        pirate.golem.ak2_3.gameObject.layer = 7;
        pirate.golem.ak3_1.gameObject.layer = 7;
        pirate.golem.ak3_2.gameObject.layer = 7;
        pirate.golem.ak3_3.gameObject.layer = 7;

        pirate.golem.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void Shield_Golem()
    {

    }
    //슬라임한테 공격 받았을 때
    void Attack_Pirate_Slime()
    {
        pirate.slime.damage_label.text = Data.Instance.gameData.pirate_damage.ToString();
        pirate.slime.slime_hp -= Data.Instance.gameData.pirate_damage;
        pirate.slime.gameObject.layer = 8;
        pirate.slime.st1.gameObject.layer = 8;
        pirate.slime.st2.gameObject.layer = 8;
        pirate.slime.wk1.gameObject.layer = 8;
        pirate.slime.wk2.gameObject.layer = 8;
        pirate.slime.ak1.gameObject.layer = 8;
        pirate.slime.ak2.gameObject.layer = 8;
        pirate.slime.ak3.gameObject.layer = 8;
        pirate.slime.ak4.gameObject.layer = 8;
        pirate.slime.ak5.gameObject.layer = 8;
        pirate.slime.ak6.gameObject.layer = 8;
        pirate.slime.sk1.gameObject.layer = 8;

        pirate.slime.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = pirate.slime.transform.position.x - transform.position.x > 0 ? 1 : -1;
        pirate.slime.rigid.AddForce(new Vector2(dirc, 0f) * 20f, ForceMode2D.Impulse);

        Invoke("offBackSlime", 0.2f);
        Invoke("offDamageSlime", 1.2f);
    }
    public void offBackSlime()
    {
        pirate.slime.rigid.velocity = Vector3.zero;
    }
    public void offDamageSlime()
    {
        pirate.slime.damage_label.text = null;
        pirate.slime.gameObject.layer = 7;
        pirate.slime.gameObject.layer = 7;
        pirate.slime.st1.gameObject.layer = 7;
        pirate.slime.st2.gameObject.layer = 7;
        pirate.slime.wk1.gameObject.layer = 7;
        pirate.slime.wk2.gameObject.layer = 7;
        pirate.slime.ak1.gameObject.layer = 7;
        pirate.slime.ak2.gameObject.layer = 7;
        pirate.slime.ak3.gameObject.layer = 7;
        pirate.slime.ak4.gameObject.layer = 7;
        pirate.slime.ak5.gameObject.layer = 7;
        pirate.slime.ak6.gameObject.layer = 7;
        pirate.slime.sk1.gameObject.layer = 7;
        pirate.slime.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    //사신
    void Attack_Pirate_Reaper()
    {
        pirate.reaper.damage_label.text = Data.Instance.gameData.pirate_damage.ToString();
        pirate.reaper.reaper_hp -= Data.Instance.gameData.pirate_damage;
        pirate.reaper.gameObject.layer = 8;
        pirate.reaper.st1.gameObject.layer = 8;
        pirate.reaper.st2.gameObject.layer = 8;
        pirate.reaper.st3.gameObject.layer = 8;
        pirate.reaper.st4.gameObject.layer = 8;
        pirate.reaper.ak1_1.gameObject.layer = 8;
        pirate.reaper.ak1_2.gameObject.layer = 8;
        pirate.reaper.ak1_3.gameObject.layer = 8;
        pirate.reaper.ak2_1.gameObject.layer = 8;
        pirate.reaper.ak2_2.gameObject.layer = 8;
        pirate.reaper.ak2_3.gameObject.layer = 8;



        pirate.reaper.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = pirate.reaper.transform.position.x - transform.position.x > 0 ? 1 : -1;
        pirate.reaper.rigid.AddForce(new Vector2(dirc, 0f) * 30f, ForceMode2D.Impulse);

        Invoke("offBackReaper", 0.2f);
        Invoke("offDamageReaper", 1.2f);
    }
    public void offBackReaper()
    {
        pirate.reaper.rigid.velocity = Vector3.zero;
    }
    public void offDamageReaper()
    {
        pirate.reaper.damage_label.text = null;
        pirate.reaper.gameObject.layer = 7;
        pirate.reaper.st1.gameObject.layer = 7;
        pirate.reaper.st2.gameObject.layer = 7;
        pirate.reaper.st3.gameObject.layer = 7;
        pirate.reaper.st4.gameObject.layer = 7;
        pirate.reaper.ak1_1.gameObject.layer = 7;
        pirate.reaper.ak1_2.gameObject.layer = 7;
        pirate.reaper.ak1_3.gameObject.layer = 7;
        pirate.reaper.ak2_1.gameObject.layer = 7;
        pirate.reaper.ak2_2.gameObject.layer = 7;
        pirate.reaper.ak2_3.gameObject.layer = 7;
        pirate.reaper.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
