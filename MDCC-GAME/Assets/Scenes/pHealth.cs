using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pHealth : MonoBehaviour
{

    public int hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void damagePlayer(int damage)
    {
        hp -= damage;
    }

    public void healPlayer(int heals)
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
        //Debug.Log("Health: " + hp);
    }
}
