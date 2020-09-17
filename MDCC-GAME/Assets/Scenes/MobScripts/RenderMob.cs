using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderMob : MonoBehaviour
{

    public Sprite sprite1; // default

    int walkCount = 0;
    public Sprite walk1; // Drag your first sprite here
    public Sprite walk2; // Drag your second sprite here
    public Sprite walk3; // Drag your second sprite here


    public Sprite jump1;

    public bool walking = true;
    public bool jumping = false;
    public bool attacking = false;

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
        if (walking == true)
        {
            walkCount++;
            if (walkCount == 1)
            {
                spriteRenderer.sprite = walk1;
            }
            else if (walkCount == 50)
            {
                spriteRenderer.sprite = walk2;
            }
            else if (walkCount == 100)
            {
                spriteRenderer.sprite = walk3;

            }
            else if (walkCount == 150)
            {
                walkCount = 0;
            }
        }
    }

}
