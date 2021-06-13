using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float radius;
    public LayerMask layersToCollide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D col)
    {

        if (col.gameObject.tag == "Ash")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Fire")
        {
            GameManager.instance.GameOver();
        }

    }

    private void HandleCollision()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius, layersToCollide);

        int c = 0;
        if (cols.Length > 0)
        {
            GameManager.instance.GameOver();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
