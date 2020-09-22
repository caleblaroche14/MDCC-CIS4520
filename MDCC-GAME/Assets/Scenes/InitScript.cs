using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScript : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject grunt;
    public int gruntCount = 10;
    System.Random rnd = new System.Random();
    private int lastNumber;

    int spawnx;
    int spawny;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.


        for (int i = 0; i < gruntCount; i++)
        {
            spawnx = GetRandom(-10, 10);
            spawny = GetRandom(-10, 10);
            Instantiate(grunt, new Vector3(spawnx, spawny, 0), Quaternion.identity);
        }
    }

    int GetRandom(int min, int max)
    {
        int rand = Random.Range(min, max);
        while (rand == lastNumber)
            rand = Random.Range(min, max);
        lastNumber = rand;
        return rand;
    }
}

