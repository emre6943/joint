using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public float moveSpeed = 0.2f;

    private Vector3 mousePosition;
    private Vector2 position = new Vector2(0, 0);
    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

        if (!GameManager.instance.paused)
        {
            var pos = Camera.main.WorldToViewportPoint(position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);   
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }
}
