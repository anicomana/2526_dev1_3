using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    public Rigidbody rb;
    public float moveLeftSpeed = -10.0f;
    public float leftBound = -15.0f;
    private PlayerController playerControllerScript;

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
        } /* Perchè non si ferma lo sfondo if è gameOver == true? */

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
