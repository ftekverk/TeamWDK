using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsLineCast : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;


    public BootPulse pulseScript;
    public PlayerJump jumpScript;
    public Vector2 pulseDirection;

    public LayerMask layersToIgnore;

    public float range = 100f;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!jumpScript.grounded) //if not grounded, draw a line to the next collider
        {
            pulseDirection = pulseScript.pulseDirection;
            
             //RaycastHit2D hit = Physics2D.Raycast(pulseScript.pulseSpawnLocation, pulseDirection * 10, range, layersToIgnore);
            if (Physics2D.Raycast(pulseScript.pulseSpawnLocation, pulseDirection, range, layersToIgnore))
            {
                Debug.DrawRay(pulseScript.pulseSpawnLocation, pulseDirection * 10);
                //this.transform.position = pulseScript.pulseSpawnLocation;
                Debug.Log("Here1");
              //  lr.SetPosition(1, pulseScript.pulseSpawnLocation);
               // lr.SetPosition(2, hit.point);
                Debug.Log("Here2");

            }
    
        }

    }

}
