
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TroopBlueprint troop;
    public TroopBlueprint troopSpecial;
    public TroopBlueprint rocketGuy;

    BuyManager buyManager;


    private void Start()
    {
        buyManager = BuyManager.instance;
    }

    public void SelectStandardTroop()
    {
        Debug.Log("Standard troop");
        buyManager.SelectTroopToBuy(troop);
    }

    public void SelectSpecialTroop()
    {
        Debug.Log("Special troop");
        buyManager.SelectTroopToBuy(troopSpecial);
    }

    public void SelectRocketGuyTroop()
    {
        Debug.Log("Rocket Guy");
        buyManager.SelectTroopToBuy(rocketGuy);
    }




}
