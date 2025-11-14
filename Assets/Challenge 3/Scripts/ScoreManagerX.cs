using UnityEngine;
using TMPro;

public class ScoreManagerX : MonoBehaviour
{
    public int playerScore = 0;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI gameOverText;

    void Start()
    {
        playerScore = 0;
    }


    public void AddScore(int amount)
    {
        playerScore += amount;
        currentScoreText.text = "Score: " + playerScore;
        Debug.Log("Score: " + playerScore);
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public void GameOverScreen()
    {
        currentScoreText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        finalScoreText.gameObject.SetActive(true);
        finalScoreText.text = "Final Score: " + playerScore;
    }

}
