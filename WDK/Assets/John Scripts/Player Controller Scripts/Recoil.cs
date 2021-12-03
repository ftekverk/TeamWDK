using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    private PlayerStates pStates;
    private DetectInput input;
    private Jump jump;

    [SerializeField] Transform pos2;
    Rigidbody2D rb;
    [SerializeField] Vector2 slope;
    Vector2 tempVel = new Vector2(0,0);

    [SerializeField] float recoilForce;

    [SerializeField]int recoilSteps;
    int stepsRecoiled = 0;

    void Start()
    {
        pStates = GetComponent<PlayerStates>();
        input = GetComponent<DetectInput>();
        jump = GetComponent<Jump>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        slope = pos2.position - transform.position;

        if (pStates.recoiling && stepsRecoiled >= recoilSteps)
        {
            pStates.recoiling = false;
            stepsRecoiled = 0;

            tempVel = new Vector2(0, 0);
            jump.StopJumpQuick();
        }
    }

    void FixedUpdate()
    {
        if (pStates.recoiling)
        {
            if (tempVel == new Vector2(0, 0))
            {
                tempVel = rb.velocity;
            }

            jump.StopJumpQuick();

            rb.velocity = (slope * recoilForce) + .25f * tempVel;

            stepsRecoiled++;
        }
    }
}
