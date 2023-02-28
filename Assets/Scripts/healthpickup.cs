using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpickup : Collidable
{
    // Start is called before the first frame update

    public int healing = 2;
    // Update is called once per frame

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name=="Player") {
            coll.SendMessage("Heal", healing);
            Destroy(gameObject);
        }
    }
}
