using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpaceShip : MonoBehaviour
{
    public float speed = 30f;
    private float currSpeed;
    private bool start_flying = false;
    public Transform destination;

    public GameObject troopContainer;
    public bool dropTroops = false;

    private Vector3 hoverAbove = new Vector3(0f, 15f, 0f);

    private float fly_away_wait = 2f;
    private bool fly_away = false;
    private bool spawning = false;

    private void Start()
    {
        currSpeed = speed;
    }

    void Update()
    {
        if(start_flying == true && !fly_away)
        {


            Vector3 dir = destination.position + hoverAbove - troopContainer.transform.position; 
            transform.Translate(dir.normalized * currSpeed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, destination.position + hoverAbove) <= 2.2f) 
            {
                fly_away = true;

                dropTroops = true;
                
            }
        } 

        if (fly_away)
        {
            fly_away_wait -= Time.deltaTime;

            currSpeed = 0f;
            if (fly_away_wait <= 0f)
            {
                currSpeed = speed;
                Vector3 finishPos = destination.position + new Vector3(0f, 100f, 100f);

                Vector3 dir = finishPos - transform.position;
                transform.Translate(dir.normalized * currSpeed * Time.deltaTime, Space.World);

                if (spawning == false)
                {
                    spawning = true;
                    StartSpawn();
                }
                
            }
        }

        if (dropTroops)
        {
            dropTroops = false;
            DropTroops();
        }





    }

    public void setFlying(bool flying)
    {
        start_flying = flying;
    }

    public void DropTroops()
    {
        
        GameObject containerInst = Instantiate(troopContainer, transform.position, troopContainer.transform.rotation, transform);
        containerInst.transform.SetParent(null);
        Vector3 newPos = new Vector3(containerInst.transform.position.x,0f, containerInst.transform.position.z);
        StartCoroutine(0.7f.Tweeng((p) => containerInst.transform.position = p, containerInst.transform.position, newPos));
        troopContainer.SetActive(false);

    }

    public void StartSpawn()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject spawner in spawners)
        {
            spawner.GetComponent<Spawner>().spawn = true;
        }
    }

}
