using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
    public float dis_time;

    public bool is_RedZone;
    public float RedZone_Time=3f;
    public float in_RedZone;

    public Character wolf;
    public Skeleton skeleton;
    public Slime_In slime;
    public Golem golem;
    public Reaper reaper;

    public FollowCamera attack_zone;

    private void Start()
    {
        wolf = GameObject.Find("Unit").transform.Find("Player").GetComponent<Character>();
        skeleton = GameObject.Find("Unit").transform.Find("Player_Skeleton").GetComponent<Skeleton>();
        attack_zone = GameObject.Find("Main Camera").GetComponent<FollowCamera>();
        golem = GameObject.Find("Unit").transform.Find("Golem").GetComponent<Golem>();
        slime = GameObject.Find("Unit").transform.Find("Slime").GetComponent<Slime_In>();
        reaper = GameObject.Find("Unit").transform.Find("Reaper").GetComponent<Reaper>();

        is_RedZone = false;
        in_RedZone = 0f;
    }

    private void Update()
    {
        if (in_RedZone >= RedZone_Time)
        {
            if (wolf.gameObject.activeSelf == true)
                wolf.wolf_hp -= 5;
            else if (skeleton.gameObject.activeSelf == true)
                skeleton.skeleton_hp -= 5;
            else if (slime.gameObject.activeSelf == true)
                slime.slime_hp -= 5;
            else if (golem.gameObject.activeSelf == true)
                golem.golem_hp -= 5;
            else if (reaper.gameObject.activeSelf == true)
                reaper.reaper_hp -= 5;

            attack_zone.redzone_effect.gameObject.SetActive(false);
            in_RedZone = 0f;
            is_RedZone = false;
        }
        if (dis_time>10f)
        {
            if(attack_zone.redzone_effect.activeSelf==true)
            {
                if (wolf.gameObject.activeSelf == true)
                    wolf.wolf_hp -= 5;
                else if (skeleton.gameObject.activeSelf == true)
                    skeleton.skeleton_hp -= 5;
                else if (slime.gameObject.activeSelf == true)
                    slime.slime_hp -= 5;
                else if (golem.gameObject.activeSelf == true)
                    golem.golem_hp -= 5;
                else if (reaper.gameObject.activeSelf == true)
                    reaper.reaper_hp -= 5;

                attack_zone.redzone_effect.gameObject.SetActive(false);
            }
            in_RedZone = 0f;
            is_RedZone = false;

            Destroy(gameObject);
        }

        dis_time += Time.deltaTime;

        if (is_RedZone == true)
        {
            attack_zone.redzone_effect.gameObject.SetActive(true);

            in_RedZone += Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Skeleton" || collision.tag == "Golem" 
            || collision.tag == "Slime" || collision.tag == "Reaper")
        {
            is_RedZone = true;
        }
    }
    
}
