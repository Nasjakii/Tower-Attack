
using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    public static BuyManager instance;


    public void Start()
    {
        
    }


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuyManager in scene");
            return;
        }
        instance = this;
    }

    public GameObject troop;
    private TroopBlueprint troop_to_buy;

    public bool CanPlace { get { return troop_to_buy != null; } }

    public void PlaceTroopOn(ShipTile shipTile)
    {

        if (PlayerStats.Money < troop_to_buy.cost)
        {
            Debug.Log("Not enough money to buy that, cost: " + troop_to_buy.cost + " your Money: " + PlayerStats.Money);
            return;
        }
        PlayerStats.Money -= troop_to_buy.cost;

        int beacon_num = shipTile.beaconNumber;
        GameObject beacon = GetBeacon(beacon_num);

        if (beacon == null) return; //no connected beacon found


        SpawnTroop inst = new SpawnTroop();
        inst.troopPrefab = troop_to_buy.prefab;
        inst.count = 5;
        inst.time_between_spawns = 0.5f;
        inst.time_after_spawn = 2;
        inst.spawn_index = shipTile.tileIndex;
        beacon.GetComponent<Beacon>().addTroop(inst);

        GameObject troop = (GameObject)Instantiate(troop_to_buy.prefab, shipTile.GetPlacePosition(), inst.troopPrefab.transform.rotation);
        troop.GetComponent<AIController>().idle = true;
        shipTile.troop = troop;

    }

    public void DeleteTroopOn(ShipTile shipTile)
    {
        Destroy(shipTile.troop);
        shipTile.troop = null;
        //delete from beacon list
    }

    public void SelectTroopToBuy(TroopBlueprint troop)
    {
        troop_to_buy = troop;
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
