using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public static int healthMultiplier = 1;

    public float speed = 10.0f;
    public float maxHealth = 100;

    public float currentHealth;
    public int destroyBounty = 80;
    public GameObject particleOnDeath;

    Transform nextCheckpoint;
    int checkPointsCount;


    [Header("Dont change this")]
    public Image healthBar;

    void Start()
    {
        maxHealth *= healthMultiplier;
        currentHealth = maxHealth;
        checkPointsCount = 0;
        nextCheckpoint = Checkpoints.checkpoints[checkPointsCount];        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            DestroyShip();
        }

        healthBar.fillAmount = currentHealth / maxHealth;
    }

    void DestroyShip()
    {
        PlayerStats.Coins += destroyBounty;
        PlayerStats.Points += destroyBounty*3;
        //GameObject effect = Instantiate(particleOnDeath, transform.position, Quaternion.identity);        
        Destroy(gameObject);
        //Destroy(effect, 3);
    }

    void Update()
    {
        Vector3 direction = nextCheckpoint.position - transform.position;
        transform.LookAt(nextCheckpoint.transform);

        transform.position += transform.forward * Time.deltaTime * speed;
        if (Vector3.Distance(transform.position, nextCheckpoint.position) <=0.1 )
        {            
            checkPointsCount++;

            if (checkPointsCount >= Checkpoints.checkpoints.Length)
            {
                Destroy(gameObject);
                PlayerStats.Lives--;
                return;
            }
            nextCheckpoint = Checkpoints.checkpoints[checkPointsCount];
        }
    }
}
