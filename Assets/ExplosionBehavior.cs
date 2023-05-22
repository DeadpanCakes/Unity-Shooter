using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
{
    public float lifespan;
    float secondsAlive;
    // Start is called before the first frame update
    void Start()
    {
        secondsAlive = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        secondsAlive += Time.fixedDeltaTime;
        float duration = secondsAlive / lifespan;
        Vector3 maxScale = Vector3.one * 5;
        transform.localScale = Vector3.Lerp(Vector3.zero, maxScale, duration);
        if (secondsAlive > lifespan)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Health colliderHealth = collider.gameObject.GetComponent<Health>();
        if (colliderHealth != null)
        {
            colliderHealth.TakeDamage(3);
        }
    }
}
