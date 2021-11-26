using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public PlayerJump jumpscript;
    //public float rotateSpeed = 5f; WHY THE FUCK CANT I PUT THAT IN ROTATE FUNC
    KeyCode rightRotate = KeyCode.X;
    KeyCode leftRotate = KeyCode.Z;
    // Start is called before the first frame update

    Vector3 rotateMove;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      if (!jumpscript.grounded)
      {
        //ask adam or john about why i cant put rotate speed in here
          if (Input.GetKey(rightRotate)){
              transform.Rotate(new Vector3( 0f, 0f, -1f) , 7f, Space.Self);
          }
          else if(Input.GetKey(leftRotate)){
              transform.Rotate(new Vector3( 0f, 0f, -1f) , -7f, Space.Self);
          }





          //transform.rotation = Quarternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);


      }

    }


}
