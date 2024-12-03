using UnityEngine;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour
{
    [Header("UI Components")]
    public Image batteryImage; // Reference to the UI Image component

    [Header("Sprites")]
    public Sprite batteryEmpty;   // 0% battery sprite
    public Sprite battery20;      // 20% battery sprite
    public Sprite battery40;      // 40% battery sprite
    public Sprite battery60;      // 60% battery sprite
    public Sprite battery80;      // 80% battery sprite
    public Sprite batteryFull;    // 100% battery sprite

    [Header("Player Health")]
    public HealthScript playerHealth; 

    void Update()
    {
        UpdateBatterySprite();
    }

    void UpdateBatterySprite()
    {
        if (playerHealth.GetCurrentHealth() >= 90)
        {
            batteryImage.sprite = batteryFull;
        }
        else if (playerHealth.GetCurrentHealth() >= 80)
        {
            batteryImage.sprite = battery80;
        }
        else if (playerHealth.GetCurrentHealth() >= 60)
        {
            batteryImage.sprite = battery60;
        }
        else if (playerHealth.GetCurrentHealth() >= 40)
        {
            batteryImage.sprite = battery40;
        }
        else if (playerHealth.GetCurrentHealth() >= 20)
        {
            batteryImage.sprite = battery20;
        }
        else
        {
            batteryImage.sprite = batteryEmpty;
        }
    }
}
