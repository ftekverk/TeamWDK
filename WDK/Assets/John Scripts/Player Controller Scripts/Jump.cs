using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private PlayerStates pStates;

    Rigidbody2D rb;

    public int jumpSteps;
    public int stepsJumped = 0;

    [SerializeField] float jumpSpeed;
    [SerializeField] float fallSpeed;
    public float stopJumpThreshold = 7;

    void Start()
    {
        pStates = GetComponent<PlayerStates>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (pStates.jumping)
        {
            if (stepsJumped < jumpSteps)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                stepsJumped++;
            }
            else
            {
                StopJumpSlow();
            }
        }

        if (rb.velocity.y < -(Mathf.Abs(fallSpeed)))
        {
            //rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -(Mathf.Abs(fallSpeed)), Mathf.Infinity));
        }
    }

    public void StopJumpSlow()
    {
        stepsJumped = 0;
        pStates.jumping = false;
    }

    public void StopJumpQuick()
    {
        stepsJumped = 0;
        pStates.jumping = false;
        rb.velocity = new Vector2(rb.velocity.x, 0);
    }
}
