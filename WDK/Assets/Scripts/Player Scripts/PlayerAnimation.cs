using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;

    public float speed;
    public bool isJumping;
    public bool isGrounded;

    void Start()
    {
        speed = 0;
        isJumping = false;
        isGrounded = false;
    }

    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(speed));
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isGrounded", isGrounded);
    }
}
