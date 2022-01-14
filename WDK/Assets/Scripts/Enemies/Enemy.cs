using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //private bool isAlive = true;
    //private bool isInvincible = false;
    [SerializeField] float health;

    public virtual float GetDamage() => 1f;
    public string GetDamagingEffect() => null;

    public virtual void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            //isAlive = false;
            OnDie();
        }
    }

    public virtual void OnDie() {
        Object.Destroy(this.gameObject); // may break... what is this
    }

    public virtual void OnSpawn() {
        //print("Spawned");
    }

    void Start() {
        OnSpawn();
    }
}
