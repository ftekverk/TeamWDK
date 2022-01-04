using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArms : MonoBehaviour
{
    public GameObject rightArm;
    public GameObject leftArm;
    public Rigidbody2D rightArmRb;
    public Rigidbody2D leftArmRb;
    public Vector2 forceVector;

    public float horizontalArmMoveSpeed = 0.001f;
    public float verticalArmMoveSpeed = 0.001f;
    public float maxVerticalSpeed = 3f;
    public float maxHorizontalSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rightArmRb = rightArm.GetComponent<Rigidbody2D>();
        leftArmRb = leftArm.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveArmsDown();
    }

    public void moveArmsDown()
    {
        forceVector = new Vector2(0f, -verticalArmMoveSpeed);
        if(-rightArmRb.velocity.y < maxVerticalSpeed)
        {
            rightArmRb.velocity += forceVector;
            leftArmRb.velocity += forceVector;
        }
    }
}
