using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public GameObject healthBarPrefab;
    HealthBarBehavior healthBar;
    public GameObject deathPrefab;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        GameObject healthBarInstance = Instantiate(healthBarPrefab, References.canvas.transform);
        healthBar = healthBarInstance.GetComponent<HealthBarBehavior>();
    }
    public void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                if (deathPrefab != null)
                {
                    Instantiate(deathPrefab, transform.position, transform.rotation);
                }
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        if (healthBar != null)
        {
            Destroy(healthBar.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.ShowHealthFraction(currentHealth / maxHealth);

        healthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);
    }
}
