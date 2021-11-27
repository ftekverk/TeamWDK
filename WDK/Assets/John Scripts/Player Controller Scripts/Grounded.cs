using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    private PlayerStates pStates;

    [SerializeField] Transform feetPos;
    [SerializeField] Transform feetPos2;
    [SerializeField] LayerMask whatIsGround;

    float checkRadius = 1.0f;

    void Start()
    {
        pStates = GetComponent<PlayerStates>();
    }

    void Update()
    {
        if (Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround) || Physics2D.OverlapCircle(feetPos2.position, checkRadius, whatIsGround))
        {
            pStates.grounded = true;
        }
        else
        {
            pStates.grounded = false;
        }
    }
}
