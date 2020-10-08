using System.Collections;
using System.Collections.Generic;
using System;
//using System.Random;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float range = 10f;
    
    // movement stuff
    public float speedCap = 4f;
    public float speedx = 0.0f;
    public float speedy = 0.0f;
    public float accelStart = 1f;
    public float buffer = 5f;
    private float accel;

    public float maxSpeedPercent = 10.25f;
    public float minSpeedPercent = .005f;

    System.Random rnd = new System.Random();

    // attack stuff
    public int damage = 5;
    Vector3 playerPos;
    public int coolDown = 0;
    public int coolDownTime = 200;

    private SpriteRenderer mySpriteRenderer;

    public List<GameObject> enemyArray;
    private bool closeToEnemiesX = false;
    public bool closeToEnemiesY = false;

    // animation stuff 
    public Sprite sprite1; // default

    // string that holds punching, walking, etc to tell the program what it should be doing
    public string animType;

    // the count of the frame -_(-_-)_-
    int frameCount = 0;


    public Sprite walk1; // Drag your first sprite here
    public Sprite walk2; // Drag your second sprite here
    public Sprite walk3; // Drag your third sprite here

    public Sprite punch1;
    public Sprite punch2;
    public bool punched = false;

    // bool of what mob is doing
    public bool walking;
    public bool punching;

    private SpriteRenderer spriteRenderer;

    // init player and script variables 
    GameObject p;
    pHealth ph;


    void Start()
    {
        // get player object and script
        p = GameObject.FindWithTag("Player");
        ph = p.GetComponent<pHealth>();

        // get enemy array
        GameObject initial = GameObject.Find("init");
        InitScript intiscript = initial.GetComponent<InitScript>();
        enemyArray = intiscript.enemies;


        mySpriteRenderer = GetComponent<SpriteRenderer>();
        
        accel = UnityEngine.Random.Range((accelStart * minSpeedPercent), (accelStart * maxSpeedPercent));

        // accessing the SpriteRenderer that is attached to the Gameobject
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite1;

        // set inital anim
        walking = true;
        punching = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // animate
        if (walking == true)
        {
            animType = "walking";
        }
        else if (punching == true)
        {
            animType = "punching";
        }
        // call method to change sprite RenderCharacter(action,frames)
        RenderCharacter(animType);

        // move mob
        if (p)
        {
            playerPos = p.transform.position;
        }
        else
        {
            Debug.Log("Can't Find Player");
        }

        // find position
        Vector3 pos = transform.position;


        // find distances between mob and player
        float distance = Vector3.Distance(playerPos, pos);//Math.Abs(Math.Abs(playerPos.x) - Math.Abs(pos.x));
        //float distanceY = Math.Abs(Math.Abs(playerPos.y) - Math.Abs(pos.y));
        //Debug.Log("Distance from player: " + distance);
     

        // if distance is greater than range

        
        if (distance > (range))
        {
            // set anim type
            walking = true;
            punching = false;

            if (playerPos.x+buffer >= pos.x && playerPos.x-buffer <= pos.x)
            {
                speedx = 0;
                //Debug.Log("Stuck here");
            }
            else
            {

                if (playerPos.x < pos.x)
                {
                    if (speedx > (speedCap * -1))
                    {
                        speedx = speedx - accel;
                    }

                }

                if (playerPos.x > pos.x)
                {
                    if (speedx < speedCap)
                    {

                        speedx = speedx + accel;
                    }
                }
            }

            if (playerPos.y+buffer >= pos.y && playerPos.y-buffer <= pos.y)
            {
                speedy = 0;
            }
            else
            {
                if (playerPos.y < pos.y)
                {
                    if (speedy > (speedCap * -1))
                    {
                        speedy = speedy - accel;
                    }
                }
                if (playerPos.y > pos.y)
                {
                    if (speedy < speedCap)
                    {
                        speedy = speedy + accel;
                    }
                }
            }
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



        // attack player if in range
        coolDown += 1;
        if (distance < range)
        {
            // set anim type
            punching = true;
            walking = false;

            if (punched == true)
            {
                ph.damagePlayer(damage);
                coolDown = 0;

                // set punch back so it only damages player on one frame;
                punched = false;
            }
        }
        //Debug.Log("Mob cooldown: " + coolDown);

        // adjust pos
        pos.y += speedy * Time.deltaTime;
        pos.x += speedx * Time.deltaTime;
 
        // move mob
        transform.position = pos;

        // flip the sprite
        if (speedx < .3)
        {
            mySpriteRenderer.flipX = true;
        }
        if (speedx > .3)
        {
            mySpriteRenderer.flipX = false;
        }

        //Debug.Log("SpeedX: " + speedx);
        Debug.Log("Walking: " + walking);
        Debug.Log("Punching: " + punching);


    }

    // render the character, damage player if animation is punching
    void RenderCharacter(string t)
    {

        frameCount++;
        if (t == "walking")
        {
            Debug.Log("walking");
            if (frameCount == 1)
            {
                spriteRenderer.sprite = walk1;
            }
            else if (frameCount == 50)
            {
                spriteRenderer.sprite = walk2;
            }
            else if (frameCount == 100)
            {
                spriteRenderer.sprite = walk3;
            }
            else if (frameCount == 150)
            {
                frameCount = 0;
            }
        }
        if (t == "punching")
        {
            Debug.Log("punching");
            if (frameCount == 1)
            {
                spriteRenderer.sprite = punch1;
            }
            else if (frameCount == 50)
            {
                spriteRenderer.sprite = punch2;
                punched = true;
            }
            else if (frameCount == 100)
            {
                frameCount = 0;
            }
        }

    }

}
