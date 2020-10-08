using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderMob : MonoBehaviour
{

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

    void Start()
    {
        // accessing the SpriteRenderer that is attached to the Gameobject
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        spriteRenderer.sprite = sprite1;

        // set inital anim
        walking = true;
        punching = false;
    }

    void Update()
    {
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

    }

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
            }else if (frameCount == 100)
            {
                frameCount = 0;
            }
            punched = false;
        }
        
    }

}
