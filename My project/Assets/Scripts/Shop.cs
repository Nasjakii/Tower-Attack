
using TMPro;
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

        TextMeshProUGUI text0 = transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI text1 = transform.GetChild(1).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI text2 = transform.GetChild(2).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        
        text0.SetText(text0.text + rocketGuy.cost);
        text1.SetText(text1.text + speedster.cost);
        text2.SetText(text2.text + tank.cost);
        
    }

    public void SelectRocketGuyTroop()
    {
        //Debug.Log("Rocket Guy");
        buyManager.SelectTroopToBuy(rocketGuy);
    }

    public void SelectSpeedsterTroop()
    {
        //Debug.Log("Speedster");
        buyManager.SelectTroopToBuy(speedster);
    }

    public void SelectTankTroop()
    {
        //Debug.Log("Tank");
        buyManager.SelectTroopToBuy(tank);
    }


    private void Update()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        text.SetText("Money: " + PlayerStats.Money.ToString());

    }


}
