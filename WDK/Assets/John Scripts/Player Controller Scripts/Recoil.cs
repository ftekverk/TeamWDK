using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    private PlayerStates pStates;
    private DetectInput input;

    [SerializeField] Transform pos2;
    Rigidbody2D rb;

    Vector2 slope;

    void Start()
    {
        pStates = GetComponent<PlayerStates>();
        input = GetComponent<DetectInput>();
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
            rb.velocity = new Vector2(slope.x * 10, slope.y * 10);
        }
    }
}
