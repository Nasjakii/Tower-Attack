
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Beacon : MonoBehaviour, IPointerDownHandler
{

    public int connectionNumber = 0;
    public int beaconNumber;

    [HideInInspector]
    public GameObject connectedSpawner;

    private Renderer rend;

    public GameObject[] spawners;
    private int spawnerCount;
    public GameObject[] shipTiles;
    private int shipTileCount;

    public List<SpawnTroop> spawnTroops = new List<SpawnTroop>(); //middle man to safe the troops
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        spawnerCount = spawners.Length;
        connectedSpawner = GetSpawner(connectionNumber, spawners);

        shipTiles = GameObject.FindGameObjectsWithTag("ShipTile");
        shipTileCount = shipTiles.Length;

        GameObject glow = transform.GetChild(0).gameObject;
        rend = glow.GetComponent<Renderer>();

        switchColor(connectionNumber, rend);

        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        connectionNumber++;
        connectionNumber = connectionNumber % spawnerCount;

        switchColor(connectionNumber, rend);

        connectedSpawner = GetSpawner(connectionNumber, spawners);

        foreach (GameObject shipTile in shipTiles) { shipTile.GetComponent<ShipTile>().UpdateConnection(); }
    }

    public void addTroop(SpawnTroop troop)
    {
        spawnTroops.Add(troop);
    }
    public void removeTroop(SpawnTroop troop)
    {
        spawnTroops.Remove(troop);
    }

    public void sendTroopData()
    {
        List<SpawnTroop> sendTroops = spawnTroops.OrderBy(o=>o.spawn_index).ToList();

        connectedSpawner.GetComponent<Spawner>().addTroops(sendTroops);
        
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

    private GameObject GetSpawner(int connection_number, GameObject[] _spawners)
    {
        for (int i = 0; i < _spawners.Length; i++)
        {
            if (_spawners[i].GetComponent<Spawner>().spawnNumber == connection_number)
            {
                return _spawners[i];

            }
        }
        return null;
    }
}
