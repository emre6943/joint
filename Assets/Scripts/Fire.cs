using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [HideInInspector] public static Fire instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
    }

    public float moveSpeed;
    public Transform endPosition;
    public float startPosition;
    public float startScale;

    public float scaleX;
    public float scaleY;

    private float originalDiff;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalDiff = transform.position.y - endPosition.position.y;
        startPosition = originalDiff;
        startScale = transform.localScale.y;

        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
    }

    private void Update()
    {
        transform.position = new Vector3(endPosition.position.x, endPosition.position.y + originalDiff, 0);
        originalDiff -= moveSpeed;
        float temp = transform.localScale.y;
        temp += moveSpeed * 2;
        transform.localScale = new Vector3(scaleX, temp, scaleY);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SplitLoc")
        {
            Ash ash = other.transform.parent.GetComponent<Ash>();
            Debug.Log(Joint.instance.moving_up);
            if (ash.isConnected)
            {
                ash.isConnected = false;
                Joint.instance.SplitAsh();
                transform.localScale = new Vector3(scaleX, startScale, scaleY);
            }
        }
    }

    public void refresh() {
        transform.position = new Vector3(endPosition.position.x, endPosition.position.y + startPosition, 0);
        originalDiff = startPosition;
        transform.localScale = new Vector3(scaleX, startScale, scaleY);
    }
}
