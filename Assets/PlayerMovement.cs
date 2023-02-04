using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // private instances
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float secondJumpForce;
    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private SpriteRenderer sprite;

    // Boolean to keep track of double jump availability
    [SerializeField] private int maxJump;
    [SerializeField] private bool canJump;
    [SerializeField] private bool onGround;

    // Player's width and height
    private float width, height;
    
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject
        rg = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        // Get the player's width and height
        width = sprite.bounds.size.x;
        height = sprite.bounds.size.y;
        //numJump = maxJump;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        // -1 to +1

        // Horizontal force
        rg.AddForce(horizontalInput * speed * Vector2.right);

        // Flip Sprite
        if (horizontalInput < 0)
        {
            sprite.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            sprite.flipX = false;
        }

        // Jump && Double Jump
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            Debug.Log("First time jump");
            // If the player is on the ground
            int currentJump = maxJump;
            rg.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            currentJump--;
            onGround = false;

            if (Input.GetKeyUp("space") && currentJump > 0) { canJump = true; }

            // If the player has already jumped once and canDoubleJump is true
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                Debug.Log("second time jump");
                // Reset the player's velocity
                currentJump--;
                if (currentJump < 1) { canJump = false; }
                rg.AddForce(Vector2.up * secondJumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onGround = true;
        }
    }
}
    

