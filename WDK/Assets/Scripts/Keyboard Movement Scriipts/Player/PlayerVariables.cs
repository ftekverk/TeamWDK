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
    public float playerHealth = 3f;
    public bool playerAlive;
    public bool playerCanTakeDamage;

    // Start is called before the first frame update
    void Start()
    {
        playerAlive = true;
        playerCanTakeDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0f) playerAlive = false;
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
}
