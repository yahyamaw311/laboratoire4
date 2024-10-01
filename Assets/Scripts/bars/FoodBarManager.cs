using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBarManager : MonoBehaviour
{
    public HealthBar foodBar;

    private float currentHealth;
    private float maxHealth = 100f;

    void Start()
    {
        currentHealth = maxHealth;
        foodBar.SetMaxHealth(maxHealth);
        StartCoroutine(PutDamage());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("food"))
        {
            currentHealth += (currentHealth < 70 ? 30 : 100 - currentHealth);
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            foodBar.SetHealth(currentHealth, maxHealth);
        }
    }

    IEnumerator PutDamage()
    {
        while (true)
        {
            decrementEnergy(10);
            yield return new WaitForSeconds(1.5f);
        }

    }

    public void decrementEnergy(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        foodBar.SetHealth(currentHealth, maxHealth);
    }
}
