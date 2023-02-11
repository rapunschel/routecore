using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class demonAI : MonoBehaviour
{
    public Transform target;

    public float speed = 400f; // Default to 2
    public float nextWayPointDistance = 100f; // Default to 1

    Path path; // The path we are following
    int currentWayPoint = 0;
    bool reachedEnd = false;

    Seeker seeker;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        // Find the components
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        
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
    void FixedUpdate()
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
        Vector2 direction = ((Vector2) path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.fixedDeltaTime;

        rb.AddForce(force);
        // Distance to next waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);
        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
    }
}
