using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�ٸ� �κп��� �����ϰ� �ʹٸ�, DataController.Instance.SaveGameData()

[Serializable]
public class GameData
{
    //��ȭ
    public int gold;
    //�ְ� ����
    public int best_score;
    //Ƽ��
    public int ticket;
    //����
    public bool sound;
    public bool effect;
    //���� ��ư ���� ���� ����
    public int numberoftime_Number = 5;//�ܿ�Ƚ��
    public bool is_Cool = false;//��ư�� �������� ����
    public int time_Min = 2;//��Ÿ�� �� ��
    public float time_Sec = 59;//��Ÿ�� �� ��
    public int today;
    public int tomorrow;

    //���� ���� ���� ���� ����
    public int character_cnt;

    //���� ���� ������ ����
    public int wolf_lv;
    public bool wolf_characteristic;
    public int wolf_hp;
    public int wolf_damage;
    public int wolf_last_damage;
    public int wolf_skill_damage;
    public float wolf_speed;

    //���̷��� ������ ����
    public int skeleton_lv;
    public bool skeleton_characteristic;
    public int skeleton_hp;
    public int skeleton_damage;
    public int skeleton_last_damage;
    public int skeleton_skill_damage;
    public float skeleton_speed;

    //������ ������ ����
    public int slime_lv;
    public bool slime_characteristic;
    public int slime_hp;
    public int slime_damage;
    public int sllime_skill_damage;
    public float slime_speed;

    //�� ������ ����
    public int golem_lv;
    public bool golem_characteristic;
    public int golem_hp;
    public int golem_damage;
    public int goelm_last_damage;
    public float golem_speed;

    //���� ������ ����
    public int reaper_lv;
    public bool reaper_characteristic;
    public int reaper_hp;
    public int reaper_damage;
    public int reaper_skill_damage;
    public float reaper_speed;

    //���1 ��ī�� ������ ����
    public int michael_hp;
    public int michael_damage;
    public int michael_speed;

    //���2 ��ũ ������ ����
    public int monk_hp;
    public int monk_damage;
    public int monk_speed;

    //���3 ���� ������ ����
    public int thief_hp;
    public int thief_damage;
    public int thief_speed;
    
    //���4 ���� ������ ����
    public int archer_hp;
    public int archer_damage;
    public int archer_speed;

    //���5 ������ ������ ����
    public int magician_hp;
    public int magician_damage;
    public int magician_speed;

    //���6 ���� ������ ����
    public int pirate_hp;
    public int pirate_damage;
    public int pirate_speed;

    //����1 ������ ������ ����
    public int warrior_hp;
    public int warrior_damage;
    public int warrior_body_damage;
    public int warrior_skill_damage;
    public int warrior_speed;

    //����2 ��Ű�� ������ ����
    public int valkyrie_hp;
    public int valkyrie_damage;
    public int valkyrie_body_damage;
    public int valkyrie_skill_damage;
    public int valkyrie_speed;

    //����3 ��ؽ� ������ ����
    public int assassin_hp;
    public int assassin_damage;
    public int assassin_body_damage;
    public int assassin_skill_damage;
    public int assassin_speed;

    //����4 ������ ������ ����
    public int mage_hp;
    public int mage_body_damage;
    public int mage_damage;
    public int mage_speed;

    //ī�� ������ �ִ� ����
    public int card_count;
    //ī����� ī�尡 �ִ��� ����
    public bool is_card1;
    public bool is_card2;
    public bool is_card3;
    public bool is_card4;
    public bool is_card5;
    //Ư��ī�� ����, ������ 0�̸� ���°���
    public int heallv;
    public int angerlv;
    public int vampirelv;
    public int arrowlv;
    public int lightninglv;
    public int shieldlv;

    //��Ȱ�������� ������ �ѹ��߰�
    public bool reborn;

    //�� ���� ������ �ִ��� ����
    public bool have_golem;
    public bool have_reaper;

    //���� ���� ȹ�� ����
    public bool isAdsBuff;

    //����
    public bool isExplain;
}

