using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject Spaceship;
    
    public void startShip()
    {

        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject spawner in spawners)
        {
            Vector3 spawnPos = new Vector3(0,0,-200);
            GameObject ship = Instantiate(Spaceship, spawner.transform.position + spawnPos, Quaternion.identity);
            ship.GetComponent<SpaceShip>().setFlying(true);
            ship.GetComponent<SpaceShip>().destination = spawner.transform;
        }
    }
}
