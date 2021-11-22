using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform feetPos;
    [SerializeField] Transform feetPos2;
    [SerializeField] LayerMask whatIsGround;
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
        {
            playerRb.constraints = ~RigidbodyConstraints2D.FreezeAll;
        }

        if (grounded)
        {
            transform.rotation = upright;
        }
    }

    private void FixedUpdate()
    {
        hInput = Input.GetAxis("Horizontal");

        playerRb.velocity = new Vector2(hInput * speed * Time.deltaTime, playerRb.velocity.y);

        Jump();

        AddForce();
    }

    private void DetectGrounded()
    {
        grounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        grounded = Physics2D.OverlapCircle(feetPos2.position, checkRadius, whatIsGround);
    }

    private void Jump()
    {
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
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, Mathf.Clamp(playerRb.velocity.y, -(Mathf.Abs(fallSpeed)), Mathf.Infinity));
        }

    }

    private void JumpInput()
    {
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
    {
        stepsJumped = 0;
        jumping = false;
    }

    private void StopJumpQuick()
    {
        stepsJumped = 0;
        jumping = false;
        playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
    }

    private void RotatePlayer()
    {
        if (!grounded)
        {
            mousePos = Input.mousePosition;
            mousePos2 = Camera.main.ScreenToWorldPoint(mousePos);

            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mousePos2.y - transform.position.y, mousePos2.x - transform.position.x) * Mathf.Rad2Deg - 90);
        }
    }

    private void DetectMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && leftMouseClicked == false)
        {
            leftMouseClicked = true;
        }
    }

    private void AddForce()
    {
        if (leftMouseClicked)
        {
            if (stepsRecoiled < recoilSteps)
            {
                transform.Translate(Vector3.down * recoilForce);
                stepsRecoiled++;
            }
            else
            {
                stepsRecoiled = 0;
                leftMouseClicked = false;
            }
        }
    }
}
