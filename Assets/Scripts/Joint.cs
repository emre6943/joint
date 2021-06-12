using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public List<GameObject> kuls = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SeperateKul();
        }
    }

    private void SeperateKul()
    {
        GameObject kul = kuls[0];
        kuls.RemoveAt(0);
        kul.transform.parent = null;
        StartCoroutine(WaitForRb(kul, 0.1f));
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
