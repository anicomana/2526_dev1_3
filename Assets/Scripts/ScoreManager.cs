using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int playerScore = 0;

    void Start()
    {

    }

    void Update()
    {

    }

    public void AddScore(int amount)
    {
        playerScore += amount;
        Debug.Log("Score: " + playerScore);
    }
}