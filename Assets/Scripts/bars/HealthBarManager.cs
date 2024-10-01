


using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public HealthBar healthBar; // Référence à la barre de santé

    private float currentHealth;
    private float maxHealth = 100f;

    void Start()
    {
        Debug.Log("Démarrage du script HealthBarManager"); // Debug pour vérifier que Start est bien appelé
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); // Initialiser la barre de santé avec la valeur maximale
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("insect"))
        {
            Debug.Log("Flèche haut appuyée, inflige 10 points de dégâts");
            TakeDamage(50);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Limiter la santé entre 0 et la santé max
        Debug.Log("Santé actuelle après dégâts : " + currentHealth); // Vérifier que la santé est correctement calculée
        healthBar.SetHealth(currentHealth, maxHealth); // Appeler la mise à jour de la barre de santé

        if (currentHealth == 0)
        {
            GameObject.Find("ClairePlayer").GetComponent<ClaireController>().isDead = true;
        }
    }
}
