﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderChar : MonoBehaviour
{

    public Sprite sprite1; // default

    int walkCount = 0;
    int punchCount = 0;
    public Sprite walk1; // Drag your first sprite here
    public Sprite walk2; // Drag your second sprite here
    public Sprite walk3; // Drag your third sprite here

    public Sprite punch1;// Drag punch sprite one here
    public Sprite punch2;// Drag punch sprite two here


    public Sprite jump1;

    public bool walking = true;
    public bool jumping = false;
    public bool punching = false;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
                                                         //if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
        spriteRenderer.sprite = sprite1;
    }

    void Update()
    {

        RenderCharacter(); // call method to change sprite

    }

    void RenderCharacter()
    {

        if (Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("w") || Input.GetKey("d")) {
            walking = true;
        }
        else {
            walking = false;
        }

        if (Input.GetKey("p")) {
            punching = true;
        }
        else
        {
            punching = false;
            //walking = true;
            //spriteRenderer.sprite = walk1;
        }

        if (punching == true)
        {

            spriteRenderer.sprite = punch2;

        }

        if (punching == false && walking == false)
        {
            spriteRenderer.sprite = walk1;
        }
    

        if (walking == true)
        {
            
            walkCount++;
            if (walkCount == 1)
            {
                Debug.Log("frame 1" );
                spriteRenderer.sprite = walk1;
            }
            else if (walkCount == 50)
            {
                Debug.Log("frame 2");
                spriteRenderer.sprite = walk2;
            }
            else if (walkCount == 100)
            {
                Debug.Log("frame 3");
                spriteRenderer.sprite = walk3;
                
            }else if(walkCount == 150)
            {
                Debug.Log("frame reset");
                walkCount = 0;
            }

        }

        if (jumping == true)
        {
            spriteRenderer.sprite = jump1;
        }

    }
}
