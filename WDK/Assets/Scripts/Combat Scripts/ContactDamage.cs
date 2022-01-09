using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    public PlayerVariables playerVariablesScript;
    public EnemyVariables enemyStats;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(enemyStats.enemyCanDoDamage) playerVariablesScript.damagePlayer();
        }
    }
}
