using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump1 : MonoBehaviour
{
    Rigidbody2D rb;
    public bool grounded;
    public float checkRadius = 0.35f;
    public LayerMask groundLayer;


    private Transform feet;
    private Transform head;

    public float jumpForce = 10f;
    public float doublejumpForce = 20f;
    private Vector2 doubleJumpDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // feet = this.gameObject.transform.GetChild(0).transform;
        // head = this.gameObject.transform.GetChild(1).transform;
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded();

        if (Input.GetButtonDown("Jump")){
            if(grounded){
                FirstJump();
                grounded = false;
            }
            else{
                AirJump();
            }
        }

    }

    //If we call firstjump, we can then call secondjump
    public void FirstJump()
    {
        //change velocity
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public void AirJump()
    {

        //TO-DO
        // A double jump should set our velocity towards our head
        // doubleJumpDirection = 
        // rb.velocity = 
    }


    private void IsGrounded()
    {
        //groundLayer is set to "Ground"

        //TO DO
        // Collider2D groundCheck = 
        // if (groundCheck) grounded = true;
        // else             grounded = false;
    }
}









//AirJump TODO
// doubleJumpDirection = head.position - feet.position;
// rb.velocity = doubleJumpDirection * doublejumpForce;

//ISGrounded TO DO
// Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, checkRadius, groundLayer);


