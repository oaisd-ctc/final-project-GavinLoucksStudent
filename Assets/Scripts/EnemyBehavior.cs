using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public SpriteRenderer GFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;


    //DistanceCheck
    private float dis;
    public GameObject player;
    private float distanceBetween = 4.0f;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        GFX = GetComponent<SpriteRenderer>();

        InvokeRepeating("UpdatePath", 0f, .5f);

    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }

    }
    void FixedUpdate()
    {
        dis = Vector2.Distance(transform.position, player.transform.position);




        if (dis < distanceBetween)
        {

            if (path == null)
            {
                return;
            }
            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }

            if (force.x >= 0.01f)
            {
                GFX.transform.localScale = new Vector3(-1f, 1f, 1f);

            }
            else if (force.x <= -0.01f)
            {
                GFX.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }




    public void deathSpeed(GameObject objectToDestroy)
    {

        Destroy(objectToDestroy);
    }











}
