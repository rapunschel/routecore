using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : Enemy
{
    
    //Cooldown tracking
    float lastFired=0;
    float cooldownmin=3;
    float cooldownmax=5;
    float currentcooldown;
    private Animator anim;
    public bool shooting = false;

    //projectile
    public GameObject fireball;

    public AudioClip attackClip;



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
            CanShoot();
        }
        if (shooting) Shoot();
    }
    //triggers shooting animation and sets cooldown logic
    private void CanShoot(){
        AudioSource.PlayClipAtPoint(attackClip, transform.position);
        rb.velocity = Vector2.zero;
        anim.SetTrigger("Shooting");
        lastFired = Time.time;
        currentcooldown= Random.Range(cooldownmin, cooldownmax);
    }
    //spawns projectile
    private void Shoot(){
        GameObject projectile = Instantiate(fireball, transform.position, transform.rotation);
        Rigidbody2D prb = projectile.GetComponent<Rigidbody2D>();
        projectile.transform.LookAt(target, Vector3.forward);
        prb.AddRelativeForce(projectile.transform.forward*5,ForceMode2D.Impulse);
        shooting = false;
    }
}
