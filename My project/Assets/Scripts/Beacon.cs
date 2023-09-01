
using UnityEngine;
using UnityEngine.EventSystems;

public class Beacon : MonoBehaviour, IPointerDownHandler
{
    public Spawner connectedSpawner;
    public int connectionNumber = 0;
    public int beaconNumber;

    private Renderer rend;


    private int spawnerCount;

    void Start()
    {
        GameObject[] instances = GameObject.FindGameObjectsWithTag("Spawner");
        spawnerCount = instances.Length;

        GameObject glow = transform.GetChild(0).gameObject;
        rend = glow.GetComponent<Renderer>();

        switchColor(connectionNumber, rend);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("click");

        connectionNumber++;
        connectionNumber = connectionNumber % spawnerCount;

        


        switchColor(connectionNumber, rend);

        GameObject[] shipTiles = GameObject.FindGameObjectsWithTag("ShipTile");
        foreach (GameObject shipTile in shipTiles) { shipTile.GetComponent<ShipTile>().UpdateConnection(); }
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
}
