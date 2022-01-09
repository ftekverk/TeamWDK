using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
//a script to store and update player variables like
//Grounded
//Is alive
//total health
//currency
//experience
//double jump allowed?

    public float runSpeed = 8f;
    public float jumpForce = 1f;
    public float bootForce = 2f;

    public float playerHealth = 3f;
    public bool playerAlive;
    public bool playerCanTakeDamage;

    //locations
    public Transform head;
    public Transform feet;

    //jumping and grounded variables
    public bool grounded;
    public float checkRadius = 0.35f;
    public LayerMask groundLayer;

    //Upgrades
    public int totalJumps;
    public bool invincibleJumpUnlocked = false;


    // Start is called before the first frame update
    void Start()
    {
        totalJumps = 3;
        playerAlive = true;
        playerCanTakeDamage = true;
        checkRadius = 0.35f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0f) playerAlive = false;
        IsGrounded();
    }


    public void damagePlayer()
    {
        if (playerCanTakeDamage) StartCoroutine(damageDelay());
    }

    IEnumerator damageDelay()
    {
        if (playerHealth >= 1 && playerCanTakeDamage)
        {
            playerHealth--;
        }
        playerCanTakeDamage = false;
        yield return new WaitForSeconds(2f);
        playerCanTakeDamage = true;
    }

    private void IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, checkRadius, groundLayer);
        if (groundCheck) grounded = true;
        else             grounded = false;
    }

}
