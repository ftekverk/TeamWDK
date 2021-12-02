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
    Vector2 tempVel;

    [SerializeField] float recoilForce;
    [SerializeField] float temp;

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
    }

    void FixedUpdate()
    {
        if (pStates.recoiling)
        {
            tempVel = rb.velocity;

            jump.StopJumpQuick();

            temp = slope.x * recoilForce;

            rb.velocity = new Vector2(temp + 10, slope.y * recoilForce);

            pStates.recoiling = false;
        }
    }
}
