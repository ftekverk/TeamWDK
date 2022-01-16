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
    private PlayerAnimation player_anim;
    public float hInput;
    private float runSpeed;
    [SerializeField] float zRot;
    [SerializeField] float pulseJumpMoveModifier;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerScripts = GetComponent<PlayerVariables>();
        jumpscript = GetComponent<PlayerJump>();
        runSpeed = playerScripts.runSpeed;
        player_anim = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        pulseJumpMoveModifier = PulseJumpMoveModify();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hInput = Input.GetAxis("Horizontal");

        //tell animator the player horizontal input
        player_anim.speed = hInput;
        //if we're grounded we can move horizontally
        if (jumpscript.grounded || jumpscript.pulseJumpsUsed == 0)// || (jumpscript.pulseJumpsUsed > 0 /*&& rb.velocity.y < 5*/ && hInput != 0))
        {
            rb.velocity = new Vector2(hInput * runSpeed, rb.velocity.y);
            if (hInput > 0) spriteRenderer.flipX = true;
            else if (hInput < 0) spriteRenderer.flipX = false;
        }
        else if (jumpscript.pulseJumpsUsed > 0 && hInput !=0)// && Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y) < 18)
        {
            rb.velocity = new Vector2(hInput * (pulseJumpMoveModifier * .01f + 1f) * runSpeed, rb.velocity.y);
        }
    }

    float PulseJumpMoveModify()
    { // This function returns a number between 0 and 90 based on the player's rotation
        float modifier;

        zRot = transform.localEulerAngles.z;
        if (zRot > 180)
        { // This keeps zRot in between 180 and -180
            zRot = zRot - 360;
        }
        modifier = Mathf.Abs(Mathf.Abs(90 - Mathf.Abs(zRot)) - 90); // basically means if they player is horizontal, the modifier will be closer to 90, if they are vertical it will be closer to 0
                                                                    // ||90 - zRot||-90|
        return modifier;
    }



}
