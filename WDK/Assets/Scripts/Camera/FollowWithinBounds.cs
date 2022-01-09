using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWithinBounds : MonoBehaviour
{
    // This script allows the camera to follow the player.
    // The camera won't move up with the player until their y value is = shiftValue.

    // If necessary this script could be expanded to have more sets of min/max values for different shift values.

    public Transform player;

    public Vector3 minValues1; // These values are the min and max positions for the camera before the player has reached the shiftValue.
    public Vector3 maxValues1;

    public Vector3 minValues2; // These values are the min and max positions for the camera after the player has reached the shiftValue.
    public Vector3 maxValues2;

    public Vector3 offset; // Camera offset from the player position before shiftValue.
    public Vector3 offset2; // Camera offset from the player position after shiftValue.

    private Vector3 cameraBounds; // Holds the values for the camera position after they are clamped.

    public float shiftValue; // The y value the player's position has to reach for the camera to shift.

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
    {  // This function recieves the target position for the camera, and makes sure it is within the min and max allowed values
       // It then returns the clamped values for the camera to move to
        Vector3 cameraBoundsF;

        cameraBoundsF = new Vector3(
            Mathf.Clamp(targetPositionF.x, minValuesF.x, maxValuesF.x),
            Mathf.Clamp(targetPositionF.y, minValuesF.y, maxValuesF.y),
            Mathf.Clamp(targetPositionF.z, minValuesF.z, maxValuesF.z));

        return cameraBoundsF;
    }
}

