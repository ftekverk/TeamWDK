using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    private PlayerStates pStates;
    private DetectInput input;

    [SerializeField] float rotateSpeed;
    float angle;
    float startRotationOffset = 270;

    void Start()
    {
        pStates = GetComponent<PlayerStates>();
        input = GetComponent<DetectInput>();
    }

    void Update()
    {
        angle = (Mathf.Atan2(input.mousePosWS.y - transform.position.y, input.mousePosWS.x - transform.position.x) * Mathf.Rad2Deg);

        if (!pStates.grounded && !pStates.recoiling)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, startRotationOffset + angle), rotateSpeed * Time.deltaTime);
        }
    }
}
