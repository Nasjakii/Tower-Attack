
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    public static BuyManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuyManager in scene");
            return;
        }
        instance = this;
    }


    public Spawner spawner;

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

        SpawnTroop inst = new SpawnTroop();
        inst.troopPrefab = troop_to_buy.prefab;
        inst.count = 1;
        inst.time_between_spawns = 0;
        inst.time_after_spawn = 10;
        spawner.addTroop(inst);

        GameObject troop = (GameObject) Instantiate(troop_to_buy.prefab, shipTile.GetPlacePosition(), Quaternion.identity);
        troop.GetComponent<Troop>().speed = 0f;
        shipTile.troop = troop;

        Debug.Log("Troop bought! Money Left: " + PlayerStats.Money);
    }
    public void SelectTroopToBuy(TroopBlueprint troop)
    {
        troop_to_buy = troop;
    }



    
}
