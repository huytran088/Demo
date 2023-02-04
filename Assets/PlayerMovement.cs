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
    [SerializeField] private float airDrag;
    [SerializeField] private bool onGround;

    // Player's width and height
    private int currentJump;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject
        rg = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
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
            currentJump = maxJump;
            currentJump--;
            rg.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onGround = false;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && currentJump >  0 && !onGround)
        {
            Debug.Log("second time jump");
            // Reset the player's velocity
            currentJump--;
            rg.AddForce(Vector2.up * secondJumpForce, ForceMode2D.Impulse);
        }
        
        //Land to ground // dragon kick
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            rg.AddForce(Physics.gravity * rg.gravityScale, ForceMode2D.Impulse);
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
    

