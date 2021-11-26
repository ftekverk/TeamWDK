using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsCursor : MonoBehaviour
{
    Rigidbody2D bulletRb;
    Vector3 mousePos;
    Vector3 mousePosWS;
    Vector3 bulletPos;
    Vector3 targetPos;

    float yChange;
    float xChange;

    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        bulletPos = transform.position;
        mousePos = Input.mousePosition;
        mousePosWS = Camera.main.ScreenToWorldPoint(mousePos);
        targetPos = new Vector3(mousePosWS.x, mousePosWS.y, 0);

        yChange = mousePosWS.y - bulletPos.y;
        xChange = mousePosWS.x - bulletPos.x;

        bulletRb.velocity = new Vector2(xChange, yChange);
    }

    void Update()
    {
        
    }
}