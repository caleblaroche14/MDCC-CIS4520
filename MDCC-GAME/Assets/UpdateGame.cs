using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGame : MonoBehaviour
{
    //public GameObject initial;
    public List<GameObject> enemyArray;// = new List<GameObject>;

    // Start is called before the first frame update
    void Start()
    {
        GameObject initial = GameObject.Find("init");
        InitScript intiscript = initial.GetComponent<InitScript>();
        enemyArray = intiscript.enemies;
        //public GameObject init;//GameObject.Find("init");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
