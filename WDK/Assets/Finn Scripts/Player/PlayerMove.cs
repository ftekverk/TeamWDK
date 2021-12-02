using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float runSpeed = 8f;
    private float hMove;
    public PlayerJump jumpscript;

    //KeyCode rightMove = KeyCode.RightArrow;
    //KeyCode leftMove = KeyCode.LeftArrow;

    public float hInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hInput = Input.GetAxis("Horizontal");
        //if we're grounded we can move horizontally
        if (jumpscript.grounded){
            rb.velocity = new Vector2(hInput * runSpeed, rb.velocity.y);
            if (hInput > 0) spriteRenderer.flipX = true;
            else if (hInput < 0) spriteRenderer.flipX = false;
        }
    }


   
}
