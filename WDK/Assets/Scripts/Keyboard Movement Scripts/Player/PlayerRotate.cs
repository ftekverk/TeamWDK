using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    Rigidbody2D rb2D;
    private PlayerJump jumpscript;
    public float rotateSpeed = 500f;
    public float rotateSpeedMouse;
    float angle;
    float startRotationOffset = 90;

    Quaternion upright;
    Vector3 rotateMove;
    Vector3 mousePos;
    Vector3 mousePosWS;

    public bool mouseForRotation = false;

    private Vector2 verticalVector;
    private Transform head;
    private Transform feet;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        upright = transform.rotation;
        jumpscript = GetComponent<PlayerJump>();
        feet = this.gameObject.transform.GetChild(0).transform;
        head = this.gameObject.transform.GetChild(1).transform;

        verticalVector = head.position - feet.position;
        verticalVector.Normalize();

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePosWS = Camera.main.ScreenToWorldPoint(mousePos);
        angle = (Mathf.Atan2(mousePosWS.y - transform.position.y, mousePosWS.x - transform.position.x) * Mathf.Rad2Deg);

        if (jumpscript.grounded){
        transform.rotation = upright;
        rb2D.freezeRotation = true;
      }
      else //if in the air
      {
            //rb2D.freezeRotation = false;
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
                if (Input.GetMouseButton(0) && jumpscript.additionalJump)
                {
                    rb2D.freezeRotation = false;
                     transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, startRotationOffset + angle), rotateSpeedMouse * Time.deltaTime);
                }
                else if (Input.GetMouseButtonUp(0) || !Input.GetMouseButton(0) || !jumpscript.additionalJump)
                {
                   //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0 , 0), rotateSpeedMouse * Time.deltaTime);
                   //transform.rotation = Quaternion.FromToRotation(jumpscript.jumpDirection, verticalVector);
                   transform.rotation = Quaternion.RotateTowards(transform.rotation, upright, 0.1f);
                }
            }
      }

    }


}
