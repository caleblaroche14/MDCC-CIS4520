﻿using System.Collections;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // jump vars

    public float scaleSpeed = 3f;

    //public int jumpTime = 50;
    //public int jumpSpeed = 1;
    //public int jumpCount = 0;

    public bool onGround = true;

    public bool jU = false;
    public bool jD = false;

    public float upSpeed = 500f;

    // move vars
    public float speedCap = 100f;
    public float speedx = 0.0f;
    public float speedy = 0.0f;
    public float accel = 10f;


    private Vector2 velocity;
    private Rigidbody2D rb2D;
    private CircleCollider2D hitBox;
    // private List<Collider2D> hitBoxes = new List<Collider2D>();

    // attack range
    public float range = 10;
    public int damage = 20;

    public int count = 0;

    // collider stuff
    public int colliderCount;
    public Collider2D[] hitBoxes = new Collider2D[1];


    // get enemy array

    List<GameObject> ea;
    InitScript ic;
    Health h;



    // ATTACK VARIABLES ----------------------------------
    public List<GameObject> enemyArray;// = new List<GameObject>;
    GameObject e;
    Health eh;
    MobScript ms;
    Vector3 enemyPos;
    //----------------------------------------------------


    // Start is called before the first frame update
    void Start()
    {
        //GameObject mobObj = GameObject.Find("Mob");
        //List<mobObj> mobList;

        GameObject initial = GameObject.Find("init");
        InitScript intiscript = initial.GetComponent<InitScript>();
        enemyArray = intiscript.enemies;

        rb2D = gameObject.GetComponent<Rigidbody2D>();
        velocity = new Vector2(0f, 0f);
        hitBox = GetComponent<CircleCollider2D>();

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        
        //int c = ea.Count;
        //for (int i = 0; i < c; i++)
        //{
        //Health h = ea[i].GetComponent<Health>();
        //Debug.Log("Enemy #" + i + " hp: " + ea[i].hp);
        //ea[i].h.damage();
        //}
        // moving 
        Vector3 pos = transform.position;

        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            //if (Math.Abs(speedx) < speedCap)
            //{
            count++;
            if (Input.GetKey("a"))
            {
                if (speedx > (speedCap * -1))
                {
                    speedx = speedx - accel;
                }
            }
            if (Input.GetKey("d"))
            {
                if (speedx < speedCap)
                {
                    speedx = speedx + accel;
                }
            }
            //Debug.Log(count + ": Speed: x" + speedx);
            //}
        }
        else
        {
            if (Math.Abs(speedx) != 0)
            {
                if (speedx > 0)
                {
                    speedx = speedx - (accel);
                }
                if (speedx < 0)
                {
                    speedx = speedx + (accel);
                }
            }
            else
            {
                speedx = 0;
            }
        }

        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            //if (Math.Abs(speedy) < speedCap)
            //{
            count++;
            if (Input.GetKey("s"))
            {
                if (speedy > (speedCap * -1))
                {
                    speedy = speedy - accel;
                }
            }
            if (Input.GetKey("w"))
            {
                if (speedy < speedCap)
                {
                    speedy = speedy + accel;
                }
            }
            //Debug.Log(count + ": Speed y: " + speedy);
            //}
        }
        else
        {
            if (Math.Abs(speedy) != 0)
            {
                if (speedy > 0)
                {
                    speedy = speedy - (accel);
                }
                if (speedy < 0)
                {
                    speedy = speedy + (accel);
                }
            }
            else
            {
                speedy = 0;
            }
        }

        // jumping 
        //Vector3 scale = transform.localScale;

        // checking to see if jumpCount is 0, if so the obj is on ground
        /*
        if (jumpCount > 0)
        {
            onGround = false;
        }
        else
        {
            onGround = true;
        }
        */


        // checking if key is down or not
        /*
        if (Input.GetKeyDown("space"))
        {
            if (jumpCount == 0)
            {
                jU = true;
                jD = false;
            }
        }
        else
        {

        }
        */
        /*
        // if jumping up
        if (jU == true)
        {
            if (jumpCount < jumpTime)
            {
                jumpCount += jumpSpeed;
                scale.x += scaleSpeed * Time.deltaTime;
                scale.y += scaleSpeed * Time.deltaTime;
                speedy += upSpeed * Time.deltaTime;
            }

            if (jumpCount == jumpTime)
            {
                jU = false;
                jD = true;
            }
        }

        // if going down
        if (jD == true)
        {
            if (onGround != true)
            {
                jumpCount -= jumpSpeed;
                scale.x -= scaleSpeed * Time.deltaTime;
                scale.y -= scaleSpeed * Time.deltaTime;
                speedy -= upSpeed * Time.deltaTime;
            }
        }
        */

        // update list of existing hittable objects
        //hitBox.OnTriggerEnter(hitBoxes);
        //hitBox.OnTriggerExit(hitBoxes);

        //Debug.Log("Speedy: " + speedy);

        // move the obj
        //transform.localScale = scale;
        velocity = new Vector2(speedx, speedy);
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
        transform.position = pos;

        // ATTACK CODE --------------------------------------------------------

        GameObject mobObj = GameObject.Find("Mob");
        for (int i = 0; i < enemyArray.Count; i++)
        {

            e = enemyArray[i];

            if (enemyArray[i] != null)
            {
                eh = e.GetComponent<Health>();
                ms = e.GetComponent<MobScript>();
                //playerPos = p.transform.position;
                enemyPos = e.transform.position;
                float distance = Vector3.Distance(pos, enemyPos);

                //Debug.Log("player to enemy: " + distance);
                if (Input.GetKeyDown("p"))
                {

                    if (distance < range)
                    {
                        eh.damage(damage);

                        
                        ms.isPunched = true;
                        ms.pc = 500;

                        if (pos.x < enemyPos.x)
                        {
                            ms.punchLaunch = 500;
                        }
                        else
                        {
                            ms.punchLaunch = -500;
                        }
                        //Debug.Log("in range");
                    }
                    else
                    {
                        //Debug.Log("Too far away to hit");
                    }
                }
            }


            Debug.Log(eh.hp);
        }

        // --------------------------------------------------------------------
        /*
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.NoFilter();

        int colliderCount = hitBox.OverlapCollider(contactFilter, hitBoxes);
        //Debug.Log("Collider Count: " + colliderCount);
        */
    }

    /*private void OnTriggerEnter2D(Collider2D someCollider)
    {
        Debug.Log("Entered Hitbox");
        if (!hitBoxes.Contains(someCollider))
        {
            hitBoxes.Add(someCollider);
            
        }
    }

    private void OnTriggerExit2D(Collider2D someCollider)
    {
        hitBoxes.Remove(someCollider);
        Debug.Log("Exited Hitbox");
    } */


    // attacking
    public void Attack()
    {
        int count = 0;
        foreach (Collider2D hitMe in hitBoxes)
        {
            //hitMe.gameObject.damage(5);
            count++;
        }

    }
}

