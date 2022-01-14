using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public bool playerinvincibleJumpUnlocked = false;
    public float playerHealth = 3f;
    public bool playerAlive;

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
