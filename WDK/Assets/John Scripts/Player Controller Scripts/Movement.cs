using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public PlayerStates pStates;
    public DetectInput input;

    Rigidbody2D rb;

    [SerializeField] float speed;

    void Start()
    {
        pStates = GetComponent<PlayerStates>();
        input = GetComponent<DetectInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!pStates.recoiling)
        {
            rb.velocity = new Vector2(input.hInput * speed * Time.deltaTime, rb.velocity.y);
        }  
    }
}
