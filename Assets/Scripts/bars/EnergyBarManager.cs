using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class EnergyBarManager : MonoBehaviour
{
    public HealthBar energyBar; // R�f�rence � la barre de sant�

    private float currentHealth;
    private float maxHealth = 100f;


    void Start()
    {
        currentHealth = maxHealth;
        energyBar.SetMaxHealth(maxHealth); // Initialiser la barre de sant� avec la valeur maximale
        StartCoroutine(PutDamage());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("battery"))
        {
            currentHealth += (currentHealth < 70 ? 30 : 100 - currentHealth);
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            energyBar.SetHealth(currentHealth, maxHealth);
        }
    }

    IEnumerator PutDamage()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetAxis("Vertical") > 0)
            {
                DecrementEnergy(4);
            }
            else if(Input.GetAxis("Vertical") != 0)
            {
                DecrementEnergy(2);
            }
            yield return new WaitForSeconds(1);
        }
        
    }


    public void DecrementEnergy(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        energyBar.SetHealth(currentHealth, maxHealth);

        if (currentHealth == 0)
        {
            GameObject.Find("ClairePlayer").GetComponent<ClaireController>().isDead = true;
        }
    }
}
