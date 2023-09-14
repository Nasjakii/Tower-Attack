using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.Image;

public class Tower : MonoBehaviour
{
    [Header("Stats")]
    public float maxHp = 10f;

    [SerializeField] private Healthbar healthbar;

    [Header("")]
    public bool CanShoot = false;
    [HideInInspector]
    public GameObject bulletPrefab;
    [HideInInspector]
    public Transform rotationPoint;
    [HideInInspector]
    public Transform firePoint;
    [HideInInspector]
    public float range = 15f;
    [HideInInspector]
    public float turnSpeed = 15f;
    [HideInInspector]
    public float fireRate = 1f;

    private float currentHp;
    private float fireCountdown = 0f;
    private Transform target;
    private string enemyTag = "Troop";
    private float fireTimer = 0f;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        currentHp = maxHp;
        healthbar.UpdateHealtbar(maxHp, currentHp);
    }

    void UpdateTarget()
    {

        //if can shoot
        if (!CanShoot) return;

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
        if (currentHp <= 0f) Destroy(gameObject);


        if (target == null) return;
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(-dir);
        Vector3 rotation = Quaternion.Lerp(rotationPoint.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotationPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireTimer <= 0f)
        {
            Shoot();
            fireTimer = 1f / fireRate;
        }

        fireTimer -= Time.deltaTime;
    }

    
    public void getDamage(float amount)
    {
        currentHp -= amount;
        healthbar.UpdateHealtbar(maxHp, currentHp);

    }

    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);

    }

    private void OnDrawGizmosSelected()
    {
        if (!CanShoot) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}
