using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshTray : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ash")
        {
            AudioManager.instance.PlaySound("hand");
            Destroy(col.gameObject);
            GameManager.instance.AddAsh();
        }

    }
}
