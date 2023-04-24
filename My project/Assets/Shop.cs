
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuyManager buyManager;


    private void Start()
    {
        buyManager = BuyManager.instance;
    }

    public void PurchaseTroop(GameObject troop)
    {
        Debug.Log("Buy");
        buyManager.SetTroopSelected(troop);
    }



}
