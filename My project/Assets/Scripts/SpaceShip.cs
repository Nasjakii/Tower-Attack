using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float speed = 30f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = FlyPoints.points[0];
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position; //moving to the next target
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= FlyPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = FlyPoints.points[wavepointIndex];
    }
}