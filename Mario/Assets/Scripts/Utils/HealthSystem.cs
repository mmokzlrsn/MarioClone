using System;
using UnityEngine;

public class HealthSystem
{
    private int maxHealth;
    private int currentHealth;

    public int MaxHealth { get { return maxHealth; } }
    public int CurrentHealth { get { return currentHealth; } }

    public event Action<int, int> OnHealthChanged;  // Event to notify when health has changed

    public HealthSystem(int maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health doesn't go below 0 or above maxHealth
        OnHealthChanged?.Invoke(currentHealth, maxHealth);  // Notify subscribers about health change

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health doesn't go below 0 or above maxHealth
        OnHealthChanged?.Invoke(currentHealth, maxHealth);  // Notify subscribers about health change
    }

    private void Die()
    {
        // Implement what happens when the entity dies (e.g., game over, destroy object, etc.)
    }
}
