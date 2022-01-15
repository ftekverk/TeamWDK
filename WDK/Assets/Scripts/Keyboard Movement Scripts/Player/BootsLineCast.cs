using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsLineCast : MonoBehaviour
{
    private LineRenderer lr;

    private BootPulse pulseScript;
    private PlayerVariables playerStats;
    public Vector2 pulseDirection;

    //public LayerMask layersToIgnore;   --WAS HAVING ISSUES WITH THIS BREAKING EVERYTHING!!!

    private float range = 10f;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        pulseScript = GetComponent<BootPulse>();
        playerStats = GetComponent<PlayerVariables>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!playerStats.grounded) //if not grounded, draw a line to the next collider
        {
            pulseDirection = pulseScript.pulseDirection;
            RaycastHit2D hit = Physics2D.Raycast(pulseScript.pulseSpawnLocation, pulseDirection, range);  //cant do "out" with Physics2D
            if (Physics2D.Raycast(pulseScript.pulseSpawnLocation, pulseDirection, range))
            {
                lr.enabled = true;
                //Debug.DrawRay(pulseScript.pulseSpawnLocation, pulseDirection);
                lr.SetPosition(0, pulseScript.pulseSpawnLocation);
                lr.SetPosition(1, hit.point);
            }
            else
            {
                lr.enabled = false;
            }

        }

    }

}
