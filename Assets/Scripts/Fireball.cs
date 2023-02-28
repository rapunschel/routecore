using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : EnemyHitbox
{

    protected override void OnCollide(Collider2D coll){
    if (coll.tag == "Combatant" &&  coll.name == "Player"){
        //create damage struct and send to player
        Damage dmg = new Damage {damageAmount = damage, origin=transform.position, pushForce=pushForce};
        coll.SendMessage("RecieveDamage", dmg);
        }
    //Destroy(gameObject);
    }
}
