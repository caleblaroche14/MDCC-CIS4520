using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    private CircleCollider2D hitBox;
    public float x = .25f;
    public float y = -2.384186e-07f;

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        hitBox = GetComponent<CircleCollider2D>();
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
                hitBox.offset = new Vector2(-x, y);

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
                hitBox.offset = new Vector2(x, y);
            }
        }
    }
}

