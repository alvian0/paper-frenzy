using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image ProgressBar;
    public int poin;
    public Text ScoreMater, MultipleMater;
    public int ScoreMultiple = 1;
    public float CurrentProgress = 0f;
    public Player player;
    public bool gameFinish = false, GameOver = false;
    public GameObject GameOverScreen, FinishScreen, InGameUI, PauseScreen;
    public Text DeathMessage, FinalScore;
    bool IsPaused = false;

    void Start()
    {
        Time.timeScale = 1f;
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

        if (GameOver)
        {
            InGameUI.SetActive(false);
            GameOverScreen.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Fish"));
            Destroy(GameObject.FindGameObjectWithTag("killer"));
        }

        if (!GameOver && !gameFinish)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPaused)
                {
                    UnPused();
                }

                else
                {
                    Paused();
                }
            }
        }

        CurrentProgress = ProgressBar.fillAmount;
        ScoreMater.text = "Score : " + poin.ToString();
        FinalScore.text = "Score\n" + poin.ToString();
        MultipleMater.text = ScoreMultiple.ToString() + "x";
    }

    public void progresbarupdate(float FillAmount)
    {
        ProgressBar.fillAmount += FillAmount;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UnPused()
    {
        Time.timeScale = 1f;
        InGameUI.SetActive(true);
        PauseScreen.SetActive(false);
        IsPaused = false;
    }

    public void Paused()
    {
        Time.timeScale = 0f;
        InGameUI.SetActive(false);
        PauseScreen.SetActive(true);
        IsPaused = true;
    }
}
