using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    public int hitpoints = 10;
    public int maxHitpoints =10;
    public float pushRecoverySpeed = 0.1f;

    //iframes
    protected float immuneTime = 0.4f;
    protected float lastImmune;

    //push
    protected Vector2 pushDirection;

    protected virtual void RecieveDamage(Damage dmg){
        if (Time.time - lastImmune > immuneTime){
            lastImmune = Time.time;
            hitpoints -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            Debug.Log(this.name +" took "+ dmg.damageAmount +" damage and has " + hitpoints + " health left");

            if (hitpoints <= 0){
                hitpoints =0;
                Death();
            }
        }
    }
    protected virtual void Death(){
        Debug.Log(this.name + " has died");
    }

}
