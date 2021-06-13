using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [HideInInspector] public static GUIManager instance;
    
    public Text timeText;
    public Text ashScoreText;
    public Text passScoreText;
    public Text numberAshLeftText;

    public GameObject scorePanel;
    public GameObject pauseScene;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
    }

    private void FixedUpdate()
    {
        SetTimeText();
        SetAshScoreText();
        SetPassScoreText();
        SetNumberAshLeftText();
    }

    private void SetTimeText()
    {
        timeText.text = "Time: " + GameManager.instance.currentTime.ToString("F1");
    }

    private void SetAshScoreText()
    {
        ashScoreText.text = "Ash Score: " + GameManager.instance.ash;
    }

    private void SetPassScoreText()
    {
        passScoreText.text = "Pass Score: " + GameManager.instance.pass;
    }

    private void SetNumberAshLeftText()
    {
        numberAshLeftText.text = "Ash Left: " + Joint.instance.ashesLeft;
    }

    public void SetPauseScene(bool boolean)
    {
        scorePanel.SetActive(!boolean);
        pauseScene.SetActive(boolean);
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
