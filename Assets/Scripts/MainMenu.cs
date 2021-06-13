using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScore;

    public GameObject canvas;
    public GameObject canvasTutorial;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", 0);
            highScore.text = "HIGH SCORE: 0";
        }
    }

    public void ReadyButton()
    {
        canvas.SetActive(false);
        canvasTutorial.SetActive(true);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
