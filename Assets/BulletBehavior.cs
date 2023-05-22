using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float bulletSpeed;
    public float lifeSpan;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody bulletBody = GetComponent<Rigidbody>();
        bulletBody.velocity = transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 1)
        {
            transform.localScale *= lifeSpan;
        }

        if (lifeSpan < 0) {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.GetComponent<EnemyBehavior>() != null)
        {
            Health theirHealth = collided.GetComponent<Health>();
            if (theirHealth != null)
            {
                theirHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
