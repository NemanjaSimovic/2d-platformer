using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Waypoints;

    private int CurrentWaypointIndex = 0;
    [SerializeField]
    private float Speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(Waypoints[CurrentWaypointIndex].transform.position, transform.position) < .1f)
        {
            CurrentWaypointIndex = CurrentWaypointIndex == Waypoints.Length - 1 ? 0 : CurrentWaypointIndex + 1;
        }
        transform.position = Vector2.MoveTowards(transform.position, Waypoints[CurrentWaypointIndex].transform.position, Time.deltaTime * Speed);
    }
}
