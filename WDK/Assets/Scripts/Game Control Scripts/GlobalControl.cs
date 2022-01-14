using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{

    //hp
    //xp
    //currency

    public bool playerinvincibleJumpUnlocked = false;
    public float playerHealth = 3f;
    public int totalJumps = 2; 

    public static GlobalControl Instance;
    void Awake()
    {
        if(Instance == null){
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance != this){
            Destroy(gameObject);
        }
    }
}
