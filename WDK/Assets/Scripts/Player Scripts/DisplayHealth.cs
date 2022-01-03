using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHealth : MonoBehaviour
{


    private GameObject Health1;
    private GameObject Health2;
    private GameObject Health3;
    public PlayerVariables playerStatsScript;

    // Start is called before the first frame update
    void Start()
    {
        Health1 = this.transform.GetChild(0).gameObject;
        Health2 = this.transform.GetChild(1).gameObject;
        Health3 = this.transform.GetChild(2).gameObject;


    }

    // Update is called once per frame
    void Update()
    {
        if(playerStatsScript.playerHealth == 3f)
        {
            Health1.SetActive(true);
            Health2.SetActive(true);
            Health3.SetActive(true);
        }
        else if (playerStatsScript.playerHealth == 2f)
        {
            Health1.SetActive(true);
            Health2.SetActive(true);
            Health3.SetActive(false);
        }
        else if (playerStatsScript.playerHealth == 1f)
        {
            Health1.SetActive(true);
            Health2.SetActive(false);
            Health3.SetActive(false);
        }
        else if (playerStatsScript.playerHealth == 0f)
        {
            Health1.SetActive(false);
            Health2.SetActive(false);
            Health3.SetActive(false);
        }
    }
}
