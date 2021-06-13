using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Joint : MonoBehaviour
{
    [HideInInspector] public static Joint instance;
    
    public List<GameObject> ashes = new List<GameObject>();
    public List<GameObject> splitted_ashes = new List<GameObject>();

    [HideInInspector] public int ashesLeft;

    public GameObject real_ash;
    
    private int top_ash_index = 0;

    public bool moving_up = false;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SplitAsh();
        }
        if (top_ash_index >= 8) {
            GameManager.instance.GameOver();
        }

        ashesLeft = ashes.Count - top_ash_index;
    }

    public void SplitAsh()
    {
        GameObject ash = ashes[top_ash_index];
        top_ash_index++;
        GameObject ashClone = Instantiate(real_ash, ash.transform.position, Quaternion.identity);     
        splitted_ashes.Add(ashClone);
        ash.SetActive(false);
        StartCoroutine(WaitForRb(ashClone, 0.05f));
    }

    public void RefillAsh()
    {
        top_ash_index = 0;
        
        for (int i = 0; i < ashes.Count; i++)
        {
            if (!ashes[i].activeSelf) ashes[i].SetActive(true);
        }

        foreach (var ash in splitted_ashes)
        {
            Destroy(ash);
        }
    }

    private IEnumerator WaitForRb(GameObject ash, float time)
    {
        yield return new WaitForSeconds(time);
        if (ash == null) yield return null;
        Rigidbody2D rb = ash.AddComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.gravityScale = 1f;
        rb.angularDrag = 5;
        rb.drag = 5;
    }
}
