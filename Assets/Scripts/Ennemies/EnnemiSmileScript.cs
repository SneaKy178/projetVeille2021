using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiSmileScript : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private Transform[] waypoints;
    private Transform targetWaypoint;
    private int destinationPoint = 0;
    [SerializeField] private SpriteRenderer sprite;

    void Start()
    {
        targetWaypoint = waypoints[0];
    }
    
    void Update()
    {
        Vector3 direction = targetWaypoint.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.3f)
        {
            destinationPoint = (destinationPoint + 1) % waypoints.Length;
            targetWaypoint = waypoints[destinationPoint];
            sprite.flipX = !sprite.flipX;
        }
    }
}
