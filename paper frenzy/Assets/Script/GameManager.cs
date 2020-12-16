using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image ProgressBar;
    public int poin;
    public Text ScoreMater, MultipleMater;
    public int ScoreMultiple = 1;

    void Start()
    {
        ProgressBar.fillAmount = 0f;
    }

    void Update()
    {
        ScoreMater.text = "Score : " + poin.ToString();
        MultipleMater.text = ScoreMultiple.ToString() + "x";
    }

    public void progresbarupdate(float FillAmount)
    {
        ProgressBar.fillAmount += FillAmount;
    }
}
