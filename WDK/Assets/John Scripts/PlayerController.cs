using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform feetPos;
    [SerializeField] Transform feetPos2;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject bullet;
                     Rigidbody2D playerRb;
                     Quaternion upright;
                     Vector3 mousePos;
                     Vector3 mousePos2;
                     Vector3 playerPos;

    [SerializeField] int jumpSteps;
                     int stepsJumped = 0;
    [SerializeField] int recoilSteps;
                     int stepsRecoiled = 0;

    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float checkRadius;
    [SerializeField] float fallSpeed;
    [SerializeField] float recoilForce;
                     float stopJumpThreshold = 7;
                     float hInput;
                     float angle;

                     bool jumping;
                     bool grounded;
                     bool leftMouseClicked;
                     bool bulletSpawned;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        upright = transform.rotation;
    }

    void Update()
    {
        RotatePlayer();

        DetectGrounded();

        JumpInput();

        DetectMouseClick();

        if (jumping)
        { // If the player is jumping they are able to rotate on the z-axis
            playerRb.constraints = ~RigidbodyConstraints2D.FreezeAll;
        }

        if (grounded)
        {  // If the player is grounded their rotation is reset to what it was when this script started
            transform.rotation = upright;
        }
    }

    private void FixedUpdate()
    {
        hInput = Input.GetAxis("Horizontal");

        if (leftMouseClicked == false)
        { // Simple left/right movement
            playerRb.velocity = new Vector2(hInput * speed * Time.deltaTime, playerRb.velocity.y);
        }
        
        Jump();

        AddForce();

        if (leftMouseClicked == true)
        { // if the player is recoiling, their y velocity is kept to 0
            playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
        }
    }

    private void DetectGrounded()
    { // 2 circles to detect ground because the player can land on their side
        grounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        grounded = Physics2D.OverlapCircle(feetPos2.position, checkRadius, whatIsGround);
    }

    private void Jump()
    { // If the player is jumping they either continue to jump or call the StopJumpSlow function
        if (jumping)
        {
            if (stepsJumped < jumpSteps)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpSpeed);
                stepsJumped++;
            }
            else
            {
                StopJumpSlow();
            }
        }

        if (playerRb.velocity.y < -(Mathf.Abs(fallSpeed)))
        { // The player's y velocity is kept at or above -45
            playerRb.velocity = new Vector2(playerRb.velocity.x, Mathf.Clamp(playerRb.velocity.y, -(Mathf.Abs(fallSpeed)), Mathf.Infinity));
        }

    }

    private void JumpInput()
    { // Listens for space bar input every frame, or the lacktherof
      // Jump stops differently based on how long the player has been jumping
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jumping = true;
        }

        if (!Input.GetKey(KeyCode.Space) && stepsJumped < jumpSteps && stepsJumped > stopJumpThreshold && jumping)
        {
            StopJumpQuick();
        }

        else if (!Input.GetKey(KeyCode.Space) && stepsJumped < stopJumpThreshold && jumping)
        {
            StopJumpSlow();
        }
    }

    private void StopJumpSlow()
    { // Causes the player stop in the air for a moment before falling
        stepsJumped = 0;
        jumping = false;
    }

    private void StopJumpQuick()
    { // Sets the player's y velocity to 0, so they begin falling immediately
        stepsJumped = 0;
        jumping = false;
        playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
    }

    private void RotatePlayer()
    { //Rotates the player toward the mouse cursor
        if (!grounded)
        {
            mousePos = Input.mousePosition;
            mousePos2 = Camera.main.ScreenToWorldPoint(mousePos);

            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mousePos2.y - transform.position.y, mousePos2.x - transform.position.x) * Mathf.Rad2Deg - 90);
        }
    }

    private void DetectMouseClick()
    { // Listens for left mouse click every frame, if it is detected the player's jump is ended
        if (Input.GetMouseButtonDown(0) && leftMouseClicked == false)
        {
            leftMouseClicked = true;

            StopJumpQuick();
        }
    }

    private void AddForce()
    { // If the left mouse button was clicked the player moves "down" each frame until they have reached the recoilSteps amount
        if (leftMouseClicked)
        {
            if (stepsRecoiled < recoilSteps)
            {
                transform.Translate(Vector3.down * recoilForce);
                stepsRecoiled++;

                Instantiate(bullet, spawner.transform, )
            }
            else
            {
                stepsRecoiled = 0;
                leftMouseClicked = false;
                playerRb.velocity = new Vector2(0, playerRb.velocity.y);
            }
        }
    }
}
