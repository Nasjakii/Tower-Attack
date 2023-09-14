
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 1f; //pause second

    private float downtime = 0;

    public List<SpawnTroop> spawnTroops = new List<SpawnTroop>();
    public List<GameObject> troopsToSpawn = new List<GameObject>();
    public List<float> spawnTime = new List<float>();
    public List<float> pauseTime = new List<float>();

    public bool spawn = false;
    public int spawnNumber = 0;


    private Renderer rend;
    public Transform spawnLocation;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        switchColor(spawnNumber, rend);
    }

    void FixedUpdate()
    {

        if (spawn == false) return;
        

        if (troopsToSpawn.Count > 0 && downtime <= 0)
        {
            Instantiate(troopsToSpawn[0], transform.position, troopsToSpawn[0].transform.rotation);
            troopsToSpawn.RemoveAt(0);
            downtime = spawnTime[0] + pauseTime[0] * Time.deltaTime * 60;
            spawnTime.RemoveAt(0);
            pauseTime.RemoveAt(0);
        }
        else
        {
            downtime -= Time.deltaTime;
        }
    }

    public void addTroops(List<SpawnTroop> troopList)
    {
        foreach(SpawnTroop troop in troopList)
        {

            for (int i = 0; i < troop.count; i++)
            {
                troopsToSpawn.Add(troop.troopPrefab);
                spawnTime.Add(troop.time_between_spawns);
                pauseTime.Add(0f);


            }
            pauseTime.RemoveAt(pauseTime.Count - 1);
            pauseTime.Add(troop.time_after_spawn);
        }

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

[System.Serializable]
public class SpawnTroop
{
    public GameObject troopPrefab;
    public int count;
    public int spawn_index; //defined by tile_index in shipTile
    public float time_between_spawns;
    public float time_after_spawn;
}
