using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemy : MonoBehaviour
{    
    [Header("User-modification variables")]

    [SerializeField] float range = 10f;
    public float turnSpeed = 10f;
    public float fireRate;
    float fireCountdown = 0f;
    [SerializeField]
    float cannonballDamage;


    [Header("In-Game variables")]
    public Transform enemyLocation;
    string enemyTag = "Enemy";
    public Transform rotator;

    public GameObject cannonballPrefab;
    public Transform cannonballSpawnPoint;

    void Start()
    {
        InvokeRepeating("UpdateEnemyLocation", 0, 0.5f);
    }

    void UpdateEnemyLocation()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if(closestEnemy != null && shortestDistance <= range)
        {
            enemyLocation = closestEnemy.transform;
        }
        else
        {
            enemyLocation = null;
        }

    }

    void Update()
    {
        if (enemyLocation == null)
        {
            return;
        }

        Vector3 lookDirection = enemyLocation.position - transform.position;
        Quaternion cannonLookRotation = Quaternion.LookRotation(lookDirection);
        Vector3 cannonRotation = Quaternion.Lerp(rotator.rotation,cannonLookRotation,Time.deltaTime * turnSpeed).eulerAngles;
        rotator.rotation = Quaternion.Euler(0.0f,cannonRotation.y,0.0f);



        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot()
    {
        GameObject firedCannonballGO = (GameObject)Instantiate(cannonballPrefab, cannonballSpawnPoint.position, cannonballSpawnPoint.rotation);
        Cannonball firedCannonball = firedCannonballGO.GetComponent<Cannonball>();

        if(firedCannonball != null)
        {
            firedCannonball.Aim(enemyLocation, cannonballDamage);
        }
    }
}
