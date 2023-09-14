using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.Image;

public class Drone : MonoBehaviour
{
    [Header("Stats")]
    public float maxHp;
    public float range = 8f;
    public float damage = 1f;
    public float fireRate = 1f;
    public float speed;
    public float turnSpeed = 10f;
    public Healthbar healthbar;

    [Header("Setup")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    [HideInInspector]
    public GameObject hub;
    [HideInInspector]
    public float currentHp;

    private Transform target;
    private string enemyTag = "Troop";
    private float fireCountdown = 0f;

    private void Start()
    {
        GameObject model = transform.GetChild(0).gameObject;
        currentHp = maxHp;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (currentHp <= 0f)
        {
            hub.GetComponent<DroneHub>().Remove(gameObject);
            Destroy(gameObject);
        }
            

        

        if (target == null) //no target -> just move
        {
            if (transform.position.y < 10) transform.position -= new Vector3(0, -speed * Time.deltaTime, 0);
            return;
        }
            

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

    public void getDamage(float amount)
    {
        currentHp -= amount;
        healthbar.UpdateHealtbar(maxHp, currentHp);

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
