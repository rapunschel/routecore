using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoors : MonoBehaviour
{

    // Using three to close the doors of other rooms to avoid player to leave.
    public SpriteRenderer roomDoor1;
    public SpriteRenderer roomDoor2;
    public SpriteRenderer roomDoor3;
    
    // Save the doors in an array so we can loop through them later
    public Sprite closedDoorSprite; // The replacement sprite for the door
    
    void Start()
    {
        // Do nothing
    }

    // Update is called once per frame
    void Update()
    {
        // Do nothing
    }
 
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.name=="Player"){
            SpriteRenderer[] doors = {roomDoor1, roomDoor2, roomDoor3};
            closeBottomDoors(doors);
        }
    }

    private void closeBottomDoors(SpriteRenderer[] doors) 
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].sprite = closedDoorSprite; // Set the new sprite
            doors[i].GetComponent<Collider2D>().isTrigger = false; // Set trigger to false to stop player from going through
        }
    }
}
