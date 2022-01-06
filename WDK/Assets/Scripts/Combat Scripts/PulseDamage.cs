using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseDamage : MonoBehaviour
{
    public EnemyVariables enemyStats;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Pulse")
        {
            enemyStats.damageEnemy();
        }
    }

}
