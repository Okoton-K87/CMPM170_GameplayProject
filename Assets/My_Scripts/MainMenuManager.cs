using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;   // Reference to the Main Menu Panel
    public GameObject creditsPanel;    // Reference to the Credits Panel
    public GameObject optionsPanel;    // Reference to the Options Panel

    public OptionsManager optionsManager; // Reference to the OptionsManager

    void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void ShowCredits()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void ShowOptions()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void StartGame()
    {
        // Store options values in GameSettings
        GameSettings.playerStartingHealth = optionsManager.playerStartingHealth;
        GameSettings.enemyCount = optionsManager.enemyCount;

        // Load the main game scene
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
