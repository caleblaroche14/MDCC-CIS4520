using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // This function is called by Unity every frame the component is enabled
    private void Update()
    {
        // if the A key was pressed this frame
        if (Input.GetKeyDown(KeyCode.A))
        {
            // if the variable isn't empty (we have a reference to our SpriteRenderer
            if (mySpriteRenderer != null)
            {
                // flip the sprite
                mySpriteRenderer.flipX = true;
            }
        }
        // if the A key was pressed this frame
        if (Input.GetKeyDown(KeyCode.D))
        {
            // if the variable isn't empty (we have a reference to our SpriteRenderer
            if (mySpriteRenderer != null)
            {
                // flip the sprite
                mySpriteRenderer.flipX = false;
            }
        }
    }
}

