using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StunTurret : MonoBehaviour
{
    [Header("Attributes")]

    public float range = 5f;
    public float cooldown = 3f;
    public float stunDuration = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public GameObject shockwave;
    private GameObject shockwaveSpawner;
    public string enemyTag = "Troop";

    public void Start()
    {
        shockwaveSpawner = Instantiate(shockwave, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
    }
    public void Update()
    {
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = cooldown;
            shockwaveSpawner.GetComponent<Shockwave>().createWave();

        }

        fireCountdown -= Time.deltaTime;
        
    }

    public void Shoot()
    {
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < range)
            {
                stun(enemy);
            }
        }
    }

    public void stun(GameObject target)
    {
        target.GetComponent<Troop>().stunned = stunDuration;

    }
}
