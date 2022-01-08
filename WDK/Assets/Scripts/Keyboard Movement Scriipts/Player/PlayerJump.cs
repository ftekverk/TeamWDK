using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public PlayerVariables playerStats;

    //public Animator animator;
    public Rigidbody2D rb;
    public float jumpForce = 20f;
    public float bootForce = 5000f;
    public Transform head;
    public bool isAlive = true;
    public bool doubleJumpCalled;
    public bool doublejump;  //true if able to double jump



    //Variables to check if grounded
    //public float checkRadius = 0.1f;
    public bool grounded;

    //Used to find direction of our jump
    private Vector2 jumpDirection;

    //check if invincible jump is unlocked

    void Start()
    {
        //animator = gameObject.GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        doubleJumpCalled = false;
        //IsGrounded();
        grounded = playerStats.grounded;
        //Find the direction of our second jump by drawing a vector from body to head.
        jumpDirection = (head.position - transform.position);
        jumpDirection.Normalize();
        jumpDirection = jumpDirection / 2f;

        if ((Input.GetButtonDown("Jump")) && (isAlive == true)) //jump is w, space, up
        {
            if(grounded) FirstJump();
            else if(doublejump) AdditionalJump();
            grounded = false;
        }

    }

    //If we call firstjump, we can then call secondjump
    public void FirstJump()
    {
      doublejump = true;
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    //If we use our secondjump, we can no longer call double jump
    public void AdditionalJump()
    {
        doubleJumpCalled = true;
        doublejump = false;
        //our second jump we move towards the head, maintaining some fraction of our original velocity
        rb.velocity = (jumpDirection * bootForce) + 0.25f*rb.velocity;
    }

    //Check if our character is on the ground
    // private void IsGrounded()
    // {
    //     Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, checkRadius, groundLayer);
    //     if (groundCheck) grounded = true;
    //     else             grounded = false;
    //
    // }
}
