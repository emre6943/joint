using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Joint : MonoBehaviour
{
    [HideInInspector] public static Joint instance;
    
    public List<GameObject> ashes = new List<GameObject>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }
    
    public void SplitAsh()
    {
        GameObject ash = ashes[0];
        ashes.RemoveAt(0);
        ash.transform.parent = null;
        StartCoroutine(WaitForRb(ash, 0.1f));
    }

    private IEnumerator WaitForRb(GameObject kul, float time)
    {
        yield return new WaitForSeconds(time);
        Rigidbody2D rb = kul.AddComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.gravityScale = 1f;
        rb.angularDrag = 5;
        rb.drag = 5;
    }
}
