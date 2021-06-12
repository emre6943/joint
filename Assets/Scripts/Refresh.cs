using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refresh : MonoBehaviour
{
    public GameObject joint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Health")
        {
            Destroy(col.gameObject);

            Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

            Instantiate(joint, pos, Quaternion.identity);
            gameObject.transform.position.Set(0, 0, -100);
            Destroy(gameObject);
            Debug.Log("??");
        }
        
    }
}
