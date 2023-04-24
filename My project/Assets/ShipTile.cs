
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShipTile : MonoBehaviour
{
    private GameObject troop;
    public GameObject troop_to_build;

    public Vector3 positionOffset;

    BuyManager buyManager;
    private void Start()
    {
        buyManager = BuyManager.instance;
    }

    private void OnMouseDown()
    {
        troop_to_build = buyManager.GetTroopSelected();

        if (troop != null)
        {
            Debug.Log("Cant build here! - Todo Display on screen");
            return;
        }


        //build Troop

        
    }


    private void setTroop()
    {
        //check for money
        //check place
        //place troop at tile
        troop = (GameObject)Instantiate(troop_to_build, transform.position + positionOffset, transform.rotation);
        //add troop to array

    }
}
