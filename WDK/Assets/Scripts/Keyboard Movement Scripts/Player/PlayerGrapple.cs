using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrapple : MonoBehaviour
{
    //RIGHT CLICK TO GRAPPLE

    private LineRenderer lr;
    private Vector2 grappleContact;
    public LayerMask whatIsGrappleable;
    public Transform grappleStart;
    public float maxGrappleDistance;

    private Vector2 grappleDirection, grappleStartVector;
    private SpringJoint2D springJoint;

    Vector3 mousePosWS;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        // springJoint = GetComponent<SpringJoint2D>();
        // springJoint.enabled = false;
    }


    void Update()
    {
        DrawGrapple();
        if (Input.GetMouseButtonDown(1)){
            StartGrapple();
        }
        else if(Input.GetMouseButtonUp(1)){
            StopGrapple();
        }
    }

    void StartGrapple(){
        Vector3 mousePos = Input.mousePosition;
        mousePosWS = Camera.main.ScreenToWorldPoint(mousePos);

        grappleDirection =  mousePosWS - grappleStart.position;
        grappleStartVector = grappleStart.position;

        RaycastHit2D hit = Physics2D.Raycast(grappleStartVector, grappleDirection, maxGrappleDistance);  //cant do "out" with Physics2D
        // Debug.DrawRay(grappleStartVector, grappleDirection, Color.green);
        if(Physics2D.Raycast(grappleStartVector, grappleDirection, maxGrappleDistance, whatIsGrappleable)){
          Debug.Log("Here");
          grappleContact = hit.point;
          springJoint = this.gameObject.AddComponent<SpringJoint2D>();
          springJoint.autoConfigureConnectedAnchor = false;
          springJoint.connectedAnchor = grappleContact;



          float distanceFromPoint = Vector2.Distance(grappleStartVector, grappleContact);

          springJoint.distance = distanceFromPoint * 0.8f;
          springJoint.dampingRatio = 1;
        }

    }

    void DrawGrapple(){
      lr.SetPosition(0, grappleStart.position);
      lr.SetPosition(1, grappleContact);
    }


    void StopGrapple(){

    }
}
