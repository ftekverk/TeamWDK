using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootPulse : MonoBehaviour
{
    //spawning our pulse
    public GameObject bootPulsePrefab;
    private GameObject pulse;

    public PlayerJump jumpscript;
    private bool doubleJumpCalled;
    public float pulseSpeed = 10f;

    //variables to set location of boot spawn
    public Transform feet;
    private Vector2 pulseDirection;
    private Vector2 pulseSpawnOffset;
    private Vector2 feet2Dposition;


    void Update()
    {
        //if we are doublejumping and not grounded
        if(jumpscript.doubleJumpCalled && !jumpscript.grounded){
          //Our vector is from our player to their feet
          pulseDirection = feet.position - transform.position;

          //store position of feet as a 2D vector
          feet2Dposition = new Vector2(feet.position.x, feet.position.y);

          //the spot to spawn our pulse is at our feet plus a fraction of our direction vector
          pulseSpawnOffset = feet2Dposition + (0.5f * pulseDirection);


          pulse = Instantiate(bootPulsePrefab, pulseSpawnOffset, transform.rotation);
          pulse.GetComponent<Rigidbody2D>().velocity = pulseDirection * pulseSpeed;
        }


    }
}
