using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTest : MonoBehaviour
{

    public PlayerVariables playerStats;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(){
        playerStats.SavePlayer();
        SceneManager.LoadScene("Level Design 1");
    }


}
