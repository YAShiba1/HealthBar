using UnityEngine;

public class Player : MonoBehaviour
{
    public float MaxHealth { get; private set; } = 50f;
    public float MinHealth { get; private set; } = 0;
    public float CurrentHealth { get; private set; }

    private void Start()
    {
        CurrentHealth = MinHealth;
    }

    public void TakeDamage(float damageValue)
    {
        if(CurrentHealth < damageValue)
        {
            CurrentHealth = 0;
        }
        else
        {
            CurrentHealth -= damageValue;
        }
    }

    public void Healing(float healValue)
    {
        CurrentHealth += healValue;

        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }
}