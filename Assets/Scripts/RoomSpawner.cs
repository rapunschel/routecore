using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public Sprite closedDoorSprite;
    public SpriteRenderer exitDoor;
    public Enemy enemy; 

    // Used to spawn the monsters at different places based on where the player enters
    Vector2[] enemyPos = { new Vector2(-2, 3)
                         //, new Vector2(-4,9)
                         //, new Vector2(1, 6)
                         //, new Vector2(4, 9)
                         //, new Vector2(4, 16)
                         };

    Enemy[] enemies;

    // ugly temporary fix
    public Enemy monster1;
    public Enemy monster2;
    public Enemy monster3;
    public Enemy monster4;
    public Enemy monster5;


    // Start is called before the first frame update
    void Start()
    {
        Enemy[] enemies = {monster1, monster2, monster3, monster4, monster5};
        this.enemies = enemies;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if all the monsters are dead
        //Debug.Log("FRAME");
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        // Get player vector
       // Vector3 playerPos = other.transform.position;
        // Spawn the monsters
        /*
        for (int i = 0; i < enemyPos.Length; i++)
        {
            Enemy newEnemy = Instantiate(enemy
                                    , new Vector3(other.transform.position.x + enemyPos[i].x, other.transform.position.y + enemyPos[i].y, 0)
                                    , other.transform.rotation);
            newEnemy.target = other.transform;
            enemies[i] = newEnemy;
            Debug.Log("SPAWNED MONSTERS: " + i);

        }
        */

        for (int j = 0; j < enemies.Length; j++)
        {
            enemies[j].target = other.transform;
        }
        exitDoor.GetComponent<Collider2D>().isTrigger = false;
        exitDoor.sprite = closedDoorSprite;
    }

    void OnTriggerStay2D(Collider2D other) 
    {
 
    }
}
