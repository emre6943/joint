using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance = null;
    public int ash;
    public int pass;

    public int time_weight;
    public int pass_weight;
    public int ash_weight;

    public float start_time;

    public bool paused;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
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
    }

    public void PauseGame()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
        }
        else
        {
            paused = true;
            Time.timeScale = 0;
        }
    }

    public void addAsh() {
        ash++;
    }

    public void addPass()
    {
        pass++;
    }

    public int getScore() 
    {
        return (int)(System.Math.Round(Time.time - start_time) * time_weight + (pass * pass_weight) + (ash_weight * ash)); 
    }
    
    
}
