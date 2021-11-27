using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInput : MonoBehaviour
{
    private PlayerStates pStates;
    private Jump jump;
    
    public float hInput;

    void Start()
    {
        pStates = GetComponent<PlayerStates>();
        jump = GetComponent<Jump>();
    }

    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        if (hInput != 0)
        {
            pStates.walking = true;
        }
        else
        {
            pStates.walking = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && pStates.grounded)
        {
            pStates.jumping = true;
        }

        if (!Input.GetKey(KeyCode.Space) && (jump.stepsJumped < jump.jumpSteps) && (jump.stepsJumped > jump.stopJumpThreshold) && pStates.jumping)
        {
            jump.StopJumpQuick();
        }
        else if (!Input.GetKey(KeyCode.Space) && (jump.stepsJumped < jump.stopJumpThreshold) && pStates.jumping)
        {
            jump.StopJumpSlow();
        }
    }
}