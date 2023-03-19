using UnityEngine;

namespace Game.Models
{
    public class DamageableData
    {
        public float Health { get; private set; }
        public float HealthNormalized => Health / _maxHealth;
        public bool IsAlive => Health > 0;
        
        private float _maxHealth;
        
        public DamageableData(float maxHealth)
        {
            _maxHealth = maxHealth;
            Health = maxHealth;
        }

        public void ApplyDamage(float damage)
        {
            if (damage <= 0 && !IsAlive) return;
            Health -= Mathf.Min(Health, damage);
        }

        public void ApplyHeal(float heal)
        {
            if (heal <= 0 || !IsAlive) return;
            Health += heal;
            Health = Mathf.Min(Health, _maxHealth);
        }

        public void SetMaxHealth(float newValue)
        {
            _maxHealth = newValue;
        }
    }
}