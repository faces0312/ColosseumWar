using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Copy : MonoBehaviour
{
    //보스 프리팹
    public GameObject warrior_prefab;
    public GameObject valkyrie_prefab;
    public GameObject assassin_prefab;
    public GameObject mage_prefab;
    //잡몹 프리팹
    public GameObject thief_prefab;
    public GameObject michael_prefab;
    public GameObject monk_prefab;
    public GameObject pirate_prefab;
    public GameObject magician_prefab;
    public GameObject archer_prefab;
    //레드존 프리팹
    public GameObject redzone_prefab;

    //몬스터 랜덤 출현
    int ran_mob1;
    int ran_mob2;
    int ran_mob3;
    int ran_boss;

    //레드존 랜덤 출현
    int ran_redzone;

    public FollowCamera attack_zone;

    void Start()
    {
        Invoke("mobGen", 8f);
        Invoke("bossGen", 60f);
        Invoke("redzoneGen", 10f);
    }
    public void mobGen()
    {
        ran_mob1 = Random.Range(1, 7);
        ran_mob2 = Random.Range(1, 7);
        ran_mob3 = Random.Range(1, 7);
        if (ran_mob1==1)
        {
            Instantiate(thief_prefab,new Vector3(-28f,0f),Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_mob1 == 2)
        {
            Instantiate(michael_prefab, new Vector3(-28f, 0f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_mob1 == 3)
        {
            Instantiate(monk_prefab, new Vector3(-28f, 0f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_mob1 == 4)
        {
            Instantiate(pirate_prefab, new Vector3(-28f, 0f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_mob1 == 5)
        {
            Instantiate(magician_prefab, new Vector3(-28f, 0f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_mob1 == 6)
        {
            Instantiate(archer_prefab, new Vector3(-28f, 0f), Quaternion.identity);
            attack_zone.death_cnt++;
        }


        if (ran_mob2 == 1)
        {
            Instantiate(thief_prefab, new Vector3(28f, 0f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_mob2 == 2)
        {
            Instantiate(michael_prefab, new Vector3(28f, 0f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_mob2 == 3)
        {
            Instantiate(monk_prefab, new Vector3(28f, 0f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_mob2 == 4)
        {
            Instantiate(pirate_prefab, new Vector3(28f, 0f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_mob2 == 5)
        {
            Instantiate(magician_prefab, new Vector3(28f, 0f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_mob2 == 6)
        {
            Instantiate(archer_prefab, new Vector3(28f, 0f), Quaternion.identity);
            attack_zone.death_cnt++;
        }


        if (ran_mob3 == 1)
        {
            Instantiate(thief_prefab, new Vector3(0f, -15f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_mob3 == 2)
        {
            Instantiate(michael_prefab, new Vector3(0f, -15f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_mob3 == 3)
        {
            Instantiate(monk_prefab, new Vector3(0f, -15f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_mob3 == 4)
        {
            Instantiate(pirate_prefab, new Vector3(0f, -15f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_mob3 == 5)
        {
            Instantiate(magician_prefab, new Vector3(0f, -15f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_mob3 == 6)
        {
            Instantiate(archer_prefab, new Vector3(0f, -15f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        Invoke("mobGen", 8f);
    }
    public void bossGen()
    {
        ran_boss = Random.Range(1, 5);
        if (ran_boss == 1)
        {
            attack_zone.warrior.gameObject.SetActive(true);
            Instantiate(warrior_prefab, new Vector3(0f, 15f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_boss == 2)
        {
            attack_zone.valkyrie.gameObject.SetActive(true);
            Instantiate(valkyrie_prefab, new Vector3(0f, 15f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_boss == 3)
        {
            attack_zone.assassin.gameObject.SetActive(true);
            Instantiate(assassin_prefab, new Vector3(0f, 15f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        else if (ran_boss == 4)
        {
            attack_zone.mage.gameObject.SetActive(true);
            Instantiate(mage_prefab, new Vector3(0f, 15f), Quaternion.identity);
            attack_zone.death_cnt++;
        }
        //증가량
        Data.Instance.gameData.michael_hp += 5;
        Data.Instance.gameData.michael_damage += 3;
        Data.Instance.gameData.michael_speed += 1;

        Data.Instance.gameData.monk_hp += 5;
        Data.Instance.gameData.monk_damage += 3;
        Data.Instance.gameData.monk_speed += 1;

        Data.Instance.gameData.thief_hp += 5;
        Data.Instance.gameData.thief_damage += 3;
        Data.Instance.gameData.thief_speed += 1;

        Data.Instance.gameData.archer_hp += 5;
        Data.Instance.gameData.archer_damage += 3;
        Data.Instance.gameData.archer_speed += 1;

        Data.Instance.gameData.magician_hp += 5;
        Data.Instance.gameData.magician_damage += 3;
        Data.Instance.gameData.magician_speed += 1;

        Data.Instance.gameData.pirate_hp += 5;
        Data.Instance.gameData.pirate_damage += 3;
        Data.Instance.gameData.pirate_speed += 1;

        Data.Instance.gameData.warrior_hp += 15;
        Data.Instance.gameData.warrior_damage += 5;
        Data.Instance.gameData.warrior_skill_damage += 5;
        Data.Instance.gameData.warrior_speed += 1;

        Data.Instance.gameData.valkyrie_hp += 15;
        Data.Instance.gameData.valkyrie_damage += 5;
        Data.Instance.gameData.valkyrie_skill_damage += 5;
        Data.Instance.gameData.valkyrie_speed += 1;

        Data.Instance.gameData.assassin_hp += 15;
        Data.Instance.gameData.assassin_damage += 5;
        Data.Instance.gameData.assassin_skill_damage += 5;
        Data.Instance.gameData.assassin_speed += 1;

        Data.Instance.gameData.mage_hp += 15;
        Data.Instance.gameData.mage_damage += 5;
        Data.Instance.gameData.mage_speed += 1;
        Invoke("bossGen", 60f);
    }
    
    public void redzoneGen()
    {
        ran_redzone = Random.Range(1, 11);
        if (ran_redzone == 1)
        {
            Instantiate(redzone_prefab, new Vector3(0f, 0f), Quaternion.identity);
        }
        else if (ran_redzone == 2)
        {
            Instantiate(redzone_prefab, new Vector3(10f, 6f), Quaternion.identity);
        }
        else if (ran_redzone == 3)
        {
            Instantiate(redzone_prefab, new Vector3(-10f, 6f), Quaternion.identity);
        }
        else if (ran_redzone == 4)
        {
            Instantiate(redzone_prefab, new Vector3(-22f, 1.8f), Quaternion.identity);
        }
        else if (ran_redzone == 5)
        {
            Instantiate(redzone_prefab, new Vector3(24f, -1.8f), Quaternion.identity);
        }
        else if (ran_redzone == 6)
        {
            Instantiate(redzone_prefab, new Vector3(12f, -7f), Quaternion.identity);
        }
        else if (ran_redzone == 7)
        {
            Instantiate(redzone_prefab, new Vector3(-12f, -7f), Quaternion.identity);
        }
        else if (ran_redzone == 8)
        {
            Instantiate(redzone_prefab, new Vector3(12f, 2f), Quaternion.identity);
        }
        else if (ran_redzone == 9)
        {
            Instantiate(redzone_prefab, new Vector3(-12f, -2f), Quaternion.identity);
        }
        else if (ran_redzone == 10)
        {
            Instantiate(redzone_prefab, new Vector3(0f, -6f), Quaternion.identity);
        }

        Invoke("redzoneGen", 30f);
    }
}
