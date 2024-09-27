using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class EnergyBarManager : MonoBehaviour
{
    public HealthBar energyBar; // Référence à la barre de santé

    private float currentHealth;
    private float maxHealth = 100f;

    //void Start()
    //{
    //    Debug.Log("Démarrage du script HealthBarManager"); // Debug pour vérifier que Start est bien appelé
    //    currentHealth = maxHealth;
    //    energyBar.SetMaxHealth(maxHealth); // Initialiser la barre de santé avec la valeur maximale

    //    while (true)
    //    {
    //        
    //    }
    //}

    void Start()
    {
        currentHealth = maxHealth;
        energyBar.SetMaxHealth(maxHealth); // Initialiser la barre de santé avec la valeur maximale
        StartCoroutine(PutDamage());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("battery"))
        {
            currentHealth += 30;
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
                decrementEnergy(3);
            }
            else if(Input.GetAxis("Vertical") > 0)
            {
                decrementEnergy(1);
            }
            yield return new WaitForSeconds(1);
        }
        
    }


    public void decrementEnergy(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        energyBar.SetHealth(currentHealth, maxHealth);
    }
}
