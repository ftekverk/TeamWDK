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

    bool firstjump = true;  //true if we havent used our first jump yet
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
        grounded = IsGrounded();
        jumpDirection = head.position - transform.position;
        if ((Input.GetButtonDown("Jump")) && (grounded || doublejump) && (isAlive == true))
        {
            Jump();
            // animator.SetTrigger("Jump");
            // JumpSFX.Play();
        }


    }

    public void Jump()
    {
        grounded = false;
        if(firstjump){
          rb.velocity = Vector2.up * jumpForce;
          firstjump = false;
          doublejump = true;
        }
        else{
          firstjump = true;
          doublejump = false;
          rb.velocity = jumpDirection * bootForce;
        }



        //Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        //rb.velocity = movement;
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, checkRadius, groundLayer);
        //Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, 0.05f, enemyLayer);
        if ((groundCheck /*!= null*/) /*|| (enemyCheck != null)*/)
        {
            firstjump = true;
            doublejump = true; //allowed to double jump
            grounded = true;
            return true;
        }
        return false;
    }
}
