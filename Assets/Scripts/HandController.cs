using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [HideInInspector] public static HandController instance;
    
    public GameObject old_hand;
    public GameObject left_hand;
    public GameObject right_hand;

    public float xPosLeft;
    public float xPosRight;
    public float yMin;
    public float yMax;

    private bool left;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
    }

    private void Start()
    {
        float yPos = NextFloat(yMin, yMax);
        old_hand = Instantiate(right_hand, new Vector3(xPosRight, yPos, 0), Quaternion.identity);
        left = false;
    }

    private static float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

    public void SetHands()
    {
        Destroy(old_hand);
        float yPos = NextFloat(yMin, yMax);

        if (left)
        {
            left = false;
            old_hand = Instantiate(right_hand, new Vector3(xPosRight, yPos, 0), Quaternion.identity);
        }
        else
        {
            left = true;
            old_hand = Instantiate(left_hand, new Vector3(xPosLeft, yPos, 0), Quaternion.identity);
        }
    }
}
