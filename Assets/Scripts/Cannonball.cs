using UnityEngine;

public class Cannonball : MonoBehaviour
{

    private Transform target;
    public float speed = 70f;
    [SerializeField] GameObject destroyedCannonballEffect;

    private float cannonballDamage;


    public void Aim(Transform target, float cannonballDamage)
    {
        this.target = target;
        this.cannonballDamage = cannonballDamage;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }


        transform.Translate(direction.normalized * distanceThisFrame,Space.World);
    }

    void HitTarget()
    {
        Enemy e = target.GetComponent<Enemy>();
        e.TakeDamage(cannonballDamage);


        Destroy(gameObject);

        GameObject destroyedCannonballEffectGO = (GameObject)Instantiate(destroyedCannonballEffect, transform.position, transform.rotation);
        Destroy(destroyedCannonballEffectGO, 1.0f);
    }
}
