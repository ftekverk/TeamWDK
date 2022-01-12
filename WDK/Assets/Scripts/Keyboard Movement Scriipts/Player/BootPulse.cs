using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootPulse : MonoBehaviour
{
    //spawning our pulse
    public GameObject bootPulsePrefab;
    private GameObject pulse;

    private PlayerJump jumpscript;
    private bool additionalJumpCalled;
    private float pulseSpeed = 10f;

    //variables to set location of boot spawn
    private Transform feet;
    public Vector2 pulseDirection;
    public Vector2 pulseSpawnLocation;
    private Vector2 feet2Dposition;


    void Start(){
      jumpscript =  GetComponent<PlayerJump>();
      feet = this.gameObject.transform.GetChild(0).transform;
    }

    void Update()
    {
        //Our vector is from our player to their feet
        pulseDirection = feet.position - transform.position;

        //store position of feet as a 2D vector
        feet2Dposition = new Vector2(feet.position.x, feet.position.y);

        //the spot to spawn our pulse is at our feet plus a fraction of our direction vector
        pulseSpawnLocation = feet2Dposition + (0.5f * pulseDirection);
        //if we are doublejumping and not grounded
        if (jumpscript.additionalJumpCalled && !jumpscript.grounded){
          pulse = Instantiate(bootPulsePrefab, pulseSpawnLocation, transform.rotation);
          pulse.GetComponent<Rigidbody2D>().velocity = pulseDirection * pulseSpeed;
        }


    }
}
