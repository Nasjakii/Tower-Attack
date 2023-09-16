using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneHub : MonoBehaviour
{
    [Header("Spawn")]
    public GameObject drone;
    public float spawn_cooldown;
    public int max_drone_count;

    private float spawn_timer;

    private Animator animator;
    private float animation_time = 0;
    private float animation_time_min = 2f;
    private float animation_time_max = 10f;

    private GameObject spawner;
    
    private List<GameObject> drones = new List<GameObject>();

    private void Start()
    {
        GameObject model = transform.GetChild(0).gameObject;
        animator = model.GetComponent<Animator>();
        spawner = GameObject.FindGameObjectWithTag("Spawner");

        spawn_timer = spawn_cooldown;
    }

    private void Update()
    {
        if (!spawner.GetComponent<Spawner>().spawn) return;
        

        spawn_timer -= Time.deltaTime;
        if (spawn_timer <= 0)
        {
            if (drones.Count < max_drone_count)
            {
                spawn_timer = spawn_cooldown;
                GameObject inst = Instantiate(drone, transform.position - new Vector3(0, 3, 0), Quaternion.identity);
                inst.GetComponent<Drone>().hub = gameObject;
                drones.Add(inst);
            }
        }
            

        if (animator == null) return;

        animation_time -= Time.deltaTime;
        if (animation_time <= 0)
        {
            animation_time = Random.Range(animation_time_min, animation_time_max);
            if (animator.GetInteger("radar_index") == 1)
            {
                animator.SetInteger("radar_index", 2);
            } else
            {
                animator.SetInteger("radar_index", 1);
            }
        }
        
    }

    public void Remove(GameObject drone)
    {
        Debug.Log("remove");
        if (drone.GetComponent<Drone>().hub == null) return;
        Debug.Log("delete");
        drones.Remove(drone);
    }
}
