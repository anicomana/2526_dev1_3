using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 40.0f;
    public float gravityModifier = 1.0f;
    private bool isOnGround = true;
    public bool gameOver = false;


    /*private float horizontalInput;
    public float moveForce = 10.0f;*/

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }


    void Update()
    {
        /*horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            playerRb.AddForce(Vector3.right * moveForce, ForceMode.Force);
        }*/

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
