using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshTray : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ash")
        {
            Destroy(col.gameObject);
            GameManager.instance.addAsh();
        }

    }
}
