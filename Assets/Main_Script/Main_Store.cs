using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Main_Store : MonoBehaviour
{
    public GameObject store;
    public GameObject store_unit;
    public GameObject store_unit_select;
    public GameObject store_pacakage;
    public GameObject store_pacakage_select;
    public GameObject store_money;
    public GameObject store_money_selecct;
    public GameObject store_casino;
    public GameObject store_casino_select;

    public GameObject pacakage;
    public GameObject money;
    public GameObject casino;

    public TextMeshProUGUI gold;
    public TextMeshProUGUI ticket;

    //솔드아웃관련 오브젝트
    public GameObject unit_golem_soldout;
    public GameObject unit_golem_button;

    public GameObject unit_reaper_soldout;
    public GameObject unit_reaper_button;
    
    public GameObject pacakage_golem_soldout;
    public GameObject pacakage_golem_button;
    
    public GameObject pacakage_reaper_soldout;
    public GameObject pacakage_reaper_button;


    public GameObject gold_less;
    public float gold_less_time;

    //구매하시겠습니까 내역
    public GameObject buy_golem;
    public GameObject buy_reaper;
    public GameObject buy_ticket;
    public GameObject buy_ticket10;
    public GameObject buy_golem_pacakage;
    public GameObject buy_reaper_pacakage;
    public GameObject buy_1200;
    public GameObject buy_3900;
    public GameObject buy_9900;
    public GameObject buy_33000;

    public GameObject buy_cancel_unit;
    public GameObject buy_cancel_pacakage;
    public GameObject buy_cancel_money;
    //검투장
    public GameObject gladiator_cancel;
    public GameObject maximus_select;
    public GameObject spartacus_select;
    public GameObject cheer_up;
    public GameObject cheer_down;
    public GameObject maximus_win;
    public GameObject maximus_lose;
    public GameObject spartacus_win;
    public GameObject spartacus_lose;
    public GameObject video_fight;
    public bool maximus_bet;
    public bool spartacus_bet;
    public int who_win;//0이면 막시무스 승, 1이면 스파르타쿠스 
    public TextMeshProUGUI maximus_win_money;
    public TextMeshProUGUI spartacus_win_money;
    public GameObject maximus_win_check;//승리시 체크 버튼 나중에 나와야함
    public GameObject spartacus_win_check;
    public int win_money_ran;//딴 금액 결정 짓는 랜덤값
    public int win_money;//딴 금액
    int i;

    public AudioSource button;
    public AudioSource fight_sound;
    public AudioSource win_sound;
    public AudioSource buy;
    public AudioSource less_money;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        store.gameObject.SetActive(false);

        gold_less_time = 0;
        gold_less.gameObject.SetActive(false);

        buy_golem.gameObject.SetActive(false);
        buy_reaper.gameObject.SetActive(false);
        buy_ticket.gameObject.SetActive(false);
        buy_ticket10.gameObject.SetActive(false);
        buy_golem_pacakage.gameObject.SetActive(false);
        buy_reaper_pacakage.gameObject.SetActive(false);
        buy_1200.gameObject.SetActive(false);
        buy_3900.gameObject.SetActive(false);
        buy_9900.gameObject.SetActive(false);
        buy_33000.gameObject.SetActive(false);

        buy_cancel_unit.gameObject.SetActive(false);
        buy_cancel_pacakage.gameObject.SetActive(false);
        buy_cancel_money.gameObject.SetActive(false);

        gladiator_cancel.gameObject.SetActive(false);
        maximus_select.gameObject.SetActive(false);
        spartacus_select.gameObject.SetActive(false);
        maximus_win.gameObject.SetActive(false);
        maximus_lose.gameObject.SetActive(false);
        spartacus_win.gameObject.SetActive(false);
        spartacus_lose.gameObject.SetActive(false);
        video_fight.gameObject.SetActive(false);
        maximus_bet = false;
        spartacus_bet = false;
    }
    private void Update()
    {
        if(Data.Instance.gameData.effect==false)
        {
            button.gameObject.GetComponent<AudioSource>().enabled = false;
            fight_sound.gameObject.GetComponent<AudioSource>().enabled = false;
            win_sound.gameObject.GetComponent<AudioSource>().enabled = false;
            buy.gameObject.GetComponent<AudioSource>().enabled = false;
            less_money.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else if(Data.Instance.gameData.effect == true)
        {
            button.gameObject.GetComponent<AudioSource>().enabled = true;
            fight_sound.gameObject.GetComponent<AudioSource>().enabled = true;
            win_sound.gameObject.GetComponent<AudioSource>().enabled = true;
            buy.gameObject.GetComponent<AudioSource>().enabled = true;
            less_money.gameObject.GetComponent<AudioSource>().enabled = true;
        }
        gold.text = Data.Instance.gameData.gold.ToString();
        ticket.text = Data.Instance.gameData.ticket.ToString();

        if (gold_less_time > 1f)
        {
            gold_less.gameObject.SetActive(false);
            gold_less.gameObject.transform.position = new Vector3(0, 0);
            gold_less_time = 0;
        }
        if (gold_less.gameObject.activeSelf == true)
        {
            gold_less_time += Time.deltaTime;
            gold_less.gameObject.transform.Translate(new Vector3(0, 0.003f));
        }

        if (Data.Instance.gameData.have_golem==false)
        {
            unit_golem_soldout.gameObject.SetActive(false);
            pacakage_golem_soldout.gameObject.SetActive(false);
            unit_golem_button.gameObject.SetActive(true);
            pacakage_golem_button.gameObject.SetActive(true);
        }
        else if(Data.Instance.gameData.have_golem == true)
        {
            unit_golem_soldout.gameObject.SetActive(true);
            pacakage_golem_soldout.gameObject.SetActive(true);
            unit_golem_button.gameObject.SetActive(false);
            pacakage_golem_button.gameObject.SetActive(false);
        }

        if (Data.Instance.gameData.have_reaper == false)
        {
            unit_reaper_soldout.gameObject.SetActive(false);
            pacakage_reaper_soldout.gameObject.SetActive(false);
            unit_reaper_button.gameObject.SetActive(true);
            pacakage_reaper_button.gameObject.SetActive(true);
        }
        else if (Data.Instance.gameData.have_reaper == true)
        {
            unit_reaper_soldout.gameObject.SetActive(true);
            pacakage_reaper_soldout.gameObject.SetActive(true);
            unit_reaper_button.gameObject.SetActive(false);
            pacakage_reaper_button.gameObject.SetActive(false);
        }

        if(Data.Instance.gameData.ticket>0&&((maximus_select.gameObject.activeSelf == true || spartacus_select.gameObject.activeSelf == true)))
        {
            cheer_up.gameObject.SetActive(true);
            cheer_down.gameObject.SetActive(false);
        }
        else if(Data.Instance.gameData.ticket <= 0 || (maximus_select.gameObject.activeSelf==false&& spartacus_select.gameObject.activeSelf == false))
        {
            cheer_up.gameObject.SetActive(false);
            cheer_down.gameObject.SetActive(true);
        }
    }

    public void Store()
    {
        button.Play();
        store.gameObject.SetActive(true);

        store_unit.gameObject.SetActive(false);
        store_pacakage.gameObject.SetActive(true);
        store_money.gameObject.SetActive(true);
        store_casino.gameObject.SetActive(true);

        store_unit_select.gameObject.SetActive(true);
        store_pacakage_select.gameObject.SetActive(false);
        store_money_selecct.gameObject.SetActive(false);
        store_casino_select.gameObject.SetActive(false);

        pacakage.gameObject.SetActive(false);
        money.gameObject.SetActive(false);
        casino.gameObject.SetActive(false);
    }

    public void Store_Unit()
    {
        button.Play();
        store_unit.gameObject.SetActive(false);
        store_pacakage.gameObject.SetActive(true);
        store_money.gameObject.SetActive(true);
        store_casino.gameObject.SetActive(true);

        store_unit_select.gameObject.SetActive(true);
        store_pacakage_select.gameObject.SetActive(false);
        store_money_selecct.gameObject.SetActive(false);
        store_casino_select.gameObject.SetActive(false);

        pacakage.gameObject.SetActive(false);
        money.gameObject.SetActive(false);
        casino.gameObject.SetActive(false);

        buy_golem.gameObject.SetActive(false);
        buy_reaper.gameObject.SetActive(false);
        buy_ticket.gameObject.SetActive(false);
        buy_ticket10.gameObject.SetActive(false);
        buy_golem_pacakage.gameObject.SetActive(false);
        buy_reaper_pacakage.gameObject.SetActive(false);
        buy_1200.gameObject.SetActive(false);
        buy_3900.gameObject.SetActive(false);
        buy_9900.gameObject.SetActive(false);
        buy_33000.gameObject.SetActive(false);

        buy_cancel_unit.gameObject.SetActive(false);
        buy_cancel_pacakage.gameObject.SetActive(false);
        buy_cancel_money.gameObject.SetActive(false);
    }
    public void Store_Pacakage()
    {
        button.Play();
        store_unit.gameObject.SetActive(true);
        store_pacakage.gameObject.SetActive(false);
        store_money.gameObject.SetActive(true);
        store_casino.gameObject.SetActive(true);

        store_unit_select.gameObject.SetActive(false);
        store_pacakage_select.gameObject.SetActive(true);
        store_money_selecct.gameObject.SetActive(false);
        store_casino_select.gameObject.SetActive(false);

        pacakage.gameObject.SetActive(true);
        money.gameObject.SetActive(false);
        casino.gameObject.SetActive(false);

        buy_golem.gameObject.SetActive(false);
        buy_reaper.gameObject.SetActive(false);
        buy_ticket.gameObject.SetActive(false);
        buy_ticket10.gameObject.SetActive(false);
        buy_golem_pacakage.gameObject.SetActive(false);
        buy_reaper_pacakage.gameObject.SetActive(false);
        buy_1200.gameObject.SetActive(false);
        buy_3900.gameObject.SetActive(false);
        buy_9900.gameObject.SetActive(false);
        buy_33000.gameObject.SetActive(false);

        buy_cancel_unit.gameObject.SetActive(false);
        buy_cancel_pacakage.gameObject.SetActive(false);
        buy_cancel_money.gameObject.SetActive(false);
    }
    public void Store_Money()
    {
        button.Play();
        store_unit.gameObject.SetActive(true);
        store_pacakage.gameObject.SetActive(true);
        store_money.gameObject.SetActive(false);
        store_casino.gameObject.SetActive(true);

        store_unit_select.gameObject.SetActive(false);
        store_pacakage_select.gameObject.SetActive(false);
        store_money_selecct.gameObject.SetActive(true);
        store_casino_select.gameObject.SetActive(false);

        pacakage.gameObject.SetActive(false);
        money.gameObject.SetActive(true);
        casino.gameObject.SetActive(false);

        buy_golem.gameObject.SetActive(false);
        buy_reaper.gameObject.SetActive(false);
        buy_ticket.gameObject.SetActive(false);
        buy_ticket10.gameObject.SetActive(false);
        buy_golem_pacakage.gameObject.SetActive(false);
        buy_reaper_pacakage.gameObject.SetActive(false);
        buy_1200.gameObject.SetActive(false);
        buy_3900.gameObject.SetActive(false);
        buy_9900.gameObject.SetActive(false);
        buy_33000.gameObject.SetActive(false);

        buy_cancel_unit.gameObject.SetActive(false);
        buy_cancel_pacakage.gameObject.SetActive(false);
        buy_cancel_money.gameObject.SetActive(false);
    }
    public void Store_Casino()
    {
        button.Play();
        store_unit.gameObject.SetActive(true);
        store_pacakage.gameObject.SetActive(true);
        store_money.gameObject.SetActive(true);
        store_casino.gameObject.SetActive(false);

        store_unit_select.gameObject.SetActive(false);
        store_pacakage_select.gameObject.SetActive(false);
        store_money_selecct.gameObject.SetActive(false);
        store_casino_select.gameObject.SetActive(true);

        pacakage.gameObject.SetActive(false);
        money.gameObject.SetActive(false);
        casino.gameObject.SetActive(true);

        buy_golem.gameObject.SetActive(false);
        buy_reaper.gameObject.SetActive(false);
        buy_ticket.gameObject.SetActive(false);
        buy_ticket10.gameObject.SetActive(false);
        buy_golem_pacakage.gameObject.SetActive(false);
        buy_reaper_pacakage.gameObject.SetActive(false);
        buy_1200.gameObject.SetActive(false);
        buy_3900.gameObject.SetActive(false);
        buy_9900.gameObject.SetActive(false);
        buy_33000.gameObject.SetActive(false);

        buy_cancel_unit.gameObject.SetActive(false);
        buy_cancel_pacakage.gameObject.SetActive(false);
        buy_cancel_money.gameObject.SetActive(false);
    }

    public void Store_Out()
    {
        button.Play();
        buy_golem.gameObject.SetActive(false);
        buy_reaper.gameObject.SetActive(false);
        buy_ticket.gameObject.SetActive(false);
        buy_ticket10.gameObject.SetActive(false);
        buy_golem_pacakage.gameObject.SetActive(false);
        buy_reaper_pacakage.gameObject.SetActive(false);
        buy_1200.gameObject.SetActive(false);
        buy_3900.gameObject.SetActive(false);
        buy_9900.gameObject.SetActive(false);
        buy_33000.gameObject.SetActive(false);

        buy_cancel_unit.gameObject.SetActive(false);
        buy_cancel_pacakage.gameObject.SetActive(false);
        buy_cancel_money.gameObject.SetActive(false);

        store.gameObject.SetActive(false);
    }

    public void Buy_Cancel()
    {
        button.Play();
        buy_golem.gameObject.SetActive(false);
        buy_reaper.gameObject.SetActive(false);
        buy_ticket.gameObject.SetActive(false);
        buy_ticket10.gameObject.SetActive(false);
        buy_golem_pacakage.gameObject.SetActive(false);
        buy_reaper_pacakage.gameObject.SetActive(false);
        buy_1200.gameObject.SetActive(false);
        buy_3900.gameObject.SetActive(false);
        buy_9900.gameObject.SetActive(false);
        buy_33000.gameObject.SetActive(false);

        buy_cancel_unit.gameObject.SetActive(false);
        buy_cancel_pacakage.gameObject.SetActive(false);
        buy_cancel_money.gameObject.SetActive(false);

        Data.Instance.SaveGameData();
    }
    //유닛
    public void Unit_Golem1()
    {
        button.Play();
        buy_golem.gameObject.SetActive(true);   
        buy_cancel_unit.gameObject.SetActive(true);
    }
    public void Unit_Golem2()
    {
        if(Data.Instance.gameData.gold>=15000)
        {
            buy.Play();
            Data.Instance.gameData.gold -= 15000;
            Data.Instance.gameData.have_golem = true;
            buy_golem.gameObject.SetActive(false);
            buy_cancel_unit.gameObject.SetActive(false);
            Data.Instance.SaveGameData();
        }
        else
        {
            gold_less.gameObject.SetActive(true);
            less_money.Play();
            return;
        }
    }
    public void Unit_Reaper1()
    {
        button.Play();
        buy_reaper.gameObject.SetActive(true);
        buy_cancel_unit.gameObject.SetActive(true);
    }
    public void Unit_Reaper2()
    {
        if (Data.Instance.gameData.gold >= 30000)
        {
            buy.Play();
            Data.Instance.gameData.gold -= 30000;
            Data.Instance.gameData.have_reaper = true;
            buy_reaper.gameObject.SetActive(false);
            buy_cancel_unit.gameObject.SetActive(false);
            Data.Instance.SaveGameData();
        }
        else
        {
            gold_less.gameObject.SetActive(true);
            less_money.Play();
            return;
        }
    }
    //패키지
    public void Pacakage_Ticket1()
    {
        button.Play();
        buy_ticket.gameObject.SetActive(true);
        buy_cancel_pacakage.gameObject.SetActive(true);
    }
    public void Pacakage_Ticket2()
    {
        if(Data.Instance.gameData.gold>=1000)
        {
            buy.Play();
            Data.Instance.gameData.gold -= 1000;
            Data.Instance.gameData.ticket++;
            buy_ticket.gameObject.SetActive(false);
            buy_cancel_pacakage.gameObject.SetActive(false);
            Data.Instance.SaveGameData();
        }
        else
        {
            gold_less.gameObject.SetActive(true);
            less_money.Play();
            return;
        }
    }
    public void Pacakage_Ticket10()
    {
        button.Play();
        buy_ticket10.gameObject.SetActive(true);
        buy_cancel_pacakage.gameObject.SetActive(true);
    }
    public void Pacakage_Ticket11()
    {
        buy.Play();
        Data.Instance.gameData.ticket += 10;
        Data.Instance.SaveGameData();
    }
    public void Pacakage_Golem1()
    {
        button.Play();
        buy_golem_pacakage.gameObject.SetActive(true);
        buy_cancel_pacakage.gameObject.SetActive(true);
    }
    public void Pacakage_Golem2()
    {
        buy.Play();
        Data.Instance.gameData.have_golem = true;
        Data.Instance.gameData.gold += 5000;
        Data.Instance.SaveGameData();
    }
    public void Pacakage_Reaper1()
    {
        button.Play();
        buy_reaper_pacakage.gameObject.SetActive(true);
        buy_cancel_pacakage.gameObject.SetActive(true);
    }
    public void Pacakage_Reaper2()
    {
        buy.Play();
        Data.Instance.gameData.have_reaper = true;
        Data.Instance.gameData.gold += 10000;
        Data.Instance.SaveGameData();
    }
    //재화
    public void Money_1200()
    {
        button.Play();
        buy_1200.gameObject.SetActive(true);
        buy_cancel_money.gameObject.SetActive(true);
    }
    public void Money_1201()
    {
        buy.Play();
        Data.Instance.gameData.gold += 3000;
        Data.Instance.SaveGameData();
    }
    public void Money_3900()
    {
        button.Play();
        buy_3900.gameObject.SetActive(true);
        buy_cancel_money.gameObject.SetActive(true);
    }
    public void Money_3901()
    {
        buy.Play();
        Data.Instance.gameData.gold += 10000;
        Data.Instance.SaveGameData();
    }
    public void Money_9900()
    {
        button.Play();
        buy_9900.gameObject.SetActive(true);
        buy_cancel_money.gameObject.SetActive(true);
    }
    public void Money_9901()
    {
        buy.Play();
        Data.Instance.gameData.gold += 30000;
        Data.Instance.SaveGameData();
    }
    public void Money_33000()
    {
        button.Play();
        buy_33000.gameObject.SetActive(true);
        buy_cancel_money.gameObject.SetActive(true);
    }
    public void Money_33001()
    {
        buy.Play();
        Data.Instance.gameData.gold += 100000;
        Data.Instance.SaveGameData();
    }
    //검투장
    public void Maximus()
    {
        if(maximus_select.gameObject.activeSelf==true)
        {
            maximus_select.gameObject.SetActive(false);
            spartacus_select.gameObject.SetActive(false);
        }
        else
        {
            maximus_select.gameObject.SetActive(true);
            spartacus_select.gameObject.SetActive(false);
        }
        
    }
    public void Spartacus()
    {
        if(spartacus_select.gameObject.activeSelf==true)
        {
            maximus_select.gameObject.SetActive(false);
            spartacus_select.gameObject.SetActive(false);
        }
        else
        {
            maximus_select.gameObject.SetActive(false);
            spartacus_select.gameObject.SetActive(true);
        }
        
    }
    public void Cheer_Up()
    {
        fight_sound.Play();
        who_win = Random.Range(0, 2);
        i = 0;
        gladiator_cancel.gameObject.SetActive(true);
        Data.Instance.gameData.ticket--;
        if (maximus_select.gameObject.activeSelf==true)
        {
            maximus_bet = true;
            spartacus_bet = false;
        }
        else if (spartacus_select.gameObject.activeSelf == true)
        {
            maximus_bet = false;
            spartacus_bet = true;
        }
        video_fight.gameObject.SetActive(true);
        Invoke("Dis_Video", 8f);
    }

    public void Dis_Video()
    {
        fight_sound.Pause();
        video_fight.gameObject.SetActive(false);
        if(maximus_bet == true && who_win == 0)
        {
            maximus_win_check.gameObject.SetActive(false);
            win_money_ran = Random.Range(1, 12);
            if(win_money_ran == 1)
            {
                win_money = 1000;
            }
            else if (win_money_ran == 2)
            {
                win_money = 1100;
            }
            else if (win_money_ran == 3)
            {
                win_money = 1200;
            }
            else if (win_money_ran == 4)
            {
                win_money = 1300;
            }
            else if (win_money_ran == 5)
            {
                win_money = 1400;
            }
            else if (win_money_ran == 6)
            {
                win_money = 1500;
            }
            else if (win_money_ran == 7)
            {
                win_money = 1600;
            }
            else if (win_money_ran == 8)
            {
                win_money = 1700;
            }
            else if (win_money_ran == 9)
            {
                win_money = 1800;
            }
            else if (win_money_ran == 10)
            {
                win_money = 1900;
            }
            else if (win_money_ran == 11)
            {
                win_money = 2000;
            }
            maximus_win.gameObject.SetActive(true);
            maximus_lose.gameObject.SetActive(false);
            spartacus_win.gameObject.SetActive(false);
            spartacus_lose.gameObject.SetActive(false);

            Invoke("Mony_Up_Maximus", 0.5f);
            Invoke("Win_Sound", 0.5f);
        }
        if (maximus_bet == true && who_win == 1)
        {
            maximus_win.gameObject.SetActive(false);
            maximus_lose.gameObject.SetActive(true);
            spartacus_win.gameObject.SetActive(false);
            spartacus_lose.gameObject.SetActive(false);
        }
        else if(spartacus_bet == true && who_win == 1)
        {
            spartacus_win_check.gameObject.SetActive(false);
            win_money_ran = Random.Range(1, 12);
            if (win_money_ran == 1)
            {
                win_money = 1000;
            }
            else if (win_money_ran == 2)
            {
                win_money = 1100;
            }
            else if (win_money_ran == 3)
            {
                win_money = 1200;
            }
            else if (win_money_ran == 4)
            {
                win_money = 1300;
            }
            else if (win_money_ran == 5)
            {
                win_money = 1400;
            }
            else if (win_money_ran == 6)
            {
                win_money = 1500;
            }
            else if (win_money_ran == 7)
            {
                win_money = 1600;
            }
            else if (win_money_ran == 8)
            {
                win_money = 1700;
            }
            else if (win_money_ran == 9)
            {
                win_money = 1800;
            }
            else if (win_money_ran == 10)
            {
                win_money = 1900;
            }
            else if (win_money_ran == 11)
            {
                win_money = 2000;
            }
            maximus_win.gameObject.SetActive(false);
            maximus_lose.gameObject.SetActive(false);
            spartacus_win.gameObject.SetActive(true);
            spartacus_lose.gameObject.SetActive(false);

            Invoke("Mony_Up_Spartacus", 0.5f);
            Invoke("Win_Sound", 0.5f);
        }
        else if (spartacus_bet == true && who_win == 0)
        {
            maximus_win.gameObject.SetActive(false);
            maximus_lose.gameObject.SetActive(false);
            spartacus_win.gameObject.SetActive(false);
            spartacus_lose.gameObject.SetActive(true);
        }

        Data.Instance.SaveGameData();
    }

    public void FightResult_Check()
    {
        maximus_win.gameObject.SetActive(false);
        maximus_lose.gameObject.SetActive(false);
        spartacus_win.gameObject.SetActive(false);
        spartacus_lose.gameObject.SetActive(false);
        gladiator_cancel.gameObject.SetActive(false);
        video_fight.gameObject.SetActive(false);
    }
    public void FightResult_Check_Win()
    {
        maximus_win.gameObject.SetActive(false);
        maximus_lose.gameObject.SetActive(false);
        spartacus_win.gameObject.SetActive(false);
        spartacus_lose.gameObject.SetActive(false);
        gladiator_cancel.gameObject.SetActive(false);
        video_fight.gameObject.SetActive(false);

        Data.Instance.gameData.gold += win_money;
    }
    

    public void Mony_Up_Maximus()
    {
        if (i == win_money)
        {
            win_sound.Pause();
            maximus_win_check.gameObject.SetActive(true);
            return;
        }
        i += 10;
        maximus_win_money.text = i.ToString();
        Invoke("Mony_Up_Maximus", 0.01f);
    }

    public void Mony_Up_Spartacus()
    {
        if (i == win_money)
        {
            win_sound.Pause();
            spartacus_win_check.gameObject.SetActive(true);
            return;
        }
        i += 10;
        spartacus_win_money.text = i.ToString();
        Invoke("Mony_Up_Spartacus", 0.01f);
    }
    public void Win_Sound()
    {
        win_sound.Play();
    }
}
