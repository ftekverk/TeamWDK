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

    bool recoiled;

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
        if (pStates.grounded)
        {
            recoiled = false;
        }
    }

    void FixedUpdate()
    {
        if (pStates.recoiling && !recoiled)
        {
            recoiled = true;
            pStates.recoiling = false;

            rb.velocity = new Vector2((slope.x * recoilForce * .6f), (slope.y * recoilForce));
        }
    }
}
