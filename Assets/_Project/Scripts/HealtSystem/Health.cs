using UnityEngine;
using System;
public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    float currentHealth;
    public float CurrentHealth => currentHealth;

    public bool IsDead { get; private set; }
    public Action<float, float> OnHealthChanged;
    public Action Died;

    public void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (IsDead) return;

        currentHealth -= damage;
        Debug.Log($"HP: {currentHealth}/{maxHealth}");
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public void SetHealth(float health, float _maxHealth)
    {
        currentHealth = health;
        maxHealth = _maxHealth;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    void Die()
    {
        IsDead = true;
        gameObject.SetActive(false);
        Died?.Invoke();
    }
}
