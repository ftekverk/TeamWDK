using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    Rigidbody2D rb2D;
    public PlayerJump jumpscript;
    public float rotateSpeed = 500f;
    public float rotateSpeedMouse;
    float angle;
    float startRotationOffset = 90;



    Quaternion upright;
    Vector3 rotateMove;
    Vector3 mousePos;
    Vector3 mousePosWS;

    public bool mouseForRotation = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        upright = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePosWS = Camera.main.ScreenToWorldPoint(mousePos);
        angle = (Mathf.Atan2(mousePosWS.y - transform.position.y, mousePosWS.x - transform.position.x) * Mathf.Rad2Deg);

        if (jumpscript.grounded){
        transform.rotation = upright;
      }
      else //if in the air
      {
            rb2D.freezeRotation = false;
            if (!mouseForRotation) {
                if (Input.GetButton("Rotate Right")){  //e or right
                     transform.Rotate(new Vector3( 0f, 0f, -1f) , rotateSpeed * Time.deltaTime, Space.Self);
                }
                else if(Input.GetButton("Rotate Left")){  //q or left
                     transform.Rotate(new Vector3( 0f, 0f, -1f) , -rotateSpeed * Time.deltaTime, Space.Self);
                }
            }
            else if (mouseForRotation)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, startRotationOffset + angle), rotateSpeedMouse * Time.deltaTime);
            }
      }

    }


}
