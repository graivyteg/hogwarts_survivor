using System;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using Unity.VisualScripting;
using UnityEngine;

namespace HogwartsSurvivor.Models
{
    public abstract class DamageableData<T> : BaseModel<T> where T : DamageableView
    {
        public float Health { get; protected set; }
        public float MaxHealth { get; protected set; }
        
        public float NormalizedHealth => Health / MaxHealth;
        public bool IsAlive => Health > 0;
        
        public event Action<object, float> OnDamaged;
        public event Action<object, float> OnHealed;
        public event Action<object> OnKilled; 

        public DamageableData(T view) : base(view)
        {
            Health = view.MaxHealth;
            MaxHealth = view.MaxHealth;
            view.InitData(() => Health, () => NormalizedHealth);
        }

        public virtual void ApplyDamage(float damage)
        {
            if (Health == 0) return;
            
            Health -= Mathf.Min(damage, Health);
            if (Health > 0)
            {
                OnDamaged?.Invoke(this, damage);
                return;
            }
            OnKilled?.Invoke(this);
        }

        public virtual void ApplyHeal(float healAmount)
        {
            Health = Mathf.Min(Health + healAmount, MaxHealth);
            OnHealed?.Invoke(this, healAmount);
        }

        public virtual void RestoreHealth()
        {
            Health = MaxHealth;
        }

        public virtual void Kill()
        {
            Health = 0;
            OnKilled?.Invoke(this);
        }
    }
}