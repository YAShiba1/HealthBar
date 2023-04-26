using UnityEngine;

public class Player : MonoBehaviour
{
    private float _currentHealth;

    public float MaxHealth { get; private set; } = 50f;
    public float MinHealth { get; private set; } = 0;
    public float CurrentHealth 
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, MinHealth, MaxHealth); } 
    }

    private void Start()
    {
        CurrentHealth = MinHealth;
    }

    public void TakeDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
    }

    public void Healing(float healValue)
    {
        CurrentHealth += healValue;
    }
}