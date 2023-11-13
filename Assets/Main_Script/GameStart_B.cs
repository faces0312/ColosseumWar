using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStart_B : MonoBehaviour
{
    public GameObject[] wolf_starX=new GameObject[6];
    public GameObject[] wolf_starO = new GameObject[6];
    public GameObject[] wolf_star_red = new GameObject[6];

    public GameObject[] slime_starX = new GameObject[6];
    public GameObject[] slime_starO = new GameObject[6];
    public GameObject[] slime_star_red = new GameObject[6];

    public GameObject[] skeleton_starX = new GameObject[6];
    public GameObject[] skeleton_starO = new GameObject[6];
    public GameObject[] skeleton_star_red = new GameObject[6];

    public GameObject[] golem_starX = new GameObject[6];
    public GameObject[] golem_starO = new GameObject[6];
    public GameObject[] golem_star_red = new GameObject[6];

    public GameObject[] reaper_starX = new GameObject[6];
    public GameObject[] reaper_starO = new GameObject[6];
    public GameObject[] reaper_star_red = new GameObject[6];

    public GameObject explainpage;
    public GameObject explainbutton;
    public GameObject[] explain = new GameObject[5];
    private void Start()
    {
        if(Data.Instance.gameData.isExplain==false)
        {
            explainpage.gameObject.SetActive(true);
            explainbutton.gameObject.SetActive(true);
            for(int i=0;i<5;i++)
            {
                explain[i].gameObject.SetActive(false);
            }
        }
        else if (Data.Instance.gameData.isExplain == true)
        {
            explainpage.gameObject.SetActive(false);
            explainbutton.gameObject.SetActive(false);
            for (int i = 0; i < 5; i++)
            {
                explain[i].gameObject.SetActive(false);
            }
        }

        Data.Instance.gameData.wolf_characteristic = false;
        Data.Instance.gameData.skeleton_characteristic = false;
        Data.Instance.gameData.slime_characteristic = false;
        Data.Instance.gameData.golem_characteristic = false;
        Data.Instance.gameData.reaper_characteristic = false;
    }
    private void Update()
    {

        //·¹º§º° ´Á´ëÀÎ°£ ½ºÅÈ
        if (Data.Instance.gameData.wolf_lv == 0)
        {
            Data.Instance.gameData.wolf_characteristic = false;
            Data.Instance.gameData.wolf_hp = 50;
            Data.Instance.gameData.wolf_damage = 3;
            Data.Instance.gameData.wolf_last_damage = 5;
            Data.Instance.gameData.wolf_skill_damage = 5;
            Data.Instance.gameData.wolf_speed = 15;

            for(int i=0;i<6;i++)
            {
                wolf_starX[i].gameObject.SetActive(true);
                wolf_starO[i].gameObject.SetActive(false);
                wolf_star_red[i].gameObject.SetActive(false);
            }
        }
        else if (Data.Instance.gameData.wolf_lv == 1)
        {
            Data.Instance.gameData.wolf_characteristic = false;
            Data.Instance.gameData.wolf_damage = 6;
            Data.Instance.gameData.wolf_last_damage = 8;
            Data.Instance.gameData.wolf_hp = 50;
            Data.Instance.gameData.wolf_skill_damage = 5;
            Data.Instance.gameData.wolf_speed = 15;

            wolf_starX[0].gameObject.SetActive(false);
            wolf_starO[0].gameObject.SetActive(true);
            for (int i = 1; i < 6; i++)
            {
                wolf_starX[i].gameObject.SetActive(true);
                wolf_starO[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < 6; i++)
                wolf_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.wolf_lv == 2)
        {
            Data.Instance.gameData.wolf_characteristic = false;
            Data.Instance.gameData.wolf_hp = 60;
            Data.Instance.gameData.wolf_damage = 6;
            Data.Instance.gameData.wolf_last_damage = 8;
            Data.Instance.gameData.wolf_skill_damage = 5;
            Data.Instance.gameData.wolf_speed = 15;

            wolf_starX[0].gameObject.SetActive(false);
            wolf_starO[0].gameObject.SetActive(true);
            wolf_starX[1].gameObject.SetActive(false);
            wolf_starO[1].gameObject.SetActive(true);
            for (int i = 2; i < 6; i++)
            {
                wolf_starX[i].gameObject.SetActive(true);
                wolf_starO[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < 6; i++)
                wolf_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.wolf_lv == 3)
        {
            Data.Instance.gameData.wolf_characteristic = false;
            Data.Instance.gameData.wolf_skill_damage = 7;
            Data.Instance.gameData.wolf_hp = 60;
            Data.Instance.gameData.wolf_damage = 6;
            Data.Instance.gameData.wolf_last_damage = 8;
            Data.Instance.gameData.wolf_speed = 15;

            wolf_starX[0].gameObject.SetActive(false);
            wolf_starO[0].gameObject.SetActive(true);
            wolf_starX[1].gameObject.SetActive(false);
            wolf_starO[1].gameObject.SetActive(true);
            wolf_starX[2].gameObject.SetActive(false);
            wolf_starO[2].gameObject.SetActive(true);
            for (int i = 3; i < 6; i++)
            {
                wolf_starX[i].gameObject.SetActive(true);
                wolf_starO[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < 6; i++)
                wolf_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.wolf_lv == 4)
        {
            Data.Instance.gameData.wolf_characteristic = false;
            Data.Instance.gameData.wolf_speed = 20;
            Data.Instance.gameData.wolf_skill_damage = 7;
            Data.Instance.gameData.wolf_hp = 60;
            Data.Instance.gameData.wolf_damage = 6;
            Data.Instance.gameData.wolf_last_damage = 8;
            wolf_starX[0].gameObject.SetActive(false);
            wolf_starO[0].gameObject.SetActive(true);
            wolf_starX[1].gameObject.SetActive(false);
            wolf_starO[1].gameObject.SetActive(true);
            wolf_starX[2].gameObject.SetActive(false);
            wolf_starO[2].gameObject.SetActive(true);
            wolf_starX[3].gameObject.SetActive(false);
            wolf_starO[3].gameObject.SetActive(true);
            for (int i = 4; i < 6; i++)
            {
                wolf_starX[i].gameObject.SetActive(true);
                wolf_starO[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < 6; i++)
                wolf_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.wolf_lv == 5)
        {
            Data.Instance.gameData.wolf_characteristic = false;
            Data.Instance.gameData.wolf_damage = 9;
            Data.Instance.gameData.wolf_last_damage = 11;
            Data.Instance.gameData.wolf_speed = 20;
            Data.Instance.gameData.wolf_skill_damage = 7;
            Data.Instance.gameData.wolf_hp = 60;
            wolf_starX[0].gameObject.SetActive(false);
            wolf_starO[0].gameObject.SetActive(true);
            wolf_starX[1].gameObject.SetActive(false);
            wolf_starO[1].gameObject.SetActive(true);
            wolf_starX[2].gameObject.SetActive(false);
            wolf_starO[2].gameObject.SetActive(true);
            wolf_starX[3].gameObject.SetActive(false);
            wolf_starO[3].gameObject.SetActive(true);
            wolf_starX[4].gameObject.SetActive(false);
            wolf_starO[4].gameObject.SetActive(true);
            for (int i = 5; i < 6; i++)
            {
                wolf_starX[i].gameObject.SetActive(true);
                wolf_starO[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < 6; i++)
                wolf_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.wolf_lv == 6)
        {
            Data.Instance.gameData.wolf_characteristic = false;
            Data.Instance.gameData.wolf_hp = 80;
            Data.Instance.gameData.wolf_damage = 9;
            Data.Instance.gameData.wolf_last_damage = 11;
            Data.Instance.gameData.wolf_speed = 20;
            Data.Instance.gameData.wolf_skill_damage = 7;
            for (int i = 0; i < 6; i++)
            {
                wolf_starX[i].gameObject.SetActive(false);
                wolf_starO[i].gameObject.SetActive(true);
            }
            for (int i = 0; i < 6; i++)
                wolf_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.wolf_lv == 7)
        {
            Data.Instance.gameData.wolf_characteristic = true;
            Data.Instance.gameData.wolf_hp = 80;
            Data.Instance.gameData.wolf_damage = 9;
            Data.Instance.gameData.wolf_last_damage = 11;
            Data.Instance.gameData.wolf_speed = 20;
            Data.Instance.gameData.wolf_skill_damage = 7;
            for (int i = 0; i < 6; i++)
            {
                wolf_starX[i].gameObject.SetActive(false);
                wolf_starO[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < 6; i++)
                wolf_star_red[i].gameObject.SetActive(true);
        }


        //·¹º§º° ½ºÄÌ·¹Åæ ½ºÅÈ
        if (Data.Instance.gameData.skeleton_lv == 0)
        {
            Data.Instance.gameData.skeleton_characteristic = false;
            Data.Instance.gameData.skeleton_hp = 45;
            Data.Instance.gameData.skeleton_damage = 5;
            Data.Instance.gameData.skeleton_last_damage = 9;
            Data.Instance.gameData.skeleton_skill_damage = 6;
            Data.Instance.gameData.skeleton_speed = 13;

            for (int i = 0; i < 6; i++)
            {
                skeleton_starX[i].gameObject.SetActive(true);
                skeleton_starO[i].gameObject.SetActive(false);
                skeleton_star_red[i].gameObject.SetActive(false);
            }
        }
        else if (Data.Instance.gameData.skeleton_lv == 1)
        {
            Data.Instance.gameData.skeleton_characteristic = false;
            Data.Instance.gameData.skeleton_damage = 8;
            Data.Instance.gameData.skeleton_last_damage = 12;

            skeleton_starX[0].gameObject.SetActive(false);
            skeleton_starO[0].gameObject.SetActive(true);
            for (int i = 1; i < 6; i++)
            {
                skeleton_starX[i].gameObject.SetActive(true);
                skeleton_starO[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < 6; i++)
                skeleton_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.skeleton_lv == 2)
        {
            Data.Instance.gameData.skeleton_characteristic = false;
            Data.Instance.gameData.skeleton_hp = 55;
            Data.Instance.gameData.skeleton_damage = 8;
            Data.Instance.gameData.skeleton_last_damage = 12;
            skeleton_starX[0].gameObject.SetActive(false);
            skeleton_starO[0].gameObject.SetActive(true);
            skeleton_starX[1].gameObject.SetActive(false);
            skeleton_starO[1].gameObject.SetActive(true);
            for (int i = 2; i < 6; i++)
            {
                skeleton_starX[i].gameObject.SetActive(true);
                skeleton_starO[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < 6; i++)
                skeleton_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.skeleton_lv == 3)
        {
            Data.Instance.gameData.skeleton_characteristic = false;
            Data.Instance.gameData.skeleton_skill_damage = 10;
            Data.Instance.gameData.skeleton_hp = 55;
            Data.Instance.gameData.skeleton_damage = 8;
            Data.Instance.gameData.skeleton_last_damage = 12;
            skeleton_starX[0].gameObject.SetActive(false);
            skeleton_starO[0].gameObject.SetActive(true);
            skeleton_starX[1].gameObject.SetActive(false);
            skeleton_starO[1].gameObject.SetActive(true);
            skeleton_starX[2].gameObject.SetActive(false);
            skeleton_starO[2].gameObject.SetActive(true);
            for (int i = 3; i < 6; i++)
            {
                skeleton_starX[i].gameObject.SetActive(true);
                skeleton_starO[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < 6; i++)
                skeleton_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.skeleton_lv == 4)
        {
            Data.Instance.gameData.skeleton_characteristic = false;
            Data.Instance.gameData.skeleton_speed = 18;
            Data.Instance.gameData.skeleton_skill_damage = 10;
            Data.Instance.gameData.skeleton_hp = 55;
            Data.Instance.gameData.skeleton_damage = 8;
            Data.Instance.gameData.skeleton_last_damage = 12;
            skeleton_starX[0].gameObject.SetActive(false);
            skeleton_starO[0].gameObject.SetActive(true);
            skeleton_starX[1].gameObject.SetActive(false);
            skeleton_starO[1].gameObject.SetActive(true);
            skeleton_starX[2].gameObject.SetActive(false);
            skeleton_starO[2].gameObject.SetActive(true);
            skeleton_starX[3].gameObject.SetActive(false);
            skeleton_starO[3].gameObject.SetActive(true);
            for (int i = 4; i < 6; i++)
            {
                skeleton_starX[i].gameObject.SetActive(true);
                skeleton_starO[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < 6; i++)
                skeleton_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.skeleton_lv == 5)
        {
            Data.Instance.gameData.skeleton_characteristic = false;
            Data.Instance.gameData.skeleton_damage = 11;
            Data.Instance.gameData.skeleton_last_damage = 15;
            Data.Instance.gameData.skeleton_speed = 18;
            Data.Instance.gameData.skeleton_skill_damage = 10;
            Data.Instance.gameData.skeleton_hp = 55;
            skeleton_starX[0].gameObject.SetActive(false);
            skeleton_starO[0].gameObject.SetActive(true);
            skeleton_starX[1].gameObject.SetActive(false);
            skeleton_starO[1].gameObject.SetActive(true);
            skeleton_starX[2].gameObject.SetActive(false);
            skeleton_starO[2].gameObject.SetActive(true);
            skeleton_starX[3].gameObject.SetActive(false);
            skeleton_starO[3].gameObject.SetActive(true);
            skeleton_starX[4].gameObject.SetActive(false);
            skeleton_starO[4].gameObject.SetActive(true);
            for (int i = 5; i < 6; i++)
            {
                skeleton_starX[i].gameObject.SetActive(true);
                skeleton_starO[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < 6; i++)
                skeleton_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.skeleton_lv == 6)
        {
            Data.Instance.gameData.skeleton_characteristic = false;
            Data.Instance.gameData.skeleton_hp = 75;
            Data.Instance.gameData.skeleton_damage = 11;
            Data.Instance.gameData.skeleton_last_damage = 15;
            Data.Instance.gameData.skeleton_speed = 18;
            Data.Instance.gameData.skeleton_skill_damage = 10;
            for (int i = 0; i < 6; i++)
            {
                skeleton_starX[i].gameObject.SetActive(false);
                skeleton_starO[i].gameObject.SetActive(true);
            }
            for (int i = 0; i < 6; i++)
                skeleton_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.skeleton_lv == 7)
        {
            Data.Instance.gameData.skeleton_characteristic = true;
            Data.Instance.gameData.skeleton_hp = 75;
            Data.Instance.gameData.skeleton_damage = 11;
            Data.Instance.gameData.skeleton_last_damage = 15;
            Data.Instance.gameData.skeleton_speed = 18;
            Data.Instance.gameData.skeleton_skill_damage = 10;
            for (int i = 0; i < 6; i++)
            {
                skeleton_starX[i].gameObject.SetActive(false);
                skeleton_starO[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < 6; i++)
                skeleton_star_red[i].gameObject.SetActive(true);
        }

        //·¹º§º° ½½¶óÀÓ ½ºÅÈ
        if (Data.Instance.gameData.slime_lv == 0)
        {
            Data.Instance.gameData.slime_characteristic = false;
            Data.Instance.gameData.slime_hp = 40;
            Data.Instance.gameData.slime_damage = 8;
            Data.Instance.gameData.sllime_skill_damage = 10;
            Data.Instance.gameData.slime_speed = 16;

            for (int i = 0; i < 6; i++)
            {
                slime_starX[i].gameObject.SetActive(true);
                slime_starO[i].gameObject.SetActive(false);
                slime_star_red[i].gameObject.SetActive(false);
            }
        }
        else if (Data.Instance.gameData.slime_lv == 1)
        {
            Data.Instance.gameData.slime_characteristic = false;
            Data.Instance.gameData.slime_damage = 11;

            slime_starX[0].gameObject.SetActive(false);
            slime_starO[0].gameObject.SetActive(true);
            for (int i = 1; i < 6; i++)
            {
                slime_starX[i].gameObject.SetActive(true);
                slime_starO[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < 6; i++)
                slime_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.slime_lv == 2)
        {
            Data.Instance.gameData.slime_characteristic = false;
            Data.Instance.gameData.slime_hp = 50;
            Data.Instance.gameData.slime_damage = 11;
            slime_starX[0].gameObject.SetActive(false);
            slime_starO[0].gameObject.SetActive(true);
            slime_starX[1].gameObject.SetActive(false);
            slime_starO[1].gameObject.SetActive(true);
            for (int i = 2; i < 6; i++)
            {
                slime_starX[i].gameObject.SetActive(true);
                slime_starO[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < 6; i++)
                slime_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.slime_lv == 3)
        {
            Data.Instance.gameData.slime_characteristic = false;
            Data.Instance.gameData.sllime_skill_damage = 14;
            Data.Instance.gameData.slime_hp = 50;
            Data.Instance.gameData.slime_damage = 11;
            slime_starX[0].gameObject.SetActive(false);
            slime_starO[0].gameObject.SetActive(true);
            slime_starX[1].gameObject.SetActive(false);
            slime_starO[1].gameObject.SetActive(true);
            slime_starX[2].gameObject.SetActive(false);
            slime_starO[2].gameObject.SetActive(true);
            for (int i = 3; i < 6; i++)
            {
                slime_starX[i].gameObject.SetActive(true);
                slime_starO[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < 6; i++)
                slime_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.slime_lv == 4)
        {
            Data.Instance.gameData.slime_characteristic = false;
            Data.Instance.gameData.slime_speed = 21;
            Data.Instance.gameData.sllime_skill_damage = 14;
            Data.Instance.gameData.slime_hp = 50;
            Data.Instance.gameData.slime_damage = 11;
            slime_starX[0].gameObject.SetActive(false);
            slime_starO[0].gameObject.SetActive(true);
            slime_starX[1].gameObject.SetActive(false);
            slime_starO[1].gameObject.SetActive(true);
            slime_starX[2].gameObject.SetActive(false);
            slime_starO[2].gameObject.SetActive(true);
            slime_starX[3].gameObject.SetActive(false);
            slime_starO[3].gameObject.SetActive(true);
            for (int i = 4; i < 6; i++)
            {
                slime_starX[i].gameObject.SetActive(true);
                slime_starO[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < 6; i++)
                slime_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.slime_lv == 5)
        {
            Data.Instance.gameData.slime_characteristic = false;
            Data.Instance.gameData.slime_damage = 14;
            Data.Instance.gameData.slime_speed = 21;
            Data.Instance.gameData.sllime_skill_damage = 14;
            Data.Instance.gameData.slime_hp = 50;
            slime_starX[0].gameObject.SetActive(false);
            slime_starO[0].gameObject.SetActive(true);
            slime_starX[1].gameObject.SetActive(false);
            slime_starO[1].gameObject.SetActive(true);
            slime_starX[2].gameObject.SetActive(false);
            slime_starO[2].gameObject.SetActive(true);
            slime_starX[3].gameObject.SetActive(false);
            slime_starO[3].gameObject.SetActive(true);
            slime_starX[4].gameObject.SetActive(false);
            slime_starO[4].gameObject.SetActive(true);
            for (int i = 5; i < 6; i++)
            {
                slime_starX[i].gameObject.SetActive(true);
                slime_starO[i].gameObject.SetActive(false);
            }
        }
        else if (Data.Instance.gameData.slime_lv == 6)
        {
            Data.Instance.gameData.slime_characteristic = false;
            Data.Instance.gameData.slime_hp = 70;
            Data.Instance.gameData.slime_damage = 14;
            Data.Instance.gameData.slime_speed = 21;
            Data.Instance.gameData.sllime_skill_damage = 14;
            for (int i = 0; i < 6; i++)
            {
                slime_starX[i].gameObject.SetActive(false);
                slime_starO[i].gameObject.SetActive(true);
            }
            for (int i = 0; i < 6; i++)
                slime_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.slime_lv == 7)
        {
            Data.Instance.gameData.slime_characteristic = true;
            Data.Instance.gameData.slime_hp = 70;
            Data.Instance.gameData.slime_damage = 14;
            Data.Instance.gameData.slime_speed = 21;
            Data.Instance.gameData.sllime_skill_damage = 14;
            for (int i = 0; i < 6; i++)
            {
                slime_starX[i].gameObject.SetActive(false);
                slime_starO[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < 6; i++)
                slime_star_red[i].gameObject.SetActive(true);
        }

        //·¹º§º° °ñ·½ ½ºÅÈ
        if (Data.Instance.gameData.golem_lv == 0)
        {
            Data.Instance.gameData.golem_characteristic = false;
            Data.Instance.gameData.golem_hp = 60;
            Data.Instance.gameData.golem_damage = 8;
            Data.Instance.gameData.goelm_last_damage = 12;
            Data.Instance.gameData.golem_speed = 12;

            for (int i = 0; i < 6; i++)
            {
                golem_starX[i].gameObject.SetActive(true);
                golem_starO[i].gameObject.SetActive(false);
                golem_star_red[i].gameObject.SetActive(false);
            }
        }
        else if (Data.Instance.gameData.golem_lv == 1)
        {
            Data.Instance.gameData.golem_characteristic = false;
            Data.Instance.gameData.golem_damage = 11;
            Data.Instance.gameData.goelm_last_damage = 15;

            golem_starX[0].gameObject.SetActive(false);
            golem_starO[0].gameObject.SetActive(true);
            for (int i = 1; i < 6; i++)
            {
                golem_starX[i].gameObject.SetActive(true);
                golem_starO[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < 6; i++)
                golem_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.golem_lv == 2)
        {
            Data.Instance.gameData.golem_characteristic = false;
            Data.Instance.gameData.golem_hp = 70;
            Data.Instance.gameData.golem_damage = 11;
            Data.Instance.gameData.goelm_last_damage = 15;
            golem_starX[0].gameObject.SetActive(false);
            golem_starO[0].gameObject.SetActive(true);
            golem_starX[1].gameObject.SetActive(false);
            golem_starO[1].gameObject.SetActive(true);
            for (int i = 2; i < 6; i++)
            {
                golem_starX[i].gameObject.SetActive(true);
                golem_starO[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < 6; i++)
                golem_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.golem_lv == 3)
        {
            Data.Instance.gameData.golem_characteristic = false;
            Data.Instance.gameData.golem_hp = 80;
            Data.Instance.gameData.golem_damage = 11;
            Data.Instance.gameData.goelm_last_damage = 15;
            golem_starX[0].gameObject.SetActive(false);
            golem_starO[0].gameObject.SetActive(true);
            golem_starX[1].gameObject.SetActive(false);
            golem_starO[1].gameObject.SetActive(true);
            golem_starX[2].gameObject.SetActive(false);
            golem_starO[2].gameObject.SetActive(true);
            for (int i = 3; i < 6; i++)
            {
                golem_starX[i].gameObject.SetActive(true);
                golem_starO[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < 6; i++)
                golem_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.golem_lv == 4)
        {
            Data.Instance.gameData.golem_characteristic = false;
            Data.Instance.gameData.golem_speed = 17;
            Data.Instance.gameData.golem_hp = 80;
            Data.Instance.gameData.golem_damage = 11;
            Data.Instance.gameData.goelm_last_damage = 15;
            golem_starX[0].gameObject.SetActive(false);
            golem_starO[0].gameObject.SetActive(true);
            golem_starX[1].gameObject.SetActive(false);
            golem_starO[1].gameObject.SetActive(true);
            golem_starX[2].gameObject.SetActive(false);
            golem_starO[2].gameObject.SetActive(true);
            golem_starX[3].gameObject.SetActive(false);
            golem_starO[3].gameObject.SetActive(true);
            for (int i = 4; i < 6; i++)
            {
                golem_starX[i].gameObject.SetActive(true);
                golem_starO[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < 6; i++)
                golem_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.golem_lv == 5)
        {
            Data.Instance.gameData.golem_characteristic = false;
            Data.Instance.gameData.golem_damage = 14;
            Data.Instance.gameData.goelm_last_damage = 18;
            Data.Instance.gameData.golem_speed = 17;
            Data.Instance.gameData.golem_hp = 80;

            golem_starX[0].gameObject.SetActive(false);
            golem_starO[0].gameObject.SetActive(true);
            golem_starX[1].gameObject.SetActive(false);
            golem_starO[1].gameObject.SetActive(true);
            golem_starX[2].gameObject.SetActive(false);
            golem_starO[2].gameObject.SetActive(true);
            golem_starX[3].gameObject.SetActive(false);
            golem_starO[3].gameObject.SetActive(true);
            golem_starX[4].gameObject.SetActive(false);
            golem_starO[4].gameObject.SetActive(true);
            for (int i = 5; i < 6; i++)
            {
                golem_starX[i].gameObject.SetActive(true);
                golem_starO[i].gameObject.SetActive(false);
            }
        }
        else if (Data.Instance.gameData.golem_lv == 6)
        {
            Data.Instance.gameData.golem_characteristic = false;
            Data.Instance.gameData.golem_hp = 100;
            Data.Instance.gameData.golem_damage = 14;
            Data.Instance.gameData.goelm_last_damage = 18;
            Data.Instance.gameData.golem_speed = 17;
            for (int i = 0; i < 6; i++)
            {
                golem_starX[i].gameObject.SetActive(false);
                golem_starO[i].gameObject.SetActive(true);
            }
            for (int i = 0; i < 6; i++)
                golem_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.golem_lv == 7)
        {
            Data.Instance.gameData.golem_characteristic = true;
            Data.Instance.gameData.golem_hp = 100;
            Data.Instance.gameData.golem_damage = 14;
            Data.Instance.gameData.goelm_last_damage = 18;
            Data.Instance.gameData.golem_speed = 17;
            for (int i = 0; i < 6; i++)
            {
                golem_starX[i].gameObject.SetActive(false);
                golem_starO[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < 6; i++)
                golem_star_red[i].gameObject.SetActive(true);
        }

        //·¹º§º° ¸®ÆÛ ½ºÅÈ
        if (Data.Instance.gameData.reaper_lv == 0)
        {
            Data.Instance.gameData.reaper_characteristic = false;
            Data.Instance.gameData.reaper_hp = 40;
            Data.Instance.gameData.reaper_damage = 10;
            Data.Instance.gameData.reaper_skill_damage = 15;
            Data.Instance.gameData.reaper_speed = 18;

            for (int i = 0; i < 6; i++)
            {
                reaper_starX[i].gameObject.SetActive(true);
                reaper_starO[i].gameObject.SetActive(false);
                reaper_star_red[i].gameObject.SetActive(false);
            }
        }
        else if (Data.Instance.gameData.reaper_lv == 1)
        {
            Data.Instance.gameData.reaper_characteristic = false;
            Data.Instance.gameData.reaper_damage = 13;

            reaper_starX[0].gameObject.SetActive(false);
            reaper_starO[0].gameObject.SetActive(true);
            for (int i = 1; i < 6; i++)
            {
                reaper_starX[i].gameObject.SetActive(true);
                reaper_starO[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < 6; i++)
                reaper_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.reaper_lv == 2)
        {
            Data.Instance.gameData.reaper_characteristic = false;
            Data.Instance.gameData.reaper_hp = 50;
            Data.Instance.gameData.reaper_damage = 13;
            reaper_starX[0].gameObject.SetActive(false);
            reaper_starO[0].gameObject.SetActive(true);
            reaper_starX[1].gameObject.SetActive(false);
            reaper_starO[1].gameObject.SetActive(true);
            for (int i = 2; i < 6; i++)
            {
                reaper_starX[i].gameObject.SetActive(true);
                reaper_starO[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < 6; i++)
                reaper_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.reaper_lv == 3)
        {
            Data.Instance.gameData.reaper_characteristic = false;
            Data.Instance.gameData.reaper_skill_damage = 19;
            Data.Instance.gameData.reaper_hp = 50;
            Data.Instance.gameData.reaper_damage = 13;
            reaper_starX[0].gameObject.SetActive(false);
            reaper_starO[0].gameObject.SetActive(true);
            reaper_starX[1].gameObject.SetActive(false);
            reaper_starO[1].gameObject.SetActive(true);
            reaper_starX[2].gameObject.SetActive(false);
            reaper_starO[2].gameObject.SetActive(true);
            for (int i = 3; i < 6; i++)
            {
                reaper_starX[i].gameObject.SetActive(true);
                reaper_starO[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < 6; i++)
                reaper_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.reaper_lv == 4)
        {
            Data.Instance.gameData.reaper_characteristic = false;
            Data.Instance.gameData.reaper_speed = 23;
            Data.Instance.gameData.reaper_skill_damage = 19;
            Data.Instance.gameData.reaper_hp = 50;
            Data.Instance.gameData.reaper_damage = 13;
            reaper_starX[0].gameObject.SetActive(false);
            reaper_starO[0].gameObject.SetActive(true);
            reaper_starX[1].gameObject.SetActive(false);
            reaper_starO[1].gameObject.SetActive(true);
            reaper_starX[2].gameObject.SetActive(false);
            reaper_starO[2].gameObject.SetActive(true);
            reaper_starX[3].gameObject.SetActive(false);
            reaper_starO[3].gameObject.SetActive(true);
            for (int i = 4; i < 6; i++)
            {
                reaper_starX[i].gameObject.SetActive(true);
                reaper_starO[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < 6; i++)
                reaper_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.reaper_lv == 5)
        {
            Data.Instance.gameData.reaper_characteristic = false;
            Data.Instance.gameData.reaper_damage = 16;
            Data.Instance.gameData.reaper_speed = 23;
            Data.Instance.gameData.reaper_skill_damage = 19;
            Data.Instance.gameData.reaper_hp = 50;

            reaper_starX[0].gameObject.SetActive(false);
            reaper_starO[0].gameObject.SetActive(true);
            reaper_starX[1].gameObject.SetActive(false);
            reaper_starO[1].gameObject.SetActive(true);
            reaper_starX[2].gameObject.SetActive(false);
            reaper_starO[2].gameObject.SetActive(true);
            reaper_starX[3].gameObject.SetActive(false);
            reaper_starO[3].gameObject.SetActive(true);
            reaper_starX[4].gameObject.SetActive(false);
            reaper_starO[4].gameObject.SetActive(true);
            for (int i = 5; i < 6; i++)
            {
                reaper_starX[i].gameObject.SetActive(true);
                reaper_starO[i].gameObject.SetActive(false);
            }
        }
        else if (Data.Instance.gameData.reaper_lv == 6)
        {
            Data.Instance.gameData.reaper_characteristic = false;
            Data.Instance.gameData.reaper_hp = 70;
            Data.Instance.gameData.reaper_damage = 16;
            Data.Instance.gameData.reaper_speed = 23;
            Data.Instance.gameData.reaper_skill_damage = 19;
            for (int i = 0; i < 6; i++)
            {
                reaper_starX[i].gameObject.SetActive(false);
                reaper_starO[i].gameObject.SetActive(true);
            }
            for (int i = 0; i < 6; i++)
                reaper_star_red[i].gameObject.SetActive(false);
        }
        else if (Data.Instance.gameData.reaper_lv == 7)
        {
            Data.Instance.gameData.reaper_characteristic = true;
            Data.Instance.gameData.reaper_hp = 70;
            Data.Instance.gameData.reaper_damage = 16;
            Data.Instance.gameData.reaper_speed = 23;
            Data.Instance.gameData.reaper_skill_damage = 19;
            for (int i = 0; i < 6; i++)
            {
                reaper_starX[i].gameObject.SetActive(false);
                reaper_starO[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < 6; i++)
                reaper_star_red[i].gameObject.SetActive(true);
        }

        
    }
    public void GameStart()
    {
        SceneManager.LoadScene("InGame");
    }
    public void Start_Explain()
    {
        explainpage.gameObject.SetActive(true);
        explain[0].gameObject.SetActive(true);
    }
    public void Next_Explain1()
    {
        explainbutton.gameObject.SetActive(false);
        explain[0].gameObject.SetActive(false);
        explain[1].gameObject.SetActive(true);
    }
    public void Next_Explain2()
    {
        explain[0].gameObject.SetActive(false);
        explain[1].gameObject.SetActive(false);
        explain[2].gameObject.SetActive(true);
    }
    public void Next_Explain3()
    {
        explain[0].gameObject.SetActive(false);
        explain[1].gameObject.SetActive(false);
        explain[2].gameObject.SetActive(false);
        explain[3].gameObject.SetActive(true);
    }
    public void Next_Explain4()
    {
        explain[0].gameObject.SetActive(false);
        explain[1].gameObject.SetActive(false);
        explain[2].gameObject.SetActive(false);
        explain[3].gameObject.SetActive(false);
        explain[4].gameObject.SetActive(true);
    }
    public void End_Explain()
    {
        explain[0].gameObject.SetActive(false);
        explain[1].gameObject.SetActive(false);
        explain[2].gameObject.SetActive(false);
        explain[3].gameObject.SetActive(false);
        explain[4].gameObject.SetActive(false);
        explainpage.gameObject.SetActive(false);
        Data.Instance.gameData.isExplain = true;
        Data.Instance.SaveGameData();
    }
}
