using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToUpright : MonoBehaviour
{
    private PlayerStates pStates;

    Quaternion uprightRot = new Quaternion(0, 0, 1, 0);
    Quaternion target;

    float zAngle = 180;
    float smoothing = 5.0f;
    float uprightBound = .99999f;

    [SerializeField] float currentZRot;

    void Start()
    {
        pStates = GetComponent<PlayerStates>();

        target = Quaternion.Euler(0, 0, zAngle);
    }

    void Update()
    {
        currentZRot = transform.rotation.z;

        if (transform.rotation.z > uprightBound || transform.rotation.z < -uprightBound)
        {
            pStates.upright = true;
        }
        else
        {
            pStates.upright = false;
        }

        if (!pStates.upright)
        {
            if ( transform.rotation.z < uprightRot.z && pStates.grounded)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smoothing);
            }
        }
    }
}