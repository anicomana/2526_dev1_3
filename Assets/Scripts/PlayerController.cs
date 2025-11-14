using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("VFX & SFX settings")]
    public ParticleSystem explosionParticles;
    public ParticleSystem dirtParticles;
    public AudioClip[] jumpSound;
    public AudioClip[] crashSound;

    [Header("PLAYER settings")]
    public float jumpForce = 40.0f;
    public float gravityModifier = 1.0f;
    public bool gameOver = false;
    private bool isOnGround = true;
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    private ScoreManager scoreManager;


    // Come faccio a far muovere il player a destra e sinistra?
    /*private float horizontalInput;
    public float moveForce = 10.0f;*/

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        scoreManager = GameObject.Find("_ScoreManager").GetComponent<ScoreManager>();

        Physics.gravity *= gravityModifier;
        isOnGround = true;
        gameOver = false;
    }


    void Update()
    {
        // Movimento orizzontale del player
        /*horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            playerRb.AddForce(Vector3.right * moveForce, ForceMode.Force);
        }*/

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig"); /* se animazione <1 allora animazione ritarda anche il salto? */
            dirtParticles.Stop();
            int randomIndex = Random.Range(0, jumpSound.Length);
            playerAudio.PlayOneShot(jumpSound[randomIndex], 1.0f);
            isOnGround = false;
        }

    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag) {
            case "Ground":
                isOnGround = true;
                dirtParticles.Play();
                break;

            case "ScoreZone":
                scoreManager.AddScore(1);
                isOnGround = true;
                dirtParticles.Play();
                break;

            case "Obstacle":
                PlayerDeathAnimation();
                dirtParticles.Stop();
                Debug.Log("Game Over! Final Score: " + scoreManager.GetPlayerScore());
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreZone"))
        {
            scoreManager.AddScore(1);
            isOnGround = true;
            dirtParticles.Play();
        }
    }

    private void PlayerDeathAnimation()
    {
        gameOver = true;
        int randomIndex = Random.Range(0, crashSound.Length);
        playerAudio.PlayOneShot(crashSound[randomIndex], 1.0f);
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", Random.Range(0, 2));
        explosionParticles.Play();
        scoreManager.GameOverScreen();



    }
}
