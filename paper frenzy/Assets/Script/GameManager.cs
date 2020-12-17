using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image ProgressBar, TimeRemainsBar;
    public int poin;
    public Text ScoreMater, MultipleMater;
    public int ScoreMultiple = 1;
    public float CurrentProgress = 0f;
    public Player player;
    public bool gameFinish = false, GameOver = false;
    public GameObject GameOverScreen, FinishScreen, InGameUI, PauseScreen, TImeRemains;
    public Text DeathMessage, GameOverScore, FinalScore, HighScore;
    public float timeremain = 3f;
    public GameObject[] Spawner;
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
            if (CurrentProgress >= 0.33f)
            {
                player.Phase = 2;
            }

            if (CurrentProgress >= 0.66)
            {
                player.Phase = 3;
            }

            if (CurrentProgress >= 1)
            {
                gameFinish = true;
            }
        }

        if (GameOver)
        {
            InGameUI.SetActive(false);
            GameOverScreen.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Fish"));
            Destroy(GameObject.FindGameObjectWithTag("killer"));
        }

        if (gameFinish)
        {
            TImeRemains.SetActive(true);
            TimeRemainsBar.fillAmount = timeremain;
            Destroy(GameObject.FindGameObjectWithTag("killer"));

            for (int i = Spawner.Length - 1; i > 0; i--)
            {
                Spawner[i].SetActive(false);
            }

            if (timeremain <= 0)
            {
                player.SetHighscore(poin);
                TImeRemains.SetActive(false);
                FinishScreen.SetActive(true);
                InGameUI.SetActive(false);
                Destroy(GameObject.FindGameObjectWithTag("Fish"));
                Destroy(GameObject.FindGameObjectWithTag("Player"));
            }

            else
            {
                timeremain -= Time.deltaTime;
            }
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
        GameOverScore.text = "Score\n" + poin.ToString();
        FinalScore.text = "Score\n" + poin.ToString();
        HighScore.text = "High Score\n" + PlayerPrefs.GetInt("HS");
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

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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
