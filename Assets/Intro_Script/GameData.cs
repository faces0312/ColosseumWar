using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//다른 부분에서 저장하고 싶다면, DataController.Instance.SaveGameData()

[Serializable]
public class GameData
{
    //재화
    public int gold;
    //최고 점수
    public int best_score;
    //티켓
    public int ticket;
    //설정
    public bool sound;
    public bool effect;
    //광고 버튼 관련 저장 변수
    public int numberoftime_Number = 5;//잔여횟수
    public bool is_Cool = false;//버튼을 눌렀는지 여부
    public int time_Min = 2;//쿨타임 중 초
    public float time_Sec = 59;//쿨타임 중 초
    public int today;
    public int tomorrow;

    //유닛 선택 관련 저장 변수
    public int character_cnt;

    //웨어 울프 프로필 파일
    public int wolf_lv;
    public bool wolf_characteristic;
    public int wolf_hp;
    public int wolf_damage;
    public int wolf_last_damage;
    public int wolf_skill_damage;
    public float wolf_speed;

    //스켈레톤 프로필 파일
    public int skeleton_lv;
    public bool skeleton_characteristic;
    public int skeleton_hp;
    public int skeleton_damage;
    public int skeleton_last_damage;
    public int skeleton_skill_damage;
    public float skeleton_speed;

    //슬라임 프로필 파일
    public int slime_lv;
    public bool slime_characteristic;
    public int slime_hp;
    public int slime_damage;
    public int sllime_skill_damage;
    public float slime_speed;

    //골렘 프로필 파일
    public int golem_lv;
    public bool golem_characteristic;
    public int golem_hp;
    public int golem_damage;
    public int goelm_last_damage;
    public float golem_speed;

    //리퍼 프로필 파일
    public int reaper_lv;
    public bool reaper_characteristic;
    public int reaper_hp;
    public int reaper_damage;
    public int reaper_skill_damage;
    public float reaper_speed;

    //잡몹1 미카엘 프로필 파일
    public int michael_hp;
    public int michael_damage;
    public int michael_speed;

    //잡몹2 뭉크 프로필 파일
    public int monk_hp;
    public int monk_damage;
    public int monk_speed;

    //잡몹3 도적 프로필 파일
    public int thief_hp;
    public int thief_damage;
    public int thief_speed;
    
    //잡몹4 아쳐 프로필 파일
    public int archer_hp;
    public int archer_damage;
    public int archer_speed;

    //잡몹5 매지션 프로필 파일
    public int magician_hp;
    public int magician_damage;
    public int magician_speed;

    //잡몹6 해적 프로필 파일
    public int pirate_hp;
    public int pirate_damage;
    public int pirate_speed;

    //보스1 워리어 프로필 파일
    public int warrior_hp;
    public int warrior_damage;
    public int warrior_body_damage;
    public int warrior_skill_damage;
    public int warrior_speed;

    //보스2 발키리 프로필 파일
    public int valkyrie_hp;
    public int valkyrie_damage;
    public int valkyrie_body_damage;
    public int valkyrie_skill_damage;
    public int valkyrie_speed;

    //보스3 어쌔신 프로필 파일
    public int assassin_hp;
    public int assassin_damage;
    public int assassin_body_damage;
    public int assassin_skill_damage;
    public int assassin_speed;

    //보스4 메이지 프로필 파일
    public int mage_hp;
    public int mage_body_damage;
    public int mage_damage;
    public int mage_speed;

    //카드 가지고 있는 갯수
    public int card_count;
    //카드란에 카드가 있는지 여부
    public bool is_card1;
    public bool is_card2;
    public bool is_card3;
    public bool is_card4;
    public bool is_card5;
    //특성카드 레벨, 레벨이 0이면 없는거임
    public int heallv;
    public int angerlv;
    public int vampirelv;
    public int arrowlv;
    public int lightninglv;
    public int shieldlv;

    //부활페이지는 무조건 한번뜨게
    public bool reborn;

    //골렘 유닛 가지고 있는지 여부
    public bool have_golem;
    public bool have_reaper;

    //광고 버프 획득 여부
    public bool isAdsBuff;

    //설명서
    public bool isExplain;
}

