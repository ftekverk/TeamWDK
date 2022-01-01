using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    private PlayerStates pStates;
    private DetectInput input;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject spawner;

    void Start()
    {
        pStates = GetComponent<PlayerStates>();
        input = GetComponent<DetectInput>();
    }


    void Update()
    {
        if (pStates.shooting)
        {
            Instantiate(bullet, spawner.transform.position, 
                        Quaternion.Euler(0, 0, Mathf.Atan2(input.mousePosWS.y - transform.position.y, input.mousePosWS.x - transform.position.x) * Mathf.Rad2Deg - 90));

            pStates.shooting = false;
        }
    }
}
