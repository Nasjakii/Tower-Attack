using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float speed = 30f;


    private bool start_flying = false;

    public Transform destination;
    //private bool unloading = false;

    void Update()
    {
        if(start_flying == true)
        {
            Vector3 dir = destination.position - transform.position; //moving to the next target
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, destination.position) <= 0.2f)
            {
                //unloading = true;

                GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
                foreach (GameObject spawner in spawners)
                {
                    spawner.GetComponent<Spawner>().spawn = true;
                }

                Destroy(gameObject);
            }
        } 



    }

    public void setFlying(bool flying)
    {
        start_flying = flying;
    }
}
