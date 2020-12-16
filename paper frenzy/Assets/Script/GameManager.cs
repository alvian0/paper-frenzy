using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image ProgressBar;
    public float FillAmout = 0.1f;
    public int poin;
    public Text ScoreMater, MultipleMater;
    public int ScoreMultiple = 1;

    void Start()
    {
        
    }

    void Update()
    {
        ScoreMater.text = poin.ToString();
        MultipleMater.text = ScoreMultiple.ToString() + "x";
    }

    public void progresbarupdate()
    {
        ProgressBar.fillAmount += FillAmout;
    }
}
