
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class ShipTile : MonoBehaviour
{

    public Vector3 positionOffset;

    [Header("Optional Pre Building")]
    public GameObject troop;

    [Header("Connected Beacon")]
    public int beaconNumber = 0;


    private Renderer rend;

    BuyManager buyManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        UpdateConnection();
        
        buyManager = BuyManager.instance;
    }

    private void OnMouseDown()
    {
        if (!buyManager.CanPlace) return;

        if (troop != null)
        {
            Debug.Log("Cant place here! - Todo Display on screen");
            return;
        }

        buyManager.PlaceTroopOn(this);

    }

    public Vector3 GetPlacePosition()
    {
        return transform.position + positionOffset;
    }

    public void UpdateConnection()
    {
        GameObject beacon = GetBeacon(beaconNumber);
        switchColor(beacon.GetComponent<Beacon>().connectionNumber, rend);

    }

    private void switchColor(int number, Renderer _rend)
    {
        switch (number)
        {
            case 0:
                _rend.material.SetColor("_Color", Color.red);
                break;
            case 1:
                _rend.material.SetColor("_Color", Color.green);
                break;
            case 2:
                _rend.material.SetColor("_Color", Color.blue);
                break;

        }
    }

    private GameObject[] GetBeacons()
    {
        GameObject[] beacons = GameObject.FindGameObjectsWithTag("Beacon");
        return beacons;
    }

    private GameObject GetBeacon(int beacon_number)
    {
        GameObject[] beacons = GetBeacons();
        for (int i = 0; i < beacons.Length; i++)
        {
            if (beacons[i].GetComponent<Beacon>().beaconNumber == beacon_number)
            {
                return beacons[i];

            }
        }
        return null;
    }

}
