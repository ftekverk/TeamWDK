using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    private PlayerStates pStates;
    private DetectInput input;

    void Start()
    {
        pStates = GetComponent<PlayerStates>();
        input = GetComponent<DetectInput>();
    }

    void Update()
    {
        if (!pStates.grounded && !pStates.recoiling)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(input.mousePosWS.y - transform.position.y, input.mousePosWS.x - transform.position.x) * Mathf.Rad2Deg - 90);
        }
    }
}
