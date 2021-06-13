using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance = null;
    [HideInInspector] public int ash;
    [HideInInspector] public int pass;
    [HideInInspector] public float currentTime = 0;
    
    [HideInInspector] public bool paused;

    public int time_weight;
    public int pass_weight;
    public int ash_weight;

    private float start_time;
    
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    private void Start()
    {
        start_time = Time.time;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }

        currentTime += Time.deltaTime;
    }

    public void PauseGame()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
            GUIManager.instance.SetPauseScene(false);
        }
        else
        {
            paused = true;
            Time.timeScale = 0;
            GUIManager.instance.SetPauseScene(true);
        }
    }

    public void AddAsh() 
    {
        ash++;
    }

    public void AddPass()
    {
        pass++;
    }

    public int GetScore() 
    {
        return (int)(System.Math.Round(Time.time - start_time) * time_weight + (pass * pass_weight) + (ash_weight * ash)); 
    }
    
    
}
