using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVariables : MonoBehaviour
{

    public float enemyHealth = 3f;  //set health of enemy in inspector!!!!!
    public float enemyState;  //if boss has multiple stages, maybe we can change this number. Use this variable in another controller script.
    public bool enemyCanTakeDamage;
    public bool enemyCanDoDamage;

    // Start is called before the first frame update
    void Start()
    {
        enemyCanTakeDamage = true;
        enemyCanDoDamage = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damageEnemy()
    {
        if (enemyCanTakeDamage) StartCoroutine(damageDelay());
    }

    IEnumerator damageDelay()
    {
        if (enemyHealth >= 1 && enemyCanTakeDamage)
        {
            enemyHealth--;
        }
        enemyCanTakeDamage = false;
        yield return new WaitForSeconds(2f);
        enemyCanTakeDamage = true;
    }
}
