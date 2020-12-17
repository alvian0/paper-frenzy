using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text HighScore;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        HighScore.text = "High Score\n" + PlayerPrefs.GetInt("HS").ToString();
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Debug.Log("Eixt now");
        Application.Quit();
    }

    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}
