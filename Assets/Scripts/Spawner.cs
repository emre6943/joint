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

    public int xPos;
    public int yPos;
    public int zPos;

    public int minX;
    public int maxX;
    public int minY;
    public int maxY;

    public int Level;
    public float respawner_time;

    // Start is called before the first frame update
    void Start()
    {
        nums = new int[]{0,0,0};
        randoms = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2};
        StartCoroutine(DropChar());
    }

    IEnumerator DropChar()
    {

        while (true)
        {
            int index = Random.Range(0, randoms.Length);
            int choice = randoms[index];

            xPos = Random.Range(minX, maxX + 1);
            yPos = Random.Range(minY, maxY + 1);

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
            yield return new WaitForSeconds(respawner_time / Level);
        }
    }



}
