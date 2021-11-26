using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    //public Animator animator;
    public Rigidbody2D rb;
    public float jumpForce = 20f;
    public float bootForce = 5000f;
    public Transform feet;
    public Transform head;
    public LayerMask groundLayer;
    //public LayerMask enemyLayer;
    public bool isAlive = true;
    //public AudioSource JumpSFX;

    //bool firstjump = true;  //true if we havent used our first jump yet
    bool doublejump = false;  //true if able to double jump
    public float checkRadius = 0.1f;
    public bool grounded;

    //jump towards head
    private Vector2 jumpDirection;

    void Start()
    {
        //animator = gameObject.GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        IsGrounded();
        jumpDirection = head.position - transform.position;
        if ((Input.GetButtonDown("Jump")) && (isAlive == true))
        {
            if(grounded) FirstJump();
            else if(doublejump) SecondJump();
            grounded = false;
        }

    }
    public void FirstJump()
    {
      doublejump = true;
      rb.velocity = Vector2.up * jumpForce;
    }

    public void SecondJump()
    {
        doublejump = false;
        rb.velocity = jumpDirection * bootForce;
    }


    private void IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, checkRadius, groundLayer);
        //Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, 0.05f, enemyLayer);
        if ((groundCheck /*!= null*/) /*|| (enemyCheck != null)*/)
        {
            grounded = true;
        }
        else{
          grounded = false;
        }
    }
}
