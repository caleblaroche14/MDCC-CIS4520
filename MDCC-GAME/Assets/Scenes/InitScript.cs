using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScript : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    
    public GameObject mob;

    public GameObject grunt;
    public int gCount = 1;

    public GameObject lion;
    public int lCount = 1;

    public GameObject brawler;
    public int bCount = 1;

    public GameObject swordsman;
    public int sCount = 1;

    System.Random rnd = new System.Random();
    private int lastNumber;

    int spawnx;
    int spawny;

    public List<GameObject> enemies; // = new List<GameObject>();

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        Application.targetFrameRate = 60;
        spawnMobs(gCount,lCount,bCount, sCount);
        //m = GameObject.Find("Mob");
        //public List <GameObject> enemies = new List<GameObject>();
    }

    int GetRandom(int min, int max)
    {
        int rand = Random.Range(min, max);
        while (rand == lastNumber)
            rand = Random.Range(min, max);
        lastNumber = rand;
        return rand;
    }

    public void spawnMobs(int gc, int lc,int bc, int sc) //Grunt, Brawler, Lion, Swordsman
    {
        
        for (int i = 0; i < gc; i++)
        {
            spawnx = GetRandom(-10, 10);
            spawny = GetRandom(-10, 10);
            enemies.Add(Instantiate(grunt, new Vector3(spawnx, spawny, 0), Quaternion.identity));
        }
        
        for (int i = 0; i < lc; i++)
        {
            spawnx = GetRandom(-10, 10);
            spawny = GetRandom(-10, 10);
            enemies.Add(Instantiate(lion, new Vector3(spawnx, spawny, 0), Quaternion.identity));
        }
        
        for (int i = 0; i < bc; i++)
        {
            spawnx = GetRandom(-10, 10);
            spawny = GetRandom(-10, 10);
            enemies.Add(Instantiate(brawler, new Vector3(spawnx, spawny, 0), Quaternion.identity));
        }
        
        for (int i = 0; i < sc; i++)
        {
            spawnx = GetRandom(-10, 10);
            spawny = GetRandom(-10, 10);
            enemies.Add(Instantiate(swordsman, new Vector3(spawnx, spawny, 0), Quaternion.identity));
        }
        
        
    }

    
}


