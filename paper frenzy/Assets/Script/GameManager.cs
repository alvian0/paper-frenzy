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
    public float CurrentProgress = 0f;
    public Player player;

    void Start()
    {
        ProgressBar.fillAmount = 0f;
    }

    void Update()
    {
        if (player != null)
        {
            if (CurrentProgress >= 0.3f)
            {
                player.Phase = 2;
            }

            if (CurrentProgress >= 0.6)
            {
                player.Phase = 3;
            }
        }

        CurrentProgress = ProgressBar.fillAmount;
        ScoreMater.text = "Score : " + poin.ToString();
        MultipleMater.text = ScoreMultiple.ToString() + "x";
    }

    public void progresbarupdate(float FillAmount)
    {
        ProgressBar.fillAmount += FillAmount;
    }
}
