using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public PlayerJump jumpscript;
    public float rotateSpeed = 20f;
    KeyCode rightRotate = KeyCode.X;
    KeyCode leftRotate = KeyCode.Z;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      if (!jumpscript.grounded && jumpscript.isAlive )
      {
          if (Input.GetKeyDown(rightRotate)) Debug.Log("Here2");
          else if(Input.GetKeyDown(leftRotate)) transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

//transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);

      }

    }


}
