using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Slider healthSlider;
    public Slider enemyCountSlider;

    public int playerStartingHealth = 100;
    public int enemyCount = 20;

    void Start()
    {
        // Initialize sliders with default values
        healthSlider.value = playerStartingHealth;
        enemyCountSlider.value = enemyCount;

        // Add listeners to update values when sliders change
        healthSlider.onValueChanged.AddListener(delegate { UpdatePlayerHealth(); });
        enemyCountSlider.onValueChanged.AddListener(delegate { UpdateEnemyCount(); });
    }

    public void UpdatePlayerHealth()
    {
        playerStartingHealth = (int)healthSlider.value;
    }

    public void UpdateEnemyCount()
    {
        enemyCount = (int)enemyCountSlider.value;
    }
}
