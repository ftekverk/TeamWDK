using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public PlayerStates pStates;
    public DetectInput input;

    Rigidbody2D rb;

    [SerializeField] float speed;

    [SerializeField] bool leftClick;

    void Start()
    {
        pStates = GetComponent<PlayerStates>();
        input = GetComponent<DetectInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            leftClick = true;
        } else
        {
            leftClick = false;
        }
    }

    void FixedUpdate()
    {
        if (leftClick == false && !pStates.recoiling)
        {
            rb.velocity = new Vector2(input.hInput * speed * Time.deltaTime, rb.velocity.y);
        }  
    }
}
