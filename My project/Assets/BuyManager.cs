
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

    private GameObject troop_selected;

    public GameObject GetTroopSelected()
    {
        return troop_selected;
    }
    public void SetTroopSelected(GameObject troop)
    {
        troop_selected = troop;
    }

}
