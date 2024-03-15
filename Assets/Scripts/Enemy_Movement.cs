using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Animations : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    [SerializeField] private float speed = 2f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetBool("running", true);
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {   
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
         
            }
            FlipEnemy();
        }

        
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
    private void FlipEnemy()
    {
        if (transform.position.x < waypoints[currentWaypointIndex].transform.position.x)
        {
            // Enemy is to the left of the waypoint, flipX should be false
            spriteRenderer.flipX = false;
        }
        else
        {
            // Enemy is to the right of the waypoint, flipX should be true
            spriteRenderer.flipX = true;
        }
    }
}
