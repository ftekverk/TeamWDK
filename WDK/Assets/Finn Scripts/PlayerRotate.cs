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
    KeyCode rightRotate2 = KeyCode.RightArrow;
    KeyCode leftRotate2 = KeyCode.LeftArrow;

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
      }
      else //if in the air
      {
          rb2D.freezeRotation = false;
          if (Input.GetKey(rightRotate) || Input.GetKey(rightRotate2)){
              transform.Rotate(new Vector3( 0f, 0f, -1f) , rotateSpeed * Time.deltaTime, Space.Self);
          }
          else if(Input.GetKey(leftRotate) || Input.GetKey(leftRotate2)){
              transform.Rotate(new Vector3( 0f, 0f, -1f) , -rotateSpeed * Time.deltaTime, Space.Self);
          }
      }

    }


}
