
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TroopBlueprint tank;
    public TroopBlueprint speedster;
    public TroopBlueprint rocketGuy;

    BuyManager buyManager;


    private void Start()
    {
        buyManager = BuyManager.instance;
    }

    public void SelectRocketGuyTroop()
    {
        Debug.Log("Rocket Guy");
        buyManager.SelectTroopToBuy(rocketGuy);
    }

    public void SelectSpeedsterTroop()
    {
        Debug.Log("Speedster");
        buyManager.SelectTroopToBuy(speedster);
    }

    public void SelectTankTroop()
    {
        Debug.Log("Tank");
        buyManager.SelectTroopToBuy(tank);
    }




}
