using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsLineCast : MonoBehaviour
{
    public BootPulse pulseScript;
    public PlayerJump jumpScript;

    private Vector2 pulseDirection;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        // pulseDirection = pulseScript.pulseDirection;

        if (!jumpScript.grounded) //if not grounded, draw a line to the next collider
        {
            Debug.Log(pulseScript.pulseSpawnLocation);
           Debug.DrawRay(pulseScript.pulseSpawnLocation, pulseScript.pulseDirection * 10, Color.yellow);
            if (Physics.Raycast(pulseScript.pulseSpawnLocation, pulseDirection))
            {
                Debug.Log("yay");
            }
        }

    }




}
