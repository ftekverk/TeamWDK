using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseBehavior : MonoBehaviour
{
    public PlayerJump jumpscript;
    public float damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag != "Player")
        {
            Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.TakeDamage(damage);
            }
            Object.Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //print("STARTED");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
