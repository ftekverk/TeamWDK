using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{

//currency
//experience

//Things to Transfer to new scene -- anything else?
    public bool invincibleJumpUnlocked = false;
    public float playerHealth = 3f;
    public bool playerAlive;
   
   
    public float runSpeed = 8f;
    public float jumpForce = 1f;
    public float bootForce = 2f;

    public bool playerCanTakeDamage;

    //locations
    private Transform feet;

    //jumping and grounded variables
    public bool grounded;
    public float checkRadius = 0.35f;
    public LayerMask groundLayer;

    //Upgrades
    public int totalJumps;


    // Start is called before the first frame update
    void Start()
    {
        totalJumps = 3;
        playerAlive = true;
        playerCanTakeDamage = true;
        checkRadius = 0.35f;
        feet = this.gameObject.transform.GetChild(0).transform;


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

    public void SavePlayer(){
        GlobalControl.Instance.playerHealth = playerHealth;
        GlobalControl.Instance.totalJumps = totalJumps;
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
