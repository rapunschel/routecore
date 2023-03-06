using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Weapon
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void OnCollide(Collider2D coll)
    {
        base.OnCollide(coll);
        if (coll.tag=="Wall") Destroy(gameObject); 
    }
}
