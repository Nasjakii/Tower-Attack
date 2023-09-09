using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

            
        }
        
    }

    private void Update()
    {
        if (!idle)
        {
            if (Vector3.Distance(transform.position, destination.transform.position) <= 2f)
            {
                destination.GetComponent<Basis>().hp -= GetComponent<Troop>().damage;
                Destroy(gameObject);
            }
        }
    }

}
