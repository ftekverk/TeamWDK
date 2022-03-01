using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb; 
    SpriteRenderer spriteRenderer;

    private PlayerJump1 jumpScript;

    public float hInput;
    public float runSpeed = 10f;
    public float rotateSpeed = 450f;


    //children
    private Transform feet;
    private Transform head;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpScript = GetComponent<PlayerJump1>();
    
        // feet = this.gameObject.transform.GetChild(0).transform;
        // head = this.gameObject.transform.GetChild(1).transform;

    }



    void FixedUpdate()
    {
        hInput = Input.GetAxis("Horizontal");

        //If the player is grounded, allow for horizontal movement

        /* -----TO DO : jumpscript grounded ----*/
        // if (jumpScript.grounded)
        // {
            //Player can't rotate : Fixed Upright
            rb.freezeRotation = true;
            this.transform.rotation = new Quaternion(0,0,0, 1);

            rb.velocity = new Vector2(hInput * runSpeed, rb.velocity.y);
            if (hInput > 0) spriteRenderer.flipX = true;
            else if (hInput < 0) spriteRenderer.flipX = false;
        // }
        // Allow for rotation in the air!
        // else
        // {
        //     rb.freezeRotation = false;
        //     //rotate right
        //     if (Input.GetKey(KeyCode.RightArrow)) transform.Rotate(new Vector3( 0f, 0f, -1f) , rotateSpeed * Time.deltaTime, Space.Self);
        //     //rotate left
        //     else if (Input.GetKey(KeyCode.LeftArrow)) transform.Rotate(new Vector3( 0f, 0f, -1f) , -rotateSpeed * Time.deltaTime, Space.Self);
    
        // }
    }




}
