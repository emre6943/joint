using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject old_hand;
    public GameObject hand;

    public float xPosLeft;
    public float xPosRight;
    public float yMin;
    public float yMax;


    private bool left;


    // Start is called before the first frame update
    void Start()
    {
        float yPos = NextFloat(yMin, yMax);
        old_hand = Instantiate(hand, new Vector3(xPosRight, yPos, 0), Quaternion.identity);
        left = false;
    }

    static float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(old_hand);
        float yPos = NextFloat(yMin, yMax);

        if (left)
        {
            left = false;
            old_hand = Instantiate(hand, new Vector3(xPosRight, yPos, 0), Quaternion.identity);
        }
        else
        {
            left = true;
            old_hand = Instantiate(hand, new Vector3(xPosLeft, yPos, 0), Quaternion.identity);
        }
    }
}
