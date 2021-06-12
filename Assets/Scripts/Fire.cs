using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float moveSpeed;
    public Transform endPosition;
    
    private float originalDiff;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalDiff = transform.position.y - endPosition.position.y;
    }

    private void Update()
    {
        originalDiff -= moveSpeed;
        transform.position = new Vector3(endPosition.position.x, endPosition.position.y + originalDiff, 0);
    }

    // private IEnumerator WaitForFireStart()
    // {
    //     yield return new WaitForSeconds(2f);
    //     fireStarted = true;
    // }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SplitLoc")
        {
            if (other.transform.position.y < transform.position.y && rb.velocity.y > 0) return;
            
            Ash ash = other.transform.parent.GetComponent<Ash>();
            if (ash.isConnected)
            {
                ash.isConnected = false;
                Joint.instance.SplitAsh();
            }
        }
    }
}
