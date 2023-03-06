using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    //upgrades?
    public int weaponLevel =0;
    private SpriteRenderer spriteRenderer;

   //shoot
    private Animator anim;
    private float cooldown = 0.9f;
    private float lastSwing = 0;
    public Arrow arrow;
    public bool reverse = false;

    public AudioClip clip;

    private void Start()
    {
        spriteRenderer =GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        if ((Input.GetKeyDown(KeyCode.Mouse0))&& Time.time - lastSwing > cooldown){
            lastSwing = Time.time;
            Shoot();
        }
    }

    private void Shoot(){
        anim.SetTrigger("Shoot");
        AudioSource.PlayClipAtPoint(clip, transform.position);
        Vector3 rota = transform.rotation.eulerAngles;
        rota.z=rota.z-90;
        if (reverse) rota.z +=180;
        Arrow projectile = Instantiate(arrow, transform.position, Quaternion.Euler(rota));
        Rigidbody2D prb = projectile.GetComponent<Rigidbody2D>();
        prb.AddRelativeForce(new Vector2(0,1000));
    }

}
