using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_Effect : MonoBehaviour
{
    public Archer archer;
    public bool atk_end;//맞으면 공격 끝
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Archer")
        {
            archer.hit.Play();
            archer.ef1.enabled = false;

            atk_end = true;
            if(archer.attack_zone.gm.shield_cnt<1)
                Attack_Archer();
            else
            {
                archer.attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Skeleton" && gameObject.tag == "Archer")
        {
            archer.hit.Play();
            archer.ef1.enabled = false;

            atk_end = true;
            if (archer.attack_zone.gm.shield_cnt < 1)
                Attack_Archer_Skeleton();
            else
            {
                archer.attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Golem" && gameObject.tag == "Archer")
        {
            archer.hit.Play();
            archer.ef1.enabled = false;

            atk_end = true;
            if (archer.golem.skillEffect.activeSelf == false && archer.attack_zone.gm.shield_cnt < 1)
                Attack_Archer_Golem();
            else if (archer.attack_zone.gm.shield_cnt >= 1 && archer.golem.skillEffect.activeSelf == false)
            {
                archer.attack_zone.gm.shield_cnt--;
            }
            if (archer.golem.skillEffect.activeSelf == true)
                Shield_Golem();
            
        }
        if (collision.gameObject.tag == "Slime" && gameObject.tag == "Archer")
        {
            archer.hit.Play();
            archer.ef1.enabled = false;

            atk_end = true;
            if (archer.slime.sk1.enabled == false && archer.attack_zone.gm.shield_cnt < 1)
                Attack_Archer_Slime();
            else  if(archer.attack_zone.gm.shield_cnt >= 1)
            {
                archer.attack_zone.gm.shield_cnt--;
            }
        }
        if (collision.gameObject.tag == "Reaper" && gameObject.tag == "Archer")
        {
            archer.hit.Play();
            archer.ef1.enabled = false;

            atk_end = true;
            if (archer.attack_zone.gm.shield_cnt < 1)
                Attack_Archer_Reaper();
            else
            {
                archer.attack_zone.gm.shield_cnt--;
            }
        }
    }

    void Attack_Archer()
    {
        archer.player_position.damage_label.text = Data.Instance.gameData.archer_damage.ToString();
        archer.player_position.wolf_hp -= Data.Instance.gameData.archer_damage;
        archer.player_position.gameObject.layer = 8;
        archer.player_position.st1.gameObject.layer = 8;
        archer.player_position.st2.gameObject.layer = 8;
        archer.player_position.wk1.gameObject.layer = 8;
        archer.player_position.wk2.gameObject.layer = 8;
        archer.player_position.ak1_1.gameObject.layer = 8;
        archer.player_position.ak1_2.gameObject.layer = 8;
        archer.player_position.ak1_3.gameObject.layer = 8;
        archer.player_position.ak2_1.gameObject.layer = 8;
        archer.player_position.ak2_2.gameObject.layer = 8;
        archer.player_position.ak2_3.gameObject.layer = 8;
        archer.player_position.ak3_1.gameObject.layer = 8;
        archer.player_position.ak3_2.gameObject.layer = 8;
        archer.player_position.ak3_3.gameObject.layer = 8;

        archer.player_position.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = archer.player_position.transform.position.x - transform.position.x > 0 ? 1 : -1;
        archer.player_position.rigid.AddForce(new Vector2(dirc, 0f) * 30f, ForceMode2D.Impulse);

        Invoke("offBack", 0.2f);
        Invoke("offDamage", 1.2f);
    }
    public void offBack()
    {
        archer.player_position.rigid.velocity = Vector3.zero;
    }
    public void offDamage()
    {
        archer.player_position.damage_label.text = null;
        archer.player_position.gameObject.layer = 7;
        archer.player_position.st1.gameObject.layer = 7;
        archer.player_position.st2.gameObject.layer = 7;
        archer.player_position.wk1.gameObject.layer = 7;
        archer.player_position.wk2.gameObject.layer = 7;
        archer.player_position.ak1_1.gameObject.layer = 7;
        archer.player_position.ak1_2.gameObject.layer = 7;
        archer.player_position.ak1_3.gameObject.layer = 7;
        archer.player_position.ak2_1.gameObject.layer = 7;
        archer.player_position.ak2_2.gameObject.layer = 7;
        archer.player_position.ak2_3.gameObject.layer = 7;
        archer.player_position.ak3_1.gameObject.layer = 7;
        archer.player_position.ak3_2.gameObject.layer = 7;
        archer.player_position.ak3_3.gameObject.layer = 7;
        archer.player_position.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void Attack_Archer_Skeleton()
    {
        archer.skeleton.damage_label.text = Data.Instance.gameData.archer_damage.ToString();
        archer.skeleton.skeleton_hp -= Data.Instance.gameData.archer_damage;
        archer.skeleton.gameObject.layer = 8;
        archer.skeleton.st1.gameObject.layer = 8;
        archer.skeleton.st2.gameObject.layer = 8;
        archer.skeleton.wk1.gameObject.layer = 8;
        archer.skeleton.wk2.gameObject.layer = 8;
        archer.skeleton.wk3.gameObject.layer = 8;
        archer.skeleton.wk4.gameObject.layer = 8;
        archer.skeleton.ak1_1.gameObject.layer = 8;
        archer.skeleton.ak1_2.gameObject.layer = 8;
        archer.skeleton.ak1_3.gameObject.layer = 8;
        archer.skeleton.ak2_1.gameObject.layer = 8;
        archer.skeleton.ak2_2.gameObject.layer = 8;
        archer.skeleton.ak2_3.gameObject.layer = 8;
        archer.skeleton.ak3_1.gameObject.layer = 8;
        archer.skeleton.ak3_2.gameObject.layer = 8;
        archer.skeleton.ak3_3.gameObject.layer = 8;
        archer.skeleton.ak3_4.gameObject.layer = 8;
        archer.skeleton.ak3_5.gameObject.layer = 8;
        archer.skeleton.ak3_6.gameObject.layer = 8;
        archer.skeleton.ak3_7.gameObject.layer = 8;
        

        archer.skeleton.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = archer.skeleton.transform.position.x - transform.position.x > 0 ? 1 : -1;
        archer.skeleton.rigid.AddForce(new Vector2(dirc, 0f) * 30f, ForceMode2D.Impulse);

        Invoke("offBackSkeleton", 0.2f);
        Invoke("offDamageSkeleton", 1.2f);
    }
    public void offBackSkeleton()
    {
        archer.skeleton.rigid.velocity = Vector3.zero;
    }
    public void offDamageSkeleton()
    {
        archer.skeleton.damage_label.text = null;
        archer.skeleton.gameObject.layer = 7;
        archer.skeleton.st1.gameObject.layer = 7;
        archer.skeleton.st2.gameObject.layer = 7;
        archer.skeleton.wk1.gameObject.layer = 7;
        archer.skeleton.wk2.gameObject.layer = 7;
        archer.skeleton.wk3.gameObject.layer = 7;
        archer.skeleton.wk4.gameObject.layer = 7;
        archer.skeleton.ak1_1.gameObject.layer = 7;
        archer.skeleton.ak1_2.gameObject.layer = 7;
        archer.skeleton.ak1_3.gameObject.layer = 7;
        archer.skeleton.ak2_1.gameObject.layer = 7;
        archer.skeleton.ak2_2.gameObject.layer = 7;
        archer.skeleton.ak2_3.gameObject.layer = 7;
        archer.skeleton.ak3_1.gameObject.layer = 7;
        archer.skeleton.ak3_2.gameObject.layer = 7;
        archer.skeleton.ak3_3.gameObject.layer = 7;
        archer.skeleton.ak3_4.gameObject.layer = 7;
        archer.skeleton.ak3_5.gameObject.layer = 7;
        archer.skeleton.ak3_6.gameObject.layer = 7;
        archer.skeleton.ak3_7.gameObject.layer = 7;
        archer.skeleton.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void Attack_Archer_Golem()
    {
        archer.golem.damage_label.text = Data.Instance.gameData.archer_damage.ToString();
        archer.golem.golem_hp -= Data.Instance.gameData.archer_damage;
        archer.golem.gameObject.layer = 8;
        archer.golem.st1.gameObject.layer = 8;
        archer.golem.st2.gameObject.layer = 8;
        archer.golem.wk1.gameObject.layer = 8;
        archer.golem.wk2.gameObject.layer = 8;
        archer.golem.wk3.gameObject.layer = 8;
        archer.golem.wk4.gameObject.layer = 8;
        archer.golem.wk5.gameObject.layer = 8;
        archer.golem.wk6.gameObject.layer = 8;
        archer.golem.wk7.gameObject.layer = 8;
        archer.golem.ak1_1.gameObject.layer = 8;
        archer.golem.ak1_2.gameObject.layer = 8;
        archer.golem.ak1_3.gameObject.layer = 8;
        archer.golem.ak2_1.gameObject.layer = 8;
        archer.golem.ak2_2.gameObject.layer = 8;
        archer.golem.ak2_3.gameObject.layer = 8;
        archer.golem.ak3_1.gameObject.layer = 8;
        archer.golem.ak3_2.gameObject.layer = 8;
        archer.golem.ak3_3.gameObject.layer = 8;

        archer.golem.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = archer.golem.transform.position.x - transform.position.x > 0 ? 1 : -1;
        archer.golem.rigid.AddForce(new Vector2(dirc, 0f) * 30f, ForceMode2D.Impulse);

        Invoke("offBackGolem", 0.2f);
        Invoke("offDamageGolem", 1.2f);
    }
    public void offBackGolem()
    {
        archer.golem.rigid.velocity = Vector3.zero;
    }
    public void offDamageGolem()
    {
        archer.golem.damage_label.text = null;
        archer.golem.gameObject.layer = 7;
        archer.golem.st1.gameObject.layer = 7;
        archer.golem.st2.gameObject.layer = 7;
        archer.golem.wk1.gameObject.layer = 7;
        archer.golem.wk2.gameObject.layer = 7;
        archer.golem.wk3.gameObject.layer = 7;
        archer.golem.wk4.gameObject.layer = 7;
        archer.golem.wk5.gameObject.layer = 7;
        archer.golem.wk6.gameObject.layer = 7;
        archer.golem.wk7.gameObject.layer = 7;
        archer.golem.ak1_1.gameObject.layer = 7;
        archer.golem.ak1_2.gameObject.layer = 7;
        archer.golem.ak1_3.gameObject.layer = 7;
        archer.golem.ak2_1.gameObject.layer = 7;
        archer.golem.ak2_2.gameObject.layer = 7;
        archer.golem.ak2_3.gameObject.layer = 7;
        archer.golem.ak3_1.gameObject.layer = 7;
        archer.golem.ak3_2.gameObject.layer = 7;
        archer.golem.ak3_3.gameObject.layer = 7;

        archer.golem.spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void Shield_Golem()
    {
        
    }
    //슬라임한테 공격 받았을 때
    void Attack_Archer_Slime()
    {
        archer.slime.damage_label.text = Data.Instance.gameData.archer_damage.ToString();
        archer.slime.slime_hp -= Data.Instance.gameData.archer_damage;
        archer.slime.gameObject.layer = 8;
        archer.slime.st1.gameObject.layer = 8;
        archer.slime.st2.gameObject.layer = 8;
        archer.slime.wk1.gameObject.layer = 8;
        archer.slime.wk2.gameObject.layer = 8;
        archer.slime.ak1.gameObject.layer = 8;
        archer.slime.ak2.gameObject.layer = 8;
        archer.slime.ak3.gameObject.layer = 8;
        archer.slime.ak4.gameObject.layer = 8;
        archer.slime.ak5.gameObject.layer = 8;
        archer.slime.ak6.gameObject.layer = 8;
        archer.slime.sk1.gameObject.layer = 8;

        archer.slime.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = archer.slime.transform.position.x - transform.position.x > 0 ? 1 : -1;
        archer.slime.rigid.AddForce(new Vector2(dirc, 0f) * 20f, ForceMode2D.Impulse);

        Invoke("offBackSlime", 0.2f);
        Invoke("offDamageSlime", 1.2f);
    }
    public void offBackSlime()
    {
        archer.slime.rigid.velocity = Vector3.zero;
    }
    public void offDamageSlime()
    {
        archer.slime.damage_label.text = null;
        archer.slime.gameObject.layer = 7;
        archer.slime.gameObject.layer = 7;
        archer.slime.st1.gameObject.layer = 7;
        archer.slime.st2.gameObject.layer = 7;
        archer.slime.wk1.gameObject.layer = 7;
        archer.slime.wk2.gameObject.layer = 7;
        archer.slime.ak1.gameObject.layer = 7;
        archer.slime.ak2.gameObject.layer = 7;
        archer.slime.ak3.gameObject.layer = 7;
        archer.slime.ak4.gameObject.layer = 7;
        archer.slime.ak5.gameObject.layer = 7;
        archer.slime.ak6.gameObject.layer = 7;
        archer.slime.sk1.gameObject.layer = 7;
        archer.slime.spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    //사신
    void Attack_Archer_Reaper()
    {
        archer.reaper.damage_label.text = Data.Instance.gameData.archer_damage.ToString();
        archer.reaper.reaper_hp -= Data.Instance.gameData.archer_damage;
        archer.reaper.gameObject.layer = 8;
        archer.reaper.st1.gameObject.layer = 8;
        archer.reaper.st2.gameObject.layer = 8;
        archer.reaper.st3.gameObject.layer = 8;
        archer.reaper.st4.gameObject.layer = 8;
        archer.reaper.ak1_1.gameObject.layer = 8;
        archer.reaper.ak1_2.gameObject.layer = 8;
        archer.reaper.ak1_3.gameObject.layer = 8;
        archer.reaper.ak2_1.gameObject.layer = 8;
        archer.reaper.ak2_2.gameObject.layer = 8;
        archer.reaper.ak2_3.gameObject.layer = 8;
        


        archer.reaper.spriteRenderer.color = new Color(255, 0, 0, 0.8f);

        int dirc = archer.reaper.transform.position.x - transform.position.x > 0 ? 1 : -1;
        archer.reaper.rigid.AddForce(new Vector2(dirc, 0f) * 30f, ForceMode2D.Impulse);

        Invoke("offBackReaper", 0.2f);
        Invoke("offDamageReaper", 1.2f);
    }
    public void offBackReaper()
    {
        archer.reaper.rigid.velocity = Vector3.zero;
    }
    public void offDamageReaper()
    {
        archer.reaper.damage_label.text = null;
        archer.reaper.gameObject.layer = 7;
        archer.reaper.st1.gameObject.layer = 7;
        archer.reaper.st2.gameObject.layer = 7;
        archer.reaper.st3.gameObject.layer = 7;
        archer.reaper.st4.gameObject.layer = 7;
        archer.reaper.ak1_1.gameObject.layer = 7;
        archer.reaper.ak1_2.gameObject.layer = 7;
        archer.reaper.ak1_3.gameObject.layer = 7;
        archer.reaper.ak2_1.gameObject.layer = 7;
        archer.reaper.ak2_2.gameObject.layer = 7;
        archer.reaper.ak2_3.gameObject.layer = 7;
        archer.reaper.spriteRenderer.color = new Color(1, 1, 1, 1);
    }

}
