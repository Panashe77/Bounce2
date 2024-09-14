using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f; // Speed for forward and backward movement
    public float jumpForce = 10f; // Base jump force
    private Rigidbody2D rb;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found! Make sure the ball has a Rigidbody2D component.");
        }

        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found! Make sure there is a GameManager in the scene.");
        }
    }

    void Update()
    {
        if (gameManager != null && gameManager.IsGameStarted())
        {
            // Handle forward and backward movement
            float move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * speed, rb.velocity.y);

            // Handle jumping
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            // Ensure the player stops moving when the game is not started
            rb.velocity = Vector2.zero;
        }
    }

    void Jump()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Reset vertical velocity before applying jump force
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // No need to reset air jump count since there's no limit
    }
}
