using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Refresh : MonoBehaviour
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
            if (!col.GetComponent<Ash>().isConnected) c++;
        }

        if (c == cols.Length) return;
        
        if (cols.Length > 0 && !collided)
        {
            collided = true;
            
            Joint.instance.RefillAsh();
            Fire.instance.refresh();

            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
