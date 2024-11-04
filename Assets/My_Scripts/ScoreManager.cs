using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreOverlay;
    public TextMeshProUGUI scoreText; // Use TextMeshProUGUI for TextMeshPro

    private int score = 0;

    void Start()
    {
        UpdateScoreText();
        scoreOverlay.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            scoreOverlay.SetActive(!scoreOverlay.activeSelf);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
