using System;
using HogwartsSurvivor.Enums;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Models
{
    public class DamageableData : BaseModel<DamageableView>
    {
        private float health;
        private float maxHealth;
        private Team team;

        public float NormalizedHealth => health / maxHealth;
        public float Health => health;

        public event Action<DamageableData, float> OnDamaged;
        public event Action<DamageableData> OnDied;

        public DamageableData(DamageableView view) : base(view)
        {
            health = view.MaxHealth;
            maxHealth = view.MaxHealth;
            team = view.Team;
        }

        public bool TryApplyDamage(float damage, Team dealerTeam)
        {
            if (dealerTeam == team) return false;

            health -= Mathf.Min(health, damage);

            if (health == 0)
            {
                Kill();
            }
            else
            {
                OnDamaged?.Invoke(this, damage);
            }

            return true;
        }

        private void Kill()
        {
            OnDied?.Invoke(this);
        }
    }
}