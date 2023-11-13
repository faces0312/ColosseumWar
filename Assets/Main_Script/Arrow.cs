using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //main 씬에서 선택할 몬스터 이미지들
    public GameObject wolf;
    public GameObject slime;
    public GameObject skeleton;
    public GameObject golem;
    public GameObject reaper;
    //
    public AudioSource button;
    private void Start()
    {
        wolf.gameObject.SetActive(true);
        slime.gameObject.SetActive(false);
        skeleton.gameObject.SetActive(false);
        golem.gameObject.SetActive(false);
        reaper.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Data.Instance.gameData.effect == false)
        {
            button.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        else if (Data.Instance.gameData.effect == true)
        {
            button.gameObject.GetComponent<AudioSource>().enabled = true;
        }
        if (wolf.gameObject.activeSelf == true)
        {
            Data.Instance.gameData.character_cnt = 1;
        }
        if (slime.gameObject.activeSelf == true)
        {
            Data.Instance.gameData.character_cnt = 2;
        }
        if (skeleton.gameObject.activeSelf == true)
        {
            Data.Instance.gameData.character_cnt = 3;
        }
        if (golem.gameObject.activeSelf == true)
        {
            Data.Instance.gameData.character_cnt = 4;
        }
        if (reaper.gameObject.activeSelf == true)
        {
            Data.Instance.gameData.character_cnt = 5;
        }
    }
    //왼쪽화살표와 오른쪽 화살표
    public void LeftArrow()
    {
        button.Play();

        if (Data.Instance.gameData.have_golem == true&& Data.Instance.gameData.have_reaper == true)
        {
            if (wolf.gameObject.activeSelf == true)
            {
                wolf.gameObject.SetActive(false);
                reaper.gameObject.SetActive(true);
            }
            else if (slime.gameObject.activeSelf == true)
            {
                slime.gameObject.SetActive(false);
                wolf.gameObject.SetActive(true);
            }
            else if (skeleton.gameObject.activeSelf == true)
            {
                skeleton.gameObject.SetActive(false);
                slime.gameObject.SetActive(true);
            }
            else if (golem.gameObject.activeSelf == true)
            {
                golem.gameObject.SetActive(false);
                skeleton.gameObject.SetActive(true);
            }
            else if (reaper.gameObject.activeSelf == true)
            {
                reaper.gameObject.SetActive(false);
                golem.gameObject.SetActive(true);
            }
        }
        else if (Data.Instance.gameData.have_golem == true && Data.Instance.gameData.have_reaper == false)
        {
            if (wolf.gameObject.activeSelf == true)
            {
                wolf.gameObject.SetActive(false);
                golem.gameObject.SetActive(true);
            }
            else if (slime.gameObject.activeSelf == true)
            {
                slime.gameObject.SetActive(false);
                wolf.gameObject.SetActive(true);
            }
            else if (skeleton.gameObject.activeSelf == true)
            {
                skeleton.gameObject.SetActive(false);
                slime.gameObject.SetActive(true);
            }
            else if (golem.gameObject.activeSelf == true)
            {
                golem.gameObject.SetActive(false);
                skeleton.gameObject.SetActive(true);
            }
        }
        else if (Data.Instance.gameData.have_golem == false && Data.Instance.gameData.have_reaper == true)
        {
            if (wolf.gameObject.activeSelf == true)
            {
                wolf.gameObject.SetActive(false);
                reaper.gameObject.SetActive(true);
            }
            else if (slime.gameObject.activeSelf == true)
            {
                slime.gameObject.SetActive(false);
                wolf.gameObject.SetActive(true);
            }
            else if (skeleton.gameObject.activeSelf == true)
            {
                skeleton.gameObject.SetActive(false);
                slime.gameObject.SetActive(true);
            }
            else if (reaper.gameObject.activeSelf == true)
            {
                reaper.gameObject.SetActive(false);
                skeleton.gameObject.SetActive(true);
            }
        }
        else if (Data.Instance.gameData.have_golem == false && Data.Instance.gameData.have_reaper == false)
        {
            if (wolf.gameObject.activeSelf == true)
            {
                wolf.gameObject.SetActive(false);
                skeleton.gameObject.SetActive(true);
            }
            else if (slime.gameObject.activeSelf == true)
            {
                slime.gameObject.SetActive(false);
                wolf.gameObject.SetActive(true);
            }
            else if (skeleton.gameObject.activeSelf == true)
            {
                skeleton.gameObject.SetActive(false);
                slime.gameObject.SetActive(true);
            }
        }

    }
    public void RightArrow()
    {
        button.Play();
        if (Data.Instance.gameData.have_golem == true && Data.Instance.gameData.have_reaper == true)
        {
            if (wolf.gameObject.activeSelf == true)
            {
                wolf.gameObject.SetActive(false);
                slime.gameObject.SetActive(true);
            }
            else if (slime.gameObject.activeSelf == true)
            {
                slime.gameObject.SetActive(false);
                skeleton.gameObject.SetActive(true);
            }
            else if (skeleton.gameObject.activeSelf == true)
            {
                skeleton.gameObject.SetActive(false);
                golem.gameObject.SetActive(true);
            }
            else if (golem.gameObject.activeSelf == true)
            {
                golem.gameObject.SetActive(false);
                reaper.gameObject.SetActive(true);
            }
            else if (reaper.gameObject.activeSelf == true)
            {
                reaper.gameObject.SetActive(false);
                wolf.gameObject.SetActive(true);
            }
        }
        else if (Data.Instance.gameData.have_golem == true && Data.Instance.gameData.have_reaper == false)
        {
            if (wolf.gameObject.activeSelf == true)
            {
                wolf.gameObject.SetActive(false);
                slime.gameObject.SetActive(true);
            }
            else if (slime.gameObject.activeSelf == true)
            {
                slime.gameObject.SetActive(false);
                skeleton.gameObject.SetActive(true);
            }
            else if (skeleton.gameObject.activeSelf == true)
            {
                skeleton.gameObject.SetActive(false);
                golem.gameObject.SetActive(true);
            }
            else if (golem.gameObject.activeSelf == true)
            {
                golem.gameObject.SetActive(false);
                wolf.gameObject.SetActive(true);
            }
        }
        else if (Data.Instance.gameData.have_golem == false && Data.Instance.gameData.have_reaper == true)
        {
            if (wolf.gameObject.activeSelf == true)
            {
                wolf.gameObject.SetActive(false);
                slime.gameObject.SetActive(true);
            }
            else if (slime.gameObject.activeSelf == true)
            {
                slime.gameObject.SetActive(false);
                skeleton.gameObject.SetActive(true);
            }
            else if (skeleton.gameObject.activeSelf == true)
            {
                skeleton.gameObject.SetActive(false);
                reaper.gameObject.SetActive(true);
            }
            else if (reaper.gameObject.activeSelf == true)
            {
                reaper.gameObject.SetActive(false);
                wolf.gameObject.SetActive(true);
            }
        }
        else if (Data.Instance.gameData.have_golem == false && Data.Instance.gameData.have_reaper == false)
        {
            if (wolf.gameObject.activeSelf == true)
            {
                wolf.gameObject.SetActive(false);
                slime.gameObject.SetActive(true);
            }
            else if (slime.gameObject.activeSelf == true)
            {
                slime.gameObject.SetActive(false);
                skeleton.gameObject.SetActive(true);
            }
            else if (skeleton.gameObject.activeSelf == true)
            {
                skeleton.gameObject.SetActive(false);
                wolf.gameObject.SetActive(true);
            }
            
        }

    }
    //
}
