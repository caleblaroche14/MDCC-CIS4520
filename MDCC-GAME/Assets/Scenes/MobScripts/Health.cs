

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    public int hp = 100;
    public UpdateGame theGame;

    // Start is called before the first frame update
    void Start()
    {
        GameObject thisScript = GameObject.Find("update");
        theGame = thisScript.GetComponent<UpdateGame>();
    }

    public void damage(int damage)
    {
        hp -= damage;

    }

    public void heal(int heals)
    {
        hp += heals;
    }


    public int getHealth()
    {
        return hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            theGame.EnemyDefeated();
        }
        //Debug.Log("Health: " + hp);
    }



}
