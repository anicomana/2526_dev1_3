using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    public Rigidbody rb;
    public float moveLeftSpeed = -10.0f;
    private PlayerController playerControllerScript;
    public float leftBound = -15.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerControllerScript = GameObject.Find("SimplePeople_Woman_Doctor_Black").GetComponent<PlayerController>();
    }

    void Update()
    {

        if (playerControllerScript.gameOver == false) {
            rb.linearVelocity = new Vector3(moveLeftSpeed, rb.linearVelocity.y, 0);
        } else {
            rb.linearVelocity = Vector3.zero;
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
