using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public int damage = 5;

    public int coolDownTime = 600;
    public int coolDown;

    public float distanceX;
    public float distanceY;
    // Start is called before the first frame update
    void Start()
    {
        coolDown = coolDownTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        var playerZ = GameObject.Find("player");
        Vector3 playerPos;

        //GameObject initial = GameObject.Find("init");
        pHealth hpScript = playerZ.GetComponent<pHealth>();
        int playerHp = hpScript.hp;

        if (playerZ)
        {
            playerPos = playerZ.transform.position;
            float distanceX = Math.Abs(Math.Abs(playerPos.x) - Math.Abs(pos.x));
            float distanceY = Math.Abs(Math.Abs(playerPos.y) - Math.Abs(pos.y));
        }


        if ((distanceX < .5) && (distanceY < .5))
        {
            if (coolDown > 0)
            {
                //playerHp -= damage;
            }
        }
        else
        {
            coolDownTime = coolDown;
        }
        // get player health to move

        playerHp = playerHp - damage;//1000;//-= damage;
        Debug.Log("Health: " + playerHp);
    }
}
