
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class ShipTile : MonoBehaviour
{

    public Vector3 positionOffset;

    [Header("Optional Pre Building")]
    public GameObject troop;

    BuyManager buyManager;
    private void Start()
    {
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


}
