using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public float minLevel;
    public float rate;
    
    private void Awake()
    {
    }

    private void Update()
    {
        var y = transform.localScale.y;

        if (y < minLevel)
        {
            y += 0.0005f;
            transform.localScale = new Vector2(transform.localScale.x, y);   
        }
    }
}
