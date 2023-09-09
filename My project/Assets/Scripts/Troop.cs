using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.Image;

public class Troop : MonoBehaviour
{
    [Header("Stats")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float damage = 1f;
    public float speed = 10f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;

    private Transform target;
    public float stunned = 0f;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        GetComponent<NavMeshAgent>().speed = speed;
    }

    void UpdateTarget()
    {
        if (firePoint == null) return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {

        if (stunned > 0f) {
            GetComponent<NavMeshAgent>().speed = 0f;
            stunned -= Time.deltaTime;
        } else
        {
            GetComponent<NavMeshAgent>().speed = speed;
        }

        if (target == null) return;
        Vector3 dir = target.position - transform.position;
        
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
