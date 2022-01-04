using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandRobotVariables : MonoBehaviour
{

    public float robotHealth;
    public float robotState;  //if boss has multiple stages, maybe we can change this number.
    public bool robotCanTakeDamage;
    public bool robotCanDoDamage;

    // Start is called before the first frame update
    void Start()
    {
        robotHealth = 3f;
        robotState = 1f;
        robotCanTakeDamage = true;
        robotCanDoDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(robotHealth < 1)
        {
            robotCanTakeDamage = false;
            robotCanDoDamage = false;
        }
    }

    public void damageRobot()
    {
        if (robotCanTakeDamage) StartCoroutine(damageDelay());
    }

    IEnumerator damageDelay()
    {
        if (robotHealth >= 1 && robotCanTakeDamage)
        {
            robotHealth--;
        }
        robotCanTakeDamage = false;
        yield return new WaitForSeconds(2f);
        robotCanTakeDamage = true;
    }
}
