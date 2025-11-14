using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{

    public int playerScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        scoreText.text = "Score: " + playerScore;
    }


    public void AddScore(int amount)
    {
        playerScore += amount;
        scoreText.text = "Score: " + playerScore;
        Debug.Log("Score: " + playerScore);
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public void GameOverScreen()
    {
        scoreText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        finalScoreText.gameObject.SetActive(true);
        finalScoreText.text = "Final Score: " + playerScore;
    }
}