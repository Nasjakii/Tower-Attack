using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    private GameObject destination;
    private NavMeshAgent agent;
    private Animator animator;

    public bool idle = false;

    void Start()
    {
        if (!idle)
        {
            GameObject bones = transform.GetChild(0).gameObject;
            animator = bones.GetComponent<Animator>();
            animator.SetBool("Idle", false);

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
