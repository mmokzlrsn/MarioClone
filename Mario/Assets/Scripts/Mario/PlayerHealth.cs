using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private HealthSystem healthSystem;

    private void Start()
    {
        int maxHealth = 100;  // Set the maximum health for the player
        healthSystem = new HealthSystem(maxHealth);
        healthSystem.OnHealthChanged += UpdateHealthUI;  // Subscribe to health change events
    }

    private void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        // Update UI elements to reflect the current health (e.g., health bars, text, etc.)
    }

    private void TakeDamage(int amount)
    {
        healthSystem.Damage(amount);
    }

    private void Heal(int amount)
    {
        healthSystem.Heal(amount);
    }
}
