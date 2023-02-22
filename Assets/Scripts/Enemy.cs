using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class Enemy : Combatant
{

    public bool canMove = true;
    public Transform target;

    public float speed = 400f; // Default to 2
    public float nextWayPointDistance = 100f; // Default to 1

    Path path; // The path we are following
    int currentWayPoint = 0;
    bool reachedEnd = false;

    Seeker seeker;
    Rigidbody2D rb;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        // Find the components
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 1f);
    }

    void UpdatePath()
    {
        if (canMove && seeker.IsDone())
            seeker.StartPath(rb.position, target.position, onPathComplete);
    }
    void onPathComplete(Path p) 
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0; // start on beginning of our path
        }
    }
    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        // Check that we have a path
        if (path == null)
            return;
        
        if(currentWayPoint >= path.vectorPath.Count)
        {
            reachedEnd = true;
            return;
        }
        else 
        {
            reachedEnd = false;
        }

        // Get the direction to move towards
        Vector2 direction = ((Vector2) path.vectorPath[currentWayPoint] - rb.position).normalized; // Makes sure its one with normalized
        // move towards the current direction
        Vector2 force = direction * speed * Time.fixedDeltaTime;

        
        rb.AddForce(force);
        // Distance to next waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        //Push if hit
       /* Vector2 nuSpeed = Vector2.zero;
        nuSpeed.x += pushDirection.x;
        nuSpeed.y+= pushDirection.y;
        rb.velocity=nuSpeed;
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);*/


        if (distance < nextWayPointDistance) // reached current waypoint
        {
            currentWayPoint++;
        }
    }

    protected override void RecieveDamage(Damage dmg){
        base.RecieveDamage(dmg);
        rb.AddForce(pushDirection);

    }


        protected override void Death()
    {
        Destroy(gameObject);
    }

}
