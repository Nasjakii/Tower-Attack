
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 1f; //pause second

    private float downtime = 0;

    public List<SpawnTroop> spawnTroops = new List<SpawnTroop>();
    public List<GameObject> troopsToSpawn = new List<GameObject>();
    public List<float> spawnTime = new List<float>();
    public List<float> pauseTime = new List<float>();

    public Transform spawnLocation;
    private void Start()
    {
        GenerateTroops();
    }

    void FixedUpdate()
    {
        if (troopsToSpawn.Count > 0 && downtime <= 0)
        {
            Instantiate(troopsToSpawn[0], transform.position, transform.rotation);
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

    public void GenerateTroops()
    {
        List<GameObject> generatedTroops = new List<GameObject>();
        List<float> spawnTimeList = new List<float>();
        List<float> pauseTimeList = new List<float>();
        for (int i = 0; i < spawnTroops.Count; i++)
        {
            for(int i2 = 0; i2 < spawnTroops[i].count; i2++)
            {
                generatedTroops.Add(spawnTroops[i].troopPrefab);
                spawnTimeList.Add(spawnTroops[i].time_between_spawns);
                pauseTimeList.Add(0f);
            }
            pauseTimeList.RemoveAt(pauseTimeList.Count - 1);
            pauseTimeList.Add(spawnTroops[i].time_after_spawn);
            
        }
        pauseTime.Clear();
        pauseTime = pauseTimeList;
        spawnTime.Clear();
        spawnTime = spawnTimeList;
        troopsToSpawn.Clear();
        troopsToSpawn = generatedTroops;
    }

    public void addTroop(SpawnTroop troop)
    {
        troopsToSpawn.Add(troop.troopPrefab);
        pauseTime.Add(troop.time_after_spawn);
        spawnTime.Add(troop.time_between_spawns);

    }



}

[System.Serializable]
public class SpawnTroop
{
    public GameObject troopPrefab;
    public int count;
    public float time_between_spawns;
    public float time_after_spawn;
}
