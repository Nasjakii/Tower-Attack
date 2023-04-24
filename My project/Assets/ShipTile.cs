
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShipTile : MonoBehaviour
{
    private GameObject turret;
    public GameObject turret_to_build;

    public Vector3 positionOffset;

    BuyManager buyManager;
    private void Start()
    {
        buyManager = BuyManager.instance;
    }

    private void OnMouseDown()
    {
        turret_to_build = buyManager.GetTroopSelected();

        if (turret != null)
        {
            Debug.Log("Cant build here! - Todo Display on screen");
            return;
        }


        //build Turret
        turret = (GameObject)Instantiate(turret_to_build, transform.position + positionOffset, transform.rotation);
    }
}
