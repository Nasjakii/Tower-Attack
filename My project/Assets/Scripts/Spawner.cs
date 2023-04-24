
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform enemy;
    public float spawnRate = 1f; //pause second

    private float downtime = 0;


    void Update()
    {
        if (Input.GetKey("space") && downtime <= 0)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            downtime = spawnRate * Time.deltaTime * 60;
        }
        else {
            downtime -= Time.deltaTime;
        }
    }
}
