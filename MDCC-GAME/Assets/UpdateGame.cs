using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGame : MonoBehaviour
{
    //public GameObject initial;
    public List<GameObject> enemyArray;// = new List<GameObject>;
    GameObject p;
    GameObject e;
    Health eh;

    Vector3 playerPos;
    Vector3 enemyPos;

    // Start is called before the first frame update
    void Start()
    {
        GameObject initial = GameObject.Find("init");
        InitScript intiscript = initial.GetComponent<InitScript>();
        enemyArray = intiscript.enemies;

        p = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        GameObject mobObj = GameObject.Find("Mob");
        for (int i = 0; i < enemyArray.Count; i++)
        {

            e = enemyArray[i];
            eh = e.GetComponent<Health>();

            playerPos = p.transform.position;
            enemyPos = e.transform.position;
            float distance = Vector3.Distance(playerPos, enemyPos);


            if (Input.GetKey("p"))
            {
                //if (distance < p.range)
                //{
                    eh.damage(10);
                //}
            }
            

            Debug.Log(eh.hp);
            
        }
        */
    }
}
