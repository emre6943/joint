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

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        start_time = Time.time;
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
