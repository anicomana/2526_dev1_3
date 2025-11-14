using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    private bool isLowEnough = true;
    private ScoreManagerX scoreManager;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;



    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        scoreManager = GameObject.Find("_ScoreManager").GetComponent<ScoreManagerX>();

        // Apply a small upward force at the start of the game
        playerRb = GetComponent<Rigidbody>();
        playerRb.AddForce(Vector3.up * 1, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && isLowEnough == true) {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        if (transform.position.y > 14) {
            isLowEnough = false;
        } else {
            isLowEnough = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
        switch (other.gameObject.tag) {
            // if player collides with bomb, explode and set gameOver to true
            case "Bomb":
                GameOverAnimation();
                scoreManager.GameOverScreen();
                Destroy(other.gameObject);
                break;

            // if player collides with money, fireworks
            case "Money":
                fireworksParticle.Play();
                playerAudio.PlayOneShot(moneySound, 1.0f);
                Destroy(other.gameObject);
                scoreManager.AddScore(1);
                break;

            // if player collides with ground, float up
            case "Ground":
                isLowEnough = true;
                playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
                break;

            // if player collides with ceiling, float down
            case "Ceiling":
                isLowEnough = true;
                playerRb.AddForce(Vector3.down * floatForce * 0.5f, ForceMode.Impulse);
                break;
        }
    }

    private void GameOverAnimation()
    {
                explosionParticle.Play();
                playerAudio.PlayOneShot(explodeSound, 1.0f);
                gameOver = true;
                Debug.Log("Game Over! Final score: " + scoreManager.GetPlayerScore());
    }
}
