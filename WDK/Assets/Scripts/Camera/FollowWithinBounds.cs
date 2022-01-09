using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWithinBounds : MonoBehaviour
{
    //This script allows the camera to follow the player.
    //The camera won't move up with the player until their y value is = shiftValue.


    public Transform player;

    public Vector3 minValues1;
    public Vector3 maxValues1;

    public Vector3 minValues2;
    public Vector3 maxValues2;

    public Vector3 offset;
    public Vector3 offset2;

    private Vector3 cameraBounds;

    public float shiftValue;

    void Update()
    {
        Vector3 targetPosition = player.position + offset;
        Vector3 targetPosition2 = player.position + offset2;

        if (player.position.y > shiftValue)
        {
            cameraBounds = getCameraBounds(targetPosition2, minValues2, maxValues2);
        }
        else
        {
            cameraBounds = getCameraBounds(targetPosition, minValues1, maxValues1);
        }


        transform.position = cameraBounds;
    }

    Vector3 getCameraBounds(Vector3 targetPositionF, Vector3 minValuesF, Vector3 maxValuesF)
    {  //Function that recieves a targetposition and values for the bounds, then returns the clamped bounds
        Vector3 cameraBoundsF;

        cameraBoundsF = new Vector3(
            Mathf.Clamp(targetPositionF.x, minValuesF.x, maxValuesF.x),
            Mathf.Clamp(targetPositionF.y, minValuesF.y, maxValuesF.y),
            Mathf.Clamp(targetPositionF.z, minValuesF.z, maxValuesF.z));

        return cameraBoundsF;
    }
}

