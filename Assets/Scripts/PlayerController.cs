using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private Stamina stamina;
    public float normalSpeed = 5f;
    public float minSpeed = 1f;
    private Rigidbody2D rb;
    private AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip jumpSound; // Reference to the jump sound clip
    public AudioClip deathSound; // Reference to the death sound clip

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        stamina = GetComponent<Stamina>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    void Update()
    {
        if (gameManager != null && gameManager.IsGameStarted())
        {
            float staminaPercentage = stamina.GetStaminaPercentage();
            float currentSpeed = Mathf.Lerp(minSpeed, normalSpeed, staminaPercentage);

            if (Input.GetButtonDown("Jump") && stamina.currentStamina >= stamina.jumpStaminaCost)
            {
                Jump();
            }

            if (stamina.currentStamina <= 0)
            {
                Fall();
            }

            // Adjust player speed based on stamina
            rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
        }
        else
        {
            // Ensure the player stops moving when the game is not started
            rb.velocity = Vector2.zero;
        }
    }

    void Jump()
    {
        // Your jump logic here
        stamina.currentStamina -= stamina.jumpStaminaCost;
        if (stamina.currentStamina < 0)
        {
            stamina.currentStamina = 0; // Prevent stamina from going negative
        }

        // Play the jump sound
        if (audioSource != null && jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    void Fall()
    {
        // Logic to make the player fall
        rb.velocity = new Vector2(rb.velocity.x, -normalSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pipe"))
        {
            // Play the death sound
            if (audioSource != null && deathSound != null)
            {
                audioSource.PlayOneShot(deathSound);
            }

            gameManager.GameOver();
        }
        else if (other.CompareTag("PipeTrigger"))
        {
            gameManager.PipeJumped(); // Call the method from GameManager
        }
    }
}
