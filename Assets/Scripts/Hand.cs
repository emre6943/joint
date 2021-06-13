using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float radius;
    public LayerMask layersToCollide;

    private void Update()
    {
        HandleCollision();
    }

    private bool collided;
    private void HandleCollision()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius, layersToCollide);
        
        int c = 0;
        foreach (var col in cols)
        {
            if (col.tag == "Ash" && !col.GetComponent<Ash>().isConnected) c++;
        }

        if (c == cols.Length) return;
        
        if (cols.Length > 0 && !collided)
        {
            collided = true;
            GameManager.instance.AddPass();
            HandController.instance.SetHands();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}