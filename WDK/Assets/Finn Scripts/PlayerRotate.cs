using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    Rigidbody2D rb2D;
    public PlayerJump jumpscript;
    public float rotateSpeed = 500f;
    KeyCode rightRotate = KeyCode.E;
    KeyCode leftRotate = KeyCode.Q;

    Quaternion upright;

    Vector3 rotateMove;

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
        //rb2D.freezeRotation = true;
      }
      else //if in the air
      {
          rb2D.freezeRotation = false;
          if (Input.GetKey(rightRotate)){
              transform.Rotate(new Vector3( 0f, 0f, -1f) , rotateSpeed * Time.deltaTime, Space.Self);
          }
          else if(Input.GetKey(leftRotate)){
              transform.Rotate(new Vector3( 0f, 0f, -1f) , -rotateSpeed * Time.deltaTime, Space.Self);
          }
      }

    }


}
