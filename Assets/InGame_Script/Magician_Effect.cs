using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician_Effect : MonoBehaviour
{
    public Magician magician;
    public bool atk_end;//맞으면 공격 끝

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Magician")
        {
            magician.hit.Play();
            magician.ef1.enabled = false;

            atk_end = true;
            if (magician.attack_zone.gm.shield_cnt < 1)
                Attack_Magician();
            else
            {
                magician.attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Skeleton" && gameObject.tag == "Magician")
        {
            magician.hit.Play();
            magician.ef1.enabled = false;

            atk_end = true;
            if (magician.attack_zone.gm.shield_cnt < 1)
                Attack_Magician_Skeleton();
            else
            {
                magician.attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Golem" && gameObject.tag == "Magician")
        {
            magician.hit.Play();
            magician.ef1.enabled = false;

            atk_end = true;
            if (magician.golem.skillEffect.activeSelf == false&& magician.attack_zone.gm.shield_cnt < 1)
                Attack_Magician_Golem();
            else if (magician.attack_zone.gm.shield_cnt >= 1 && magician.golem.skillEffect.activeSelf == false)
            {
                magician.attack_zone.gm.shield_cnt--;
            }
            if (magician.golem.skillEffect.activeSelf == true)
                Shield_Golem();
        }
        if (collision.gameObject.tag == "Slime" && gameObject.tag == "Magician")
        {
            magician.hit.Play();
            magician.ef1.enabled = false;

            atk_end = true;
            if (magician.slime.sk1.enabled == false && magician.attack_zone.gm.shield_cnt < 1)
                Attack_Magician_Slime();
            else if (magician.attack_zone.gm.shield_cnt >= 1)
            {
                magician.attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Reaper" && gameObject.tag == "Magician")
        {
            magician.hit.Play();
            magician.ef1.enabled = false;

            atk_end = true;
            if (magician.attack_zone.gm.shield_cnt < 1)
                Attack_Magician_Reaper();
            else
            {
                magician.attack_zone.gm.shield_cnt--;
            }
        }
    }

    void Attack_Magician()
    {
        magician.player_position.damage_label.text = Data.Instance.gameData.magician_damage.ToString();
        magician.player_position.wolf_hp -= Data.Instance.gameData.magician_damage;
        magician.player_position.gameObject.layer = 8;
        magician.player_position.st1.gameObject.layer = 8;
        magician.player_position.st2.gameObject.layer = 8;
        magician.player_position.wk1.gameObject.layer = 8;
        magician.player_position.wk2.gameObject.layer = 8;
        magician.player_position.ak1_1.gameObject.layer = 8;
        magician.player_position.ak1_2.gameObject.layer = 8;
        magician.player_position.ak1_3.gameObject.layer = 8;
        magician.player_position.ak2_1.gameObject.layer = 8;
        magician.player_position.ak2_2.gameObject.layer = 8;
        magician.player_position.ak2_3.gameObject.layer = 8;
        magician.player_position.ak3_1.gameObject.layer = 8;
        magician.player_position.ak3_2.gameObject.layer = 8;
        magician.player_position.ak3_3.gameObject.layer = 8;

        magician.player_position.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = magician.player_position.transform.position.x - transform.position.x > 0 ? 1 : -1;
        magician.player_position.rigid.AddForce(new Vector2(dirc, 0f) * 30f, ForceMode2D.Impulse);

        Invoke("offBack", 0.2f);
        Invoke("offDamage", 1.2f);
    }
    
    public void offBack()
    {
        magician.player_position.rigid.velocity = Vector3.zero;
    }
    public void offDamage()
    {
        magician.player_position.damage_label.text = null;
        magician.player_position.gameObject.layer = 7;
        magician.player_position.st1.gameObject.layer = 7;
        magician.player_position.st2.gameObject.layer = 7;
        magician.player_position.wk1.gameObject.layer = 7;
        magician.player_position.wk2.gameObject.layer = 7;
        magician.player_position.ak1_1.gameObject.layer = 7;
        magician.player_position.ak1_2.gameObject.layer = 7;
        magician.player_position.ak1_3.gameObject.layer = 7;
        magician.player_position.ak2_1.gameObject.layer = 7;
        magician.player_position.ak2_2.gameObject.layer = 7;
        magician.player_position.ak2_3.gameObject.layer = 7;
        magician.player_position.ak3_1.gameObject.layer = 7;
        magician.player_position.ak3_2.gameObject.layer = 7;
        magician.player_position.ak3_3.gameObject.layer = 7;
        magician.player_position.spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void Attack_Magician_Skeleton()
    {
        magician.skeleton.damage_label.text = Data.Instance.gameData.magician_damage.ToString();
        magician.skeleton.skeleton_hp -= Data.Instance.gameData.magician_damage;
        magician.skeleton.gameObject.layer = 8;
        magician.skeleton.st1.gameObject.layer = 8;
        magician.skeleton.st2.gameObject.layer = 8;
        magician.skeleton.wk1.gameObject.layer = 8;
        magician.skeleton.wk2.gameObject.layer = 8;
        magician.skeleton.wk3.gameObject.layer = 8;
        magician.skeleton.wk4.gameObject.layer = 8;
        magician.skeleton.ak1_1.gameObject.layer = 8;
        magician.skeleton.ak1_2.gameObject.layer = 8;
        magician.skeleton.ak1_3.gameObject.layer = 8;
        magician.skeleton.ak2_1.gameObject.layer = 8;
        magician.skeleton.ak2_2.gameObject.layer = 8;
        magician.skeleton.ak2_3.gameObject.layer = 8;
        magician.skeleton.ak3_1.gameObject.layer = 8;
        magician.skeleton.ak3_2.gameObject.layer = 8;
        magician.skeleton.ak3_3.gameObject.layer = 8;
        magician.skeleton.ak3_4.gameObject.layer = 8;
        magician.skeleton.ak3_5.gameObject.layer = 8;
        magician.skeleton.ak3_6.gameObject.layer = 8;
        magician.skeleton.ak3_7.gameObject.layer = 8;

        magician.skeleton.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = magician.skeleton.transform.position.x - transform.position.x > 0 ? 1 : -1;
        magician.skeleton.rigid.AddForce(new Vector2(dirc, 0f) * 15f, ForceMode2D.Impulse);

        Invoke("offBackSkeleton", 0.2f);
        Invoke("offDamageSkeleton", 1.2f);
    }
    public void offBackSkeleton()
    {
        magician.skeleton.rigid.velocity = Vector3.zero;
    }
    public void offDamageSkeleton()
    {
        magician.skeleton.damage_label.text = null;
        magician.skeleton.gameObject.layer = 8;
        magician.skeleton.st1.gameObject.layer = 8;
        magician.skeleton.st2.gameObject.layer = 8;
        magician.skeleton.wk1.gameObject.layer = 8;
        magician.skeleton.wk2.gameObject.layer = 8;
        magician.skeleton.wk3.gameObject.layer = 8;
        magician.skeleton.wk4.gameObject.layer = 8;
        magician.skeleton.ak1_1.gameObject.layer = 8;
        magician.skeleton.ak1_2.gameObject.layer = 8;
        magician.skeleton.ak1_3.gameObject.layer = 8;
        magician.skeleton.ak2_1.gameObject.layer = 8;
        magician.skeleton.ak2_2.gameObject.layer = 8;
        magician.skeleton.ak2_3.gameObject.layer = 8;
        magician.skeleton.ak3_1.gameObject.layer = 8;
        magician.skeleton.ak3_2.gameObject.layer = 8;
        magician.skeleton.ak3_3.gameObject.layer = 8;
        magician.skeleton.ak3_4.gameObject.layer = 8;
        magician.skeleton.ak3_5.gameObject.layer = 8;
        magician.skeleton.ak3_6.gameObject.layer = 8;
        magician.skeleton.ak3_7.gameObject.layer = 8;
        magician.skeleton.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void Attack_Magician_Golem()
    {
        magician.golem.damage_label.text = Data.Instance.gameData.magician_damage.ToString();
        magician.golem.golem_hp -= Data.Instance.gameData.magician_damage;
        magician.golem.gameObject.layer = 8;
        magician.golem.st1.gameObject.layer = 8;
        magician.golem.st2.gameObject.layer = 8;
        magician.golem.wk1.gameObject.layer = 8;
        magician.golem.wk2.gameObject.layer = 8;
        magician.golem.wk3.gameObject.layer = 8;
        magician.golem.wk4.gameObject.layer = 8;
        magician.golem.wk5.gameObject.layer = 8;
        magician.golem.wk6.gameObject.layer = 8;
        magician.golem.wk7.gameObject.layer = 8;
        magician.golem.ak1_1.gameObject.layer = 8;
        magician.golem.ak1_2.gameObject.layer = 8;
        magician.golem.ak1_3.gameObject.layer = 8;
        magician.golem.ak2_1.gameObject.layer = 8;
        magician.golem.ak2_2.gameObject.layer = 8;
        magician.golem.ak2_3.gameObject.layer = 8;
        magician.golem.ak3_1.gameObject.layer = 8;
        magician.golem.ak3_2.gameObject.layer = 8;
        magician.golem.ak3_3.gameObject.layer = 8;

        magician.golem.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = magician.golem.transform.position.x - transform.position.x > 0 ? 1 : -1;
        magician.golem.rigid.AddForce(new Vector2(dirc, 0f) * 30f, ForceMode2D.Impulse);

        Invoke("offBackGolem", 0.2f);
        Invoke("offDamageGolem", 1.2f);
    }


    public void offBackGolem()
    {
        magician.golem.rigid.velocity = Vector3.zero;
    }
    public void offDamageGolem()
    {
        magician.golem.damage_label.text = null;
        magician.golem.gameObject.layer = 7;
        magician.golem.st1.gameObject.layer = 7;
        magician.golem.st2.gameObject.layer = 7;
        magician.golem.wk1.gameObject.layer = 7;
        magician.golem.wk2.gameObject.layer = 7;
        magician.golem.wk3.gameObject.layer = 7;
        magician.golem.wk4.gameObject.layer = 7;
        magician.golem.wk5.gameObject.layer = 7;
        magician.golem.wk6.gameObject.layer = 7;
        magician.golem.wk7.gameObject.layer = 7;
        magician.golem.ak1_1.gameObject.layer = 7;
        magician.golem.ak1_2.gameObject.layer = 7;
        magician.golem.ak1_3.gameObject.layer = 7;
        magician.golem.ak2_1.gameObject.layer = 7;
        magician.golem.ak2_2.gameObject.layer = 7;
        magician.golem.ak2_3.gameObject.layer = 7;
        magician.golem.ak3_1.gameObject.layer = 7;
        magician.golem.ak3_2.gameObject.layer = 7;
        magician.golem.ak3_3.gameObject.layer = 7;

        magician.golem.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void Shield_Golem()
    {

    }
    //슬라임한테 공격 받았을 때
    void Attack_Magician_Slime()
    {
        magician.slime.damage_label.text = Data.Instance.gameData.magician_damage.ToString();
        magician.slime.slime_hp -= Data.Instance.gameData.magician_damage;
        magician.slime.gameObject.layer = 8;
        magician.slime.st1.gameObject.layer = 8;
        magician.slime.st2.gameObject.layer = 8;
        magician.slime.wk1.gameObject.layer = 8;
        magician.slime.wk2.gameObject.layer = 8;
        magician.slime.ak1.gameObject.layer = 8;
        magician.slime.ak2.gameObject.layer = 8;
        magician.slime.ak3.gameObject.layer = 8;
        magician.slime.ak4.gameObject.layer = 8;
        magician.slime.ak5.gameObject.layer = 8;
        magician.slime.ak6.gameObject.layer = 8;
        magician.slime.sk1.gameObject.layer = 8;

        magician.slime.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = magician.slime.transform.position.x - transform.position.x > 0 ? 1 : -1;
        magician.slime.rigid.AddForce(new Vector2(dirc, 0f) * 20f, ForceMode2D.Impulse);

        Invoke("offBackSlime", 0.2f);
        Invoke("offDamageSlime", 1.2f);
    }
    public void offBackSlime()
    {
        magician.slime.rigid.velocity = Vector3.zero;
    }
    public void offDamageSlime()
    {
        magician.slime.damage_label.text = null;
        magician.slime.gameObject.layer = 7;
        magician.slime.gameObject.layer = 7;
        magician.slime.st1.gameObject.layer = 7;
        magician.slime.st2.gameObject.layer = 7;
        magician.slime.wk1.gameObject.layer = 7;
        magician.slime.wk2.gameObject.layer = 7;
        magician.slime.ak1.gameObject.layer = 7;
        magician.slime.ak2.gameObject.layer = 7;
        magician.slime.ak3.gameObject.layer = 7;
        magician.slime.ak4.gameObject.layer = 7;
        magician.slime.ak5.gameObject.layer = 7;
        magician.slime.ak6.gameObject.layer = 7;
        magician.slime.sk1.gameObject.layer = 7;
        magician.slime.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    //사신
    void Attack_Magician_Reaper()
    {
        magician.reaper.damage_label.text = Data.Instance.gameData.magician_damage.ToString();
        magician.reaper.reaper_hp -= Data.Instance.gameData.magician_damage;
        magician.reaper.gameObject.layer = 8;
        magician.reaper.st1.gameObject.layer = 8;
        magician.reaper.st2.gameObject.layer = 8;
        magician.reaper.st3.gameObject.layer = 8;
        magician.reaper.st4.gameObject.layer = 8;
        magician.reaper.ak1_1.gameObject.layer = 8;
        magician.reaper.ak1_2.gameObject.layer = 8;
        magician.reaper.ak1_3.gameObject.layer = 8;
        magician.reaper.ak2_1.gameObject.layer = 8;
        magician.reaper.ak2_2.gameObject.layer = 8;
        magician.reaper.ak2_3.gameObject.layer = 8;



        magician.reaper.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = magician.reaper.transform.position.x - transform.position.x > 0 ? 1 : -1;
        magician.reaper.rigid.AddForce(new Vector2(dirc, 0f) * 30f, ForceMode2D.Impulse);

        Invoke("offBackReaper", 0.2f);
        Invoke("offDamageReaper", 1.2f);
    }
    public void offBackReaper()
    {
        magician.reaper.rigid.velocity = Vector3.zero;
    }
    public void offDamageReaper()
    {
        magician.reaper.damage_label.text = null;
        magician.reaper.gameObject.layer = 7;
        magician.reaper.st1.gameObject.layer = 7;
        magician.reaper.st2.gameObject.layer = 7;
        magician.reaper.st3.gameObject.layer = 7;
        magician.reaper.st4.gameObject.layer = 7;
        magician.reaper.ak1_1.gameObject.layer = 7;
        magician.reaper.ak1_2.gameObject.layer = 7;
        magician.reaper.ak1_3.gameObject.layer = 7;
        magician.reaper.ak2_1.gameObject.layer = 7;
        magician.reaper.ak2_2.gameObject.layer = 7;
        magician.reaper.ak2_3.gameObject.layer = 7;
        magician.reaper.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
