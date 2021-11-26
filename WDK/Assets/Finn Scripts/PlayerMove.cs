using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float runSpeed = 10f;
    private Vector3 hMove;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position += hMove * runSpeed * Time.deltaTime;
    }
}
