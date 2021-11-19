using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D playerRb;
    public Transform feetPos;
    public LayerMask whatIsGround;
    public GameObject breakableGround;

    private Vector3 velocity;

    public float speed;
    public float jumpForce;
    public float checkRadius;
    public float jumpTime;
    private float jumpTimeCounter;
    private float doubleJumpTimeCounter;
    public float groundPoundForce;

    public bool isGrounded;
    private bool isJumping;
    private bool isDoubleJumping;
    public bool isPounding;
    public bool hasGPPowerup;

    //=================================================================================================================

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        isPounding = false;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = playerRb.velocity;
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        // Invisible circle at base of player model detects ground and sets true if detecting ground, or false if not

        if (isGrounded == true)
        {
            isDoubleJumping = false;
        }

        Jump();

        DoubleJump();

        GroundPound();

    }

    private void FixedUpdate()
    {
        float hInput = Input.GetAxis("Horizontal");

        playerRb.velocity = new Vector2(hInput * speed * Time.deltaTime, playerRb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        { // Resets the player position when they touch a spike
            transform.position = new Vector3(-60, -2, 0);
        }

        if (collision.gameObject.CompareTag("BreakableGround") && isPounding == true)
        { // If the player is groundpounding, they destroy the breakable ground and are no longer groundpounding
            Destroy(collision.gameObject);
            isPounding = false;
        }

        if (collision.gameObject.CompareTag("Ground"))
        { // If the player is groundpounding and collides with regular ground, they are no longer groundpounding
            isPounding = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GPPowerup"))
        { // If the player touches the groundpound powerup, it is destroyed, the player gets the groundpound powerup, and a console message is displayed
            Destroy(collision.gameObject);
            hasGPPowerup = true;
            Debug.Log("Press F to ground-pound!");
        }
    }

    //=================================================================================================================

    void Jump()
    { // Function that is called every frame and adds value to the player's y velocity
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        { // If the player is grounded and space is pressed, they are considered to be jumping, the jump time counter is set to the jumpTime variable,
          // and the player's y velocity is set to the jump force variable.
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerRb.velocity = Vector2.up * jumpForce; // This is basically (0,1) * jumpforce, changing only the y value.
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        { // If the player is holding space and is already jumping
            if (jumpTimeCounter > 0)
            { // If the jump time counter hasn't reached 0, the player's y velocity gets increased be the jump force variable
              // and the jump time counter is decreased by the time.
                playerRb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            { // If the jump time counter is not grreater than 0, the player is no longer considered to be jumping.
                isJumping = false;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space))
        { // If the player releases the space key, they are no longer considered to be jumping.
            isJumping = false;
        }
    }

    void DoubleJump()
    {
        if (isDoubleJumping == false && (isJumping == true || (isJumping == false && isGrounded == false)))
        { // If the player is not double jumping and is either jumping or not jumping and off the ground
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isDoubleJumping = true;
                velocity.y = 0; // Velocity has to be changed through a variable
                playerRb.velocity = velocity;
                doubleJumpTimeCounter = jumpTime;
                playerRb.velocity = Vector2.up * jumpForce;



            }
        }
    }

    void GroundPound()
    { // Function that is called every frame and lets the player press f to groundpound if they are not on ground
        if (Input.GetKeyDown(KeyCode.F) && hasGPPowerup == true && isGrounded == false)
        {
            playerRb.AddForce(Vector2.down * groundPoundForce, ForceMode2D.Impulse);

            isPounding = true;
        }
    }
}

