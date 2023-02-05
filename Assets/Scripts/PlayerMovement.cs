using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Animation
    [SerializeField] private Animator _animator;
    private int _movingHash;
    private int _attackHash;

    // private instances
    [SerializeField] private float speed;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float jumpForce;
    [SerializeField] private float grapplingForce;
    [SerializeField] private float secondJumpForce;
    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private SpriteRenderer sprite;

    //attack zone
    [SerializeField] private Collider2D attackZone;

    // Boolean to keep track of double jump availability
    [SerializeField] private int maxJump;
    [SerializeField] private float airDrag;
    [SerializeField] private bool onGround;
    [SerializeField] private bool grappling;

    // Player's width and height
    private int currentJump;
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject
        rg = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        _movingHash = Animator.StringToHash("moving");
        _attackHash = Animator.StringToHash("isAttacking");
        canMove = true;
    }

    void Update()
    {
        Move();
        Attack();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !_animator.GetBool(_attackHash))
        {
            canMove = false;
            _animator.SetBool(_attackHash, true);
        }
    }

    public void StopAttack()
    {
        _animator.SetBool(_attackHash, false);
        canMove = true;
        attackZone.enabled = true;
    }

    public void TurnOffHitbox()
    {
        attackZone.enabled = false;
    }

    private void Move()
    {
        // horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        // -1 to +1

        // Horizontal force
        if (onGround && canMove)
        {
            //Debug.Log("Hello");
            rg.AddForce(horizontalInput * speed * Vector2.right, ForceMode2D.Force);
            if (rg.velocity.magnitude > maxVelocity)
            {
                rg.velocity = new Vector2(horizontalInput * maxVelocity, 0f);
            }
        }

        if (horizontalInput != 0 && onGround && canMove)
        {
            _animator.SetBool(_movingHash, true);
        }
        else
        {
            _animator.SetBool(_movingHash, false);
        }

        // if (!onGround)
        // {
        //     rg.AddForce(horizontalInput * airDrag * Vector2.left, ForceMode2D.Force);
        // }

        // Flip Sprite
        if (horizontalInput < 0)
        {
            //sprite.flipX = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // Jump && Double Jump
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            // If the player is on the ground
            currentJump = maxJump;
            currentJump--;

            //jump with airdrag
            rg.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            onGround = false;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && currentJump > 0 && !onGround)
        {
            // Reset the player's velocity
            currentJump--;

            //jump with air drag
            rg.AddForce(Vector2.up * secondJumpForce, ForceMode2D.Impulse);
        }

        //Land to ground // dragon kick
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            rg.AddForce(Physics.gravity * rg.gravityScale, ForceMode2D.Impulse);
        }
    }

    public void SetOnGround(bool isOnGround)
    {
        onGround = isOnGround;
    }

    public void SetGrappling(bool isGrappling)
    {
        grappling = isGrappling;
    }
}

