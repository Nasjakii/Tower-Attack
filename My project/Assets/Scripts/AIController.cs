using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    private GameObject destination;
    private NavMeshAgent agent;

    public bool idle = false;

    void Start()
    {
        if (!idle)
        {
            destination = GameObject.FindGameObjectWithTag("Destination");
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(destination.transform.position);

            if (Vector3.Distance(transform.position, destination.transform.position) <= 0.2f)
            {
                Destroy(gameObject);
            }
        }
        
    }

}
