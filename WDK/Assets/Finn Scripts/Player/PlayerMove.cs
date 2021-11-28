using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public float runSpeed = 10f;
    private float hMove;
    public PlayerJump jumpscript;

    KeyCode rightMove = KeyCode.RightArrow;
    KeyCode leftMove = KeyCode.LeftArrow;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if we're grounded we can move horizontally
        if(jumpscript.grounded){
          if(Input.GetKey(rightMove)){
              rb.velocity = new Vector2(runSpeed, rb.velocity.y);
              spriteRenderer.flipX = true;
          }
          if(Input.GetKey(leftMove)){
              rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
              spriteRenderer.flipX = false;
          }
        }


    }
}
