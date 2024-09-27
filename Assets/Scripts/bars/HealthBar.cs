using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    public Text healthText;

    // Fonction pour initialiser la barre de santé à la valeur maximale
    public void SetMaxHealth(float maxHealth)
    {
        Slider.maxValue = maxHealth;
        Slider.value = maxHealth;
        healthText.text = "100%";
    }

    // Utilise une Coroutine pour mettre à jour progressivement la barre de santé
    public void SetHealth(float health, float maxHealth)
    {
        StartCoroutine(SmoothHealthTransition(health));
        healthText.text = (health / maxHealth * 100).ToString() + "%";
    }

    // Coroutine pour animer la transition de la barre de santé
    private IEnumerator SmoothHealthTransition(float targetHealth)
    {
        while (Mathf.Abs(Slider.value - targetHealth) > 1)
        {
            Slider.value = Mathf.Lerp(Slider.value, targetHealth, Time.deltaTime * 5);
            yield return null; // Attendre le frame suivant avant de continuer la boucle
        }
        Slider.value = targetHealth;
        Canvas.ForceUpdateCanvases(); // Assurez-vous que le Canvas est à jour
    }
}
