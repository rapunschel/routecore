using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player: Combatant
{
    [SerializeField]
    private float speed =10;
    private Vector2 currSpeed;
    private Rigidbody2D rb;
    public Tracker weaponTracker;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis ("Horizontal"); 
        float verticalInput = Input.GetAxis ("Vertical");
        Vector2 nuSpeed = new Vector2 (0,0);
        nuSpeed.x=(horizontalInput*speed);
        nuSpeed.y=(verticalInput*speed);
        
        //don't increase total max speed if moving diagonally
        if (nuSpeed.magnitude > speed) nuSpeed = nuSpeed.normalized*speed;
        
        nuSpeed.x += pushDirection.x;
        nuSpeed.y+= pushDirection.y;

        rb.velocity=nuSpeed;
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);


        if (horizontalInput>0){
            transform.localScale = Vector3.one; 
            weaponTracker.reverse=false;   
        }
        else if (horizontalInput<0){
             transform.localScale = new Vector3 (-1,1,1); 
             weaponTracker.reverse=true;
        }
       

    }

    protected override void Death(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




}
