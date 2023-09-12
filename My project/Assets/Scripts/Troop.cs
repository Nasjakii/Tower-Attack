using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.Image;

public class Troop : MonoBehaviour
{
    [Header("Stats")]
    public float damage = 1f; //damage when running into basis
    public float speed = 10f;
    public float maxHp = 10f;

    [SerializeField] private Healthbar healthbar;

    [Header("")]
    public bool CanShoot = false;
    [HideInInspector]
    public GameObject bulletPrefab;
    [HideInInspector]
    public Transform firePoint;
    [HideInInspector]
    public float range = 15f;
    [HideInInspector]
    public float fireRate = 1f;

    [HideInInspector]
    public float stunned = 0f;

    private Transform target;
    private string enemyTag = "Tower";
    private float currentHp;
    private float fireCountdown = 0f;
    private float baseSpeed;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        GetComponent<NavMeshAgent>().speed = speed;

        baseSpeed = speed;
        currentHp = maxHp;
        healthbar.UpdateHealtbar(maxHp, currentHp);
    }

    void UpdateTarget()
    {
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

        if (stunned > 0f) {
            GetComponent<NavMeshAgent>().speed = 0f;
            stunned -= Time.deltaTime;
        } else
        {
            GetComponent<NavMeshAgent>().speed = speed;
        }

        speed = baseSpeed;
        if (target == null) return;
        speed = 0f;

        Vector3 dir = target.position - transform.position;
        
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
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
