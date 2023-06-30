
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

        GameObject troop = (GameObject) Instantiate(troop_to_buy.prefab, shipTile.GetPlacePosition(), Quaternion.identity);
        shipTile.troop = troop;

        Debug.Log("Troop bought! Money Left: " + PlayerStats.Money);
    }
    public void SelectTroopToBuy(TroopBlueprint troop)
    {
        troop_to_buy = troop;
    }

}
