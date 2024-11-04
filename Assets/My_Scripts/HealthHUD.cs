using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    public HealthScript playerHealth;      // Reference to the player's HealthScript
    public Slider healthSlider;            // Reference to the health slider UI element
    public TMP_Text healthText;            // Reference to the health text UI element

    void Start()
    {
        // Initialize the slider's max value to the player's max health
        healthSlider.maxValue = playerHealth.maxHealth;
    }

    void Update()
    {
        // Update the slider and text based on the player's current health
        healthSlider.maxValue = playerHealth.maxHealth;
        healthSlider.value = playerHealth.GetCurrentHealth();
        healthText.text = "Health: " + playerHealth.GetCurrentHealth();
    }
}
