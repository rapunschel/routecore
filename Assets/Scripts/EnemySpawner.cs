using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Enemy
{
    public float spawnCooldown = 5.0f;

    private float lastSpawn;

    public Enemy enemy;
    
    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        canMove=false;
    }   

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (Time.time - lastSpawn > spawnCooldown){
            lastSpawn = Time.time;
            Enemy newEnemy = Instantiate(enemy, this.transform.position, this.transform.rotation);
            newEnemy.target= target;
        }
        
       
    }
}
