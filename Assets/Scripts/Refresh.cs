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
            
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Ash")
    //     {
    //         Ash ash = other.gameObject.GetComponent<Ash>();
    //
    //         if (!ash.isConnected) return;
    //         
    //         Joint.instance.RefillAsh();
    //         
    //         Destroy(gameObject);
    //     }
    // }

    // void OnTriggerEnter2D(Collider2D col)
    // {
    //     if (col.gameObject.tag == "Health")
    //     {
    //         Destroy(col.gameObject);
    //
    //         Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    //
    //         // Instantiate(joint, pos, Quaternion.identity);
    //         //
    //         // Destroy(gameObject);
    //         StartCoroutine(WaitForInstantiate(pos));
    //     }
    //     
    // }
    //
    // private IEnumerator WaitForInstantiate(Vector3 pos)
    // {
    //     Instantiate(joint, pos, Quaternion.identity);
    //     yield return new WaitForSeconds(2f);
    //     Debug.Log("Instantiated");
    //     Destroy(gameObject);
    //
    // }
}
