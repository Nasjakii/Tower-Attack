using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UIElements;
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

    private Transform center;
    public float circle_rad;
    private float timeCounter;

    private bool start_sequence_done = false;

    private void Start()
    {
        GameObject model = transform.GetChild(0).gameObject;
        currentHp = maxHp;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        center = hub.transform;
        timeCounter = 0f;
    }


    
    
    void Update()
    {

        if (currentHp <= 0f)
        {
            Destroy(gameObject);
            if (hub != null)
            {
                DroneHub hubComp = hub.GetComponent<DroneHub>();
                if (hubComp != null) hubComp.Remove(gameObject);
            }
            
        }

        if (hub != null) //cant move without center transform
        {
            if (transform.position.y < 6) //fly up before anything else
            {
                transform.position -= new Vector3(0, -speed * Time.deltaTime, 0);
                return;
            }
            if (transform.position.z - center.position.z < 3 && !start_sequence_done)  //fly to side 
            {
                transform.localPosition += new Vector3(0, 0, speed * Time.deltaTime);
                return;
            }
            else
            {
                start_sequence_done = true;
            }

            
        }


        if (target == null && hub != null) //no target -> just move
        {
            timeCounter += Time.deltaTime * speed;
            float x = Mathf.Sin(timeCounter) * circle_rad;
            float z = Mathf.Cos(timeCounter) * circle_rad;
            transform.position = new Vector3(center.position.x + x, transform.position.y, center.position.z + z);
            return;
        }

        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(rotation);

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
        
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
