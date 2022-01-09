using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    private float hMove;


     private PlayerVariables playerScripts;
    private PlayerJump jumpscript;
    private float hInput;
    private float runSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerScripts = GetComponent<PlayerVariables>();
        jumpscript = GetComponent<PlayerJump>();
        runSpeed = playerScripts.runSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hInput = Input.GetAxis("Horizontal");
        //if we're grounded we can move horizontally
        if (jumpscript.grounded || jumpscript.pulseJumpsUsed == 0){
            rb.velocity = new Vector2(hInput * runSpeed, rb.velocity.y);
            if (hInput > 0) spriteRenderer.flipX = true;
            else if (hInput < 0) spriteRenderer.flipX = false;
        }
    }



}
