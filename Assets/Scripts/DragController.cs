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
    public bool moving_up = false;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

        if (mousePosition.y > transform.position.y) {
            Joint.instance.moving_up = true;
        } else {
            Joint.instance.moving_up = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }
}
