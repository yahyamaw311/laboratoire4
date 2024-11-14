


using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public HealthBar healthBar; // R�f�rence � la barre de sant�

    private float currentHealth;
    private float maxHealth = 100f;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); // Initialiser la barre de sant� avec la valeur maximale
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("insect"))
        {
            Debug.Log("Fl�che haut appuy�e, inflige 10 points de d�g�ts");
            TakeDamage(20);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Limiter la sant� entre 0 et la sant� max
        Debug.Log("Sant� actuelle apr�s d�g�ts : " + currentHealth); // V�rifier que la sant� est correctement calcul�e
        healthBar.SetHealth(currentHealth, maxHealth); // Appeler la mise � jour de la barre de sant�

        if (currentHealth == 0)
        {
            GameObject.Find("ClairePlayer").GetComponent<ClaireController>().isDead = true;
        }
    }
}
