using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.Image;

public class Drone : MonoBehaviour
{
    [Header("Stats")]
    public float hp;
    public float range = 8f;
    public float damage = 1f;
    public float fireRate = 1f;
    public float speed;
    public float turnSpeed = 10f;

    [Header("Setup")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    
    private Transform target;
    private Animator animator;
    private string enemyTag = "Troop";
    private float fireCountdown = 0f;

    private void Start()
    {
        GameObject model = transform.GetChild(0).gameObject;
        animator = model.GetComponent<Animator>();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        transform.position -= new Vector3(0, -speed * Time.deltaTime, 0);

        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        transform.rotation = lookRotation;

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
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
