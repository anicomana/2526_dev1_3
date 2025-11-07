using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    public float jumpForce = 40.0f;
    public float gravityModifier = 1.0f;

    private bool isOnGround = true;
    public bool gameOver = false;

    private Animator playerAnim;

    // Come faccio a far muovere il player a destra e sinistra?
    /*private float horizontalInput;
    public float moveForce = 10.0f;*/

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        playerAnim = GetComponent<Animator>();
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
            isOnGround = false;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1); /* oppure 2, come fare random?*/
            Debug.Log("Game Over!");
        }
    }
}
