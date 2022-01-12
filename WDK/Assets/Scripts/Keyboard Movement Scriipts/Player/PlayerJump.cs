using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private PlayerVariables playerStats;
    private PlayerMove playerMove;
    private PlayerRotate rotate;

    //public Animator animator;
    public Rigidbody2D rb;

    public Transform head;
    public bool additionalJumpCalled;
    public bool additionalJump;  //true if able to double jump

    public int pulseJumpsUsed = 0;

    //Variables to check if grounded
    public bool grounded;

    private float jumpForce;
    private float bootForce;
    //Used to find direction of our jump
    private Vector2 jumpDirection;

    //check if invincible jump is unlocked
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        //animator = gameObject.GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerStats = GetComponent<PlayerVariables>();
        rotate = GetComponent<PlayerRotate>();
        playerMove = GetComponent<PlayerMove>();

        jumpForce = playerStats.jumpForce;
        bootForce = playerStats.bootForce;
    }


    void Update()
    {
        additionalJumpCalled = false;
        grounded = playerStats.grounded;
        //Find the direction of our second jump by drawing a vector from body to head.
        jumpDirection = (head.position - transform.position);
        jumpDirection.Normalize();
        jumpDirection = jumpDirection / 2f;

        if (!rotate.mouseForRotation)
        {
            if (Input.GetButtonDown("Jump")) //jump is w, space, up
            {
                if (playerStats.grounded) FirstJump();
                else AdditionalJump();
                grounded = false;
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && playerStats.grounded)
            {
                FirstJump();
                grounded = false;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                AdditionalJump();
                grounded = false;
            }
            
        }
    }

    //If we call firstjump, we can then call secondjump
    public void FirstJump()
    {
      additionalJump = true;
      pulseJumpsUsed = 0;
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    //If we use our secondjump, we can no longer call double jump
    public void AdditionalJump()
    {
        if(additionalJump){ //if we have another jump
          additionalJumpCalled = true;
          //count how many pulse jumps we've used
          pulseJumpsUsed++;
          if(pulseJumpsUsed >= playerStats.totalJumps){
              additionalJump = false; //no more jumps allowed
          }

          //if invincible jump
          if(playerStats.invincibleJumpUnlocked){
              StartCoroutine(immunityDelay());
          }
            //our second jump we move towards the head, maintaining some fraction of our original velocity
            //rb.velocity = (jumpDirection * bootForce) + 0.25f*rb.velocity;
            rb.velocity = new Vector2((jumpDirection.x * bootForce) + (.25f * rb.velocity.x),(jumpDirection.y * bootForce) + (.25f * rb.velocity.y)); // This is the same thing(I think) but easier to adjust in the future - J

        }

    }



    IEnumerator immunityDelay()
    {
        playerStats.playerCanTakeDamage = false;
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.25f);
        playerStats.playerCanTakeDamage = true;
        spriteRenderer.enabled = true;
    }

}
