using System;
using System.Collections;
using UnityEngine;

namespace _Main.Scripts.Entities
{
    public class HealthController
    {
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        public event Action<float> OnHealthChange;
        public event Action OnDie;

        public HealthController(float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0)
                OnDie?.Invoke();
            else
                OnHealthChange?.Invoke(CurrentHealth);
        }

        public void Heal(float heal)
        {
            CurrentHealth += heal;

            if (CurrentHealth >= MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
            OnHealthChange?.Invoke(CurrentHealth);
        }
    }
}
