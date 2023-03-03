using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Enemy
{
    
    //Cooldown tracking
    float lastFired=0;
    float cooldownmin=5;
    float cooldownmax=7;
    float currentcooldown;
    private Animator anim;
    public bool charging = false;

    //projectile




    protected override void Start()
    {
        base.Start();
        currentcooldown = Random.Range(cooldownmin, cooldownmax);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();


    }
    protected override void  FixedUpdate() {
        base.FixedUpdate();
        if ((canMove)&& Time.time-lastFired>currentcooldown){
            CanCharge();
        }
        if (charging && canMove) Charge();
    }
    //triggers shooting animation and sets cooldown logic
    //spawns projectile
    private void CanCharge(){
        anim.SetTrigger("Charge");
        rb.velocity=Vector2.zero;
        lastFired = Time.time;
        currentcooldown = Random.Range(cooldownmin, cooldownmax);
    }

    private void Charge(){
    var dif = target.transform.position - rb.transform.position;
    rb.velocity= dif.normalized*8;
    }


}
