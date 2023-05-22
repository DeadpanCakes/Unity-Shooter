using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float accuracy;
    public float secondsBetweenShots;
    public float numberOfProjectiles;
    float secondsSinceLastShot;

    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastShot = secondsBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        secondsSinceLastShot += Time.deltaTime;
    }
    public void Fire(Vector3 targetPosition) {

        if (secondsSinceLastShot >= secondsBetweenShots)
        {
            for (int i = 0; i < numberOfProjectiles; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);

                float inaccuracy = Vector3.Distance(transform.position, targetPosition) / accuracy;
                Vector3 offset = targetPosition;
                offset.x += Random.Range(-inaccuracy, inaccuracy);
                offset.z += Random.Range(-inaccuracy, inaccuracy);
                bullet.transform.LookAt(offset);
            }
            secondsSinceLastShot = 0;
        }
    }
}
