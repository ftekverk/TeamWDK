using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public PlayerJump jumpscript;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      if (!jumpscript.grounded && jumpscript.isAlive )
      {
        if ((Input.GetButtonDown("x")))
        {
            
            // animator.SetTrigger("Jump");
            // JumpSFX.Play();
        }
      }

    }


}
