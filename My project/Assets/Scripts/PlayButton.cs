using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    
    
    public void startShip()
    {
        GameObject ship = GameObject.Find("SpaceShip");
        ship.GetComponent<SpaceShip>().setFlying(true);
    }
}
