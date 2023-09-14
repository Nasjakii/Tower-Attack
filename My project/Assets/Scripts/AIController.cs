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
    private GameObject healthbarCanvas;

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

            
        } else
        {
            healthbarCanvas = transform.GetChild(1).gameObject;
        }
        
    }

    private void Update()
    {
        if (!idle)
        {
            if (Vector3.Distance(transform.position, destination.transform.position) <= 2f)
            {
                destination.GetComponent<Basis>().curr_hp -= GetComponent<Troop>().damage;
                Destroy(gameObject);
            }
        } else
        {
            healthbarCanvas.SetActive(false);
        }
    }

}
