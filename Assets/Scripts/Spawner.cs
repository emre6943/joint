using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject tray;
    public GameObject health;

    public Transform parentTransform;

    public int[] nums;
    public int[] randoms;

    public float xPos;
    public float yPos;
    public float zPos;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float offset;

    public int Level;
    public float respawner_time;
    public int level_interval;
    

    // Start is called before the first frame update
    void Start()
    {
        nums = new int[]{0,0,0};
        randoms = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2};
        StartCoroutine(DropChar());

        var top_left = new Vector3(0, (Screen.height * 1.5f), 0);
        top_left = Camera.main.ScreenToWorldPoint(top_left);
        var bottom_right = new Vector3(Screen.width, (Screen.height * 1.1f), 0);
        bottom_right = Camera.main.ScreenToWorldPoint(bottom_right);

        minX = top_left.x + offset;
        maxX = bottom_right.x - offset;
        minY = bottom_right.y + offset;
        maxY = top_left.y - offset;
    }

    void Update()
    {
        
        if (Time.time > (level_interval * Level)) {
            Level += 1;
            respawner_time -= 0.03f;
        }
    }

    private static float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

    IEnumerator DropChar()
    {

        while (true)
        {
            int index = Random.Range(0, randoms.Length);
            int choice = randoms[index];

            xPos = NextFloat(minX, maxX);
            yPos = NextFloat(minY, maxY);

            nums[choice]++;
            switch (choice) 
            {
                case 0:
                    Instantiate(enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity).transform.SetParent(parentTransform);
                    break;
                case 1:
                    Instantiate(tray, new Vector3(xPos, yPos, zPos), Quaternion.identity).transform.SetParent(parentTransform);
                    break;
                default:
                    Instantiate(health, new Vector3(xPos, yPos, zPos), Quaternion.identity).transform.SetParent(parentTransform);
                    break;
            }
            yield return new WaitForSeconds(respawner_time);
        }
    }



}
