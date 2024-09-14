using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Slider staminaBar;
    public float maxStamina = 100f;
    public float currentStamina; // Ensure this is public
    public float staminaRegenRate = 5f;
    public float jumpStaminaCost = 20f;

    void Start()
    {
        currentStamina = maxStamina; // Start with full stamina
        staminaBar.maxValue = maxStamina;
        staminaBar.value = currentStamina;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && currentStamina >= jumpStaminaCost)
        {
            Jump();
        }

        RegenerateStamina();
        staminaBar.value = currentStamina;
    }

    void Jump()
    {
        // Your jump logic here
        currentStamina -= jumpStaminaCost;
        if (currentStamina < 0)
        {
            currentStamina = 0; // Prevent stamina from going negative
        }
    }

    void RegenerateStamina()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina; // Prevent stamina from exceeding max
            }
        }
    }

    public float GetStaminaPercentage()
    {
        return currentStamina / maxStamina;
    }
}
