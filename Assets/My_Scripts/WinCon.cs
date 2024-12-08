using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCon : MonoBehaviour
{
    [Header("Win Condition Settings")]
    public int requiredCollectibles = 4; // Number of collectibles required to win
    private int collectedCount = 0;      // Tracks how many collectibles have been gathered
    public string winScene = "Win"; // Name of the win screen scene

    // Method to increment the collectible count
    public void Collect()
    {
        collectedCount++;
        Debug.Log($"Collected {collectedCount}/{requiredCollectibles}");

        // Check if the win condition is met
        if (collectedCount >= requiredCollectibles)
        {
            TriggerWin();
        }
    }

    // Method to handle the win condition
    private void TriggerWin()
    {
        Debug.Log("All collectibles gathered! Loading win screen...");
        SceneManager.LoadScene(winScene);
    }
}
