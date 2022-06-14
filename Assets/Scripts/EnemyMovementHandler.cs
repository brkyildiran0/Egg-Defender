using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementHandler : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    void Update()
    {
        PrintWaypointName();
    }

    void PrintWaypointName()
    {
        foreach (var waypoint in path)
        {
            print(waypoint.name);
        }
    }
}
