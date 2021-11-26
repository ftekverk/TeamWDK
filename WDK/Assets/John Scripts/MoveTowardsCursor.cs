using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsCursor : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 mousePosWS;
    Vector3 bulletPos;
    Vector3 targetPos;

    void Start()
    {
        bulletPos = transform.position;
        mousePos = Input.mousePosition;
        mousePosWS = Camera.main.ScreenToWorldPoint(mousePos);
        targetPos = new Vector3(mousePosWS.x, mousePosWS.y, 0);
    }

    void Update()
    {
        transform.position = targetPos;
    }
}