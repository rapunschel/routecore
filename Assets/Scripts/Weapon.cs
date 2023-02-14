using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    //damage
    public int damageDealt =1;
    public float pushForce=2.0f;

    //upgrades
    public int weaponLevel =0;
    private SpriteRenderer spriteRenderer;

    //swing
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing = 0;
    protected override void Start()
    {
        base.Start();
        spriteRenderer =GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.Space)){
            lastSwing = Time.time;
            Swing();
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Combatant"){
            if (coll.name == "player_1")
                return;
            
            Damage dmg = new Damage {damageAmount = damageDealt, origin=transform.position, pushForce=pushForce};

            coll.SendMessage("RecieveDamage", dmg);
        }
    }

    private void Swing(){
        anim.SetTrigger("Swing");
    }
}
