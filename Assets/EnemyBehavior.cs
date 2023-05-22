using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public float maxSpeed;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (References.pc != null)
        {
            Rigidbody enemyBody = GetComponent<Rigidbody>();
            Vector3 vectorToPC = References.pc.transform.position - transform.position;
            enemyBody.velocity = vectorToPC.normalized * maxSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.GetComponent<PlayerBehavior>() != null)
        {
            Health theirHealth = collided.GetComponent<Health>();
            if (theirHealth != null)
            {
                theirHealth.TakeDamage(1);
            }
        }
    }

}
