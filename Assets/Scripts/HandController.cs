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

    public float offset;

    private bool left;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
    }

    private void Start()
    {

        var top_left = new Vector3(0, Screen.height, 0);
        top_left = Camera.main.ScreenToWorldPoint(top_left);
        var bottom_right = new Vector3(Screen.width, 0, 0);
        bottom_right = Camera.main.ScreenToWorldPoint(bottom_right);

        xPosLeft = top_left.x + offset;
        xPosRight = bottom_right.x - offset;
        yMin = bottom_right.y + offset;
        yMax = top_left.y - offset;

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
