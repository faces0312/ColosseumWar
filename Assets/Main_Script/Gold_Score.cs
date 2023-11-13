using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gold_Score : MonoBehaviour
{
    public TextMeshProUGUI gold;
    public TextMeshProUGUI score;

    // Update is called once per frame
    void Update()
    {
        gold.text = Data.Instance.gameData.gold.ToString();
        score.text = Data.Instance.gameData.best_score.ToString();
    }
}
