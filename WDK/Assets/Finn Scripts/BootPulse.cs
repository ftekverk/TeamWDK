using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootPulse : MonoBehaviour
{
    public GameObject bootPulsePrefab;
    public PlayerJump jumpscript;
    public Transform feet;
    public float pulseSpeed = 10f;
    private bool doubleJumpCalled;
//    private bool firstPulse;//keeps track that we only spawn one pulse

    private Vector2 pulseDirection;
    private Vector2 pulseSpawnOffset;
    private Vector2 feet2Dposition;
    //private Vector2 pulseDirection;
    private GameObject pulse;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //doubleJumpCalled = jumpscript.doubleJumpCalled;
        if(jumpscript.doubleJumpCalled && !jumpscript.grounded){
          pulseDirection = feet.position - transform.position;
          feet2Dposition = new Vector2(feet.position.x, feet.position.y);
          pulseSpawnOffset = feet2Dposition + 0.5f * pulseDirection;

          pulse = Instantiate(bootPulsePrefab, pulseSpawnOffset, transform.rotation);
          pulse.GetComponent<Rigidbody2D>().velocity = pulseDirection * pulseSpeed;
        }


    }
}
