using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    public int hitpoints = 10;
    public int maxHitpoints =10;
    public float pushRecoverySpeed = 0.1f;

    public bool canMove = true;



    //iframes

    [Tooltip("Material to switch to during iframes.")]
    [SerializeField] private Material flashMaterial;
    protected float immuneTime = 0.6f;
    protected float lastImmune;

    //push
    protected Vector2 pushDirection;

    // The SpriteRenderer that should flash.
    private SpriteRenderer spriteRenderer;
        
        // The material that was in use, when the script started.
    private Material originalMaterial;

        // The currently running coroutine.
    private Coroutine flashRoutine;

    protected virtual void Start(){
       // Get the SpriteRenderer to be used,
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the material that the SpriteRenderer uses, 
        // so we can switch back to it after the flash ended.
        originalMaterial = spriteRenderer.material; 
    }

    protected virtual void RecieveDamage(Damage dmg){
        if (Time.time - lastImmune > immuneTime){
            lastImmune = Time.time;
            hitpoints -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
            Flash();

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

    public void Flash()
        {
            // If the flashRoutine is not null, then it is currently running.
            if (flashRoutine != null)
            {
                // In this case, we should stop it first.
                // Multiple FlashRoutines the same time would cause bugs.
                StopCoroutine(flashRoutine);
            }

            // Start the Coroutine, and store the reference for it.
            flashRoutine = StartCoroutine(FlashRoutine());
        }

        private IEnumerator FlashRoutine()
        {
            //enemies can't move during hitstun
            canMove=false;
            // Swap to the flashMaterial.
            spriteRenderer.material = flashMaterial;

            // Pause the execution of this function for "duration" seconds.
            yield return new WaitForSeconds(immuneTime);

            //enemies can move again
            canMove=true;

            // After the pause, swap back to the original material.
            spriteRenderer.material = originalMaterial;

            // Set the routine to null, signaling that it's finished.
            flashRoutine = null;
        }

}
