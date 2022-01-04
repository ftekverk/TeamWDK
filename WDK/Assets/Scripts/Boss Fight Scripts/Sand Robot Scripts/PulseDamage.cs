using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseDamage : MonoBehaviour
{
    public SandRobotVariables robotStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Pulse")
        {
            robotStats.damageRobot();
            Debug.Log(robotStats.robotHealth);
        }
    }

}
