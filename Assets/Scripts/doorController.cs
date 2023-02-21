using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class doorController : MonoBehaviour
{

    public SpriteRenderer bottomDoor;
    public SpriteRenderer bottomRightDoor;
    public SpriteRenderer bottomLeftDoor;
    
    // Save the doors in an array so we can loop through them later
    public Sprite closedDoorSprite; // Used to close the doors after entering
    private Collider2D spriteCollider;
    private Collider2D doorControllerCollider;
    // Start is called before the first frame update
    
    void Start()
    {
        doorControllerCollider = this.GetComponent<Collider2D>();
        doorControllerCollider.isTrigger = true; // Set to true to allow moving through
    }

    // Update is called once per frame
    void Update()
    {
    }
 
    private void OnTriggerExit2D(Collider2D other) 
    {
        doorControllerCollider.isTrigger = false; // Make it not possible to go out of door
        SpriteRenderer[] doors = {bottomDoor, bottomRightDoor, bottomLeftDoor};
        closeBottomDoors(doors);
    }

    private void closeBottomDoors(SpriteRenderer[] doors) 
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].sprite = closedDoorSprite;
        }
    }

}

