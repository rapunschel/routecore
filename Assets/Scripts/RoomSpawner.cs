using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public Sprite openDoorSprite;
    public Sprite closedDoorSprite;
    public SpriteRenderer exitDoor;
  //  public Transform player; 
    private bool fightOver = false;
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

        for (int i = 0; i < 5; i++)
        {   
            if (enemies[i] != null)
                enemies[i].target = enemies[i].transform; // Set itself as
        }
        this.enemies = enemies;
        
    }
        bool isAllDead = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if all the monsters are dead
        if (!fightOver)
        {
            // Check if all monsters hp is 0
            for (int i = 0; i < 5; i++)
            {

                if (enemies[i]==null) // Check if it's null as we delete the gameobject
                {
                    isAllDead = true; // Set to true
                    continue;
                }
                else 
                {
                    isAllDead = false; // If its not null, still alive
                    return;
                }
                
            }
            if (isAllDead)
                {
                    // Open the door to let the player out
                    exitDoor.GetComponent<Collider2D>().isTrigger = true; // allow letting through
                    exitDoor.sprite = openDoorSprite;
                    // Set sentinel value to true
                    fightOver = true;
                }
        }
    }

    int counter = 0;
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
        Debug.Log(counter);
        for (int j = 0; j < enemies.Length; j++)
        {
            enemies[j].target = other.transform;
            enemies[j].canMove=true;
        }
        exitDoor.GetComponent<Collider2D>().isTrigger = false;
        exitDoor.sprite = closedDoorSprite;
    }

    void OnTriggerExit2D(Collider2D other) 
    {

    }
}
