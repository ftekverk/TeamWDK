using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    Rigidbody2D rb2D;
    public PlayerJump jumpscript;
    public float rotateSpeed = 500f;


    Quaternion upright;
    Vector3 rotateMove;

    public bool keyboardInputUsed = true;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        upright = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

      
      if(jumpscript.grounded){
        transform.rotation = upright;
      }
      else //if in the air
      {
            rb2D.freezeRotation = false;
            if (keyboardInputUsed) {
                if (Input.GetButton("Rotate Right")){  //e or right
                     transform.Rotate(new Vector3( 0f, 0f, -1f) , rotateSpeed * Time.deltaTime, Space.Self);
                }
                else if(Input.GetButton("Rotate Left")){  //q or left
                     transform.Rotate(new Vector3( 0f, 0f, -1f) , -rotateSpeed * Time.deltaTime, Space.Self);
                }
            }
            else if (!keyboardInputUsed)
            {

            }
      }

    }


}
