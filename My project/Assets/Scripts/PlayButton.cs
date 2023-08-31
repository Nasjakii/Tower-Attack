using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    
    
    public void startShip()
    {
        GameObject ship = GameObject.Find("SpaceShip");
        ship.GetComponent<SpaceShip>().setFlying(true);

        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject spawner in spawners)
        {
            spawner.GetComponent<Spawner>().spawn = true;
        }
        
    }
}
