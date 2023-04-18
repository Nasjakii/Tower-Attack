
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform enemy;



    void Update()
    {
        if (Input.GetKey("space"))
        {
            Instantiate(enemy, transform.position, transform.rotation);
        }
    }
}
