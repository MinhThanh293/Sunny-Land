using UnityEngine;
using Pathfinding;
using System.IO;

public class EnemyAI : EnemyControllerScript
{

    public Transform target;
    public Transform enemyGFX; 

    //public float speed = 200f;
    public float nexWayPointDistance = 3f;

	Pathfinding.Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    //Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
			seeker.StartPath(rb.position, target.position, OnPathComplete);
		}
    }

    void OnPathComplete(Pathfinding.Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
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
        Vector2 force = direction * Time.deltaTime;

        if (!destroyed)
        {
            if (!stop)
            {
				rb.AddForce(force);
			} 
            else
            {
				StopTime();
			}
        }

        

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nexWayPointDistance)
        {
            currentWaypoint++;
		}

		if (rb.linearVelocity.x >= 0.01f)
		{
			enemyGFX.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		else if (rb.linearVelocity.x < 0.01f)
		{
			enemyGFX.transform.localScale = new Vector3(1f, 1f, 1f);
		}
	}
}
