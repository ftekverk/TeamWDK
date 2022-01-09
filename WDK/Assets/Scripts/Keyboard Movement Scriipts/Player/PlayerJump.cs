using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private PlayerVariables playerStats;

    //public Animator animator;
    public Rigidbody2D rb;
    public float jumpForce = 20f;
    public float bootForce = 5000f;
    public Transform head;
    public bool isAlive = true;
    public bool additionalJumpCalled;
    public bool additionalJump;  //true if able to double jump

    public int pulseJumpsUsed = 0;

    //Variables to check if grounded
    public bool grounded;

    //Used to find direction of our jump
    private Vector2 jumpDirection;

    //check if invincible jump is unlocked
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        //animator = gameObject.GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerStats = GetComponent<PlayerVariables>();
    }


    void Update()
    {
        additionalJumpCalled = false;
        grounded = playerStats.grounded;
        //Find the direction of our second jump by drawing a vector from body to head.
        jumpDirection = (head.position - transform.position);
        jumpDirection.Normalize();
        jumpDirection = jumpDirection / 2f;

        if ((Input.GetButtonDown("Jump")) && (isAlive == true)) //jump is w, space, up
        {
            if(playerStats.grounded) FirstJump();
            else AdditionalJump();
            grounded = false;
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
          rb.velocity = (jumpDirection * bootForce) + 0.25f*rb.velocity;

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
