using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    //hp
    //xp
    //currency

    public bool playerinvincibleJumpUnlocked = false;
    public float playerHealth = 3f;
    public int totalJumps = 2; 

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
