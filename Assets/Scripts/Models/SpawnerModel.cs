using System;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Models
{
    public class SpawnerModel 
    {
        private string key;
        private float maxCooldown;
        private float cooldown;
        
        public event Action<Vector3, string> OnCooldown;
        
        private Transform transform;
        
        public SpawnerModel(Transform viewTransform, string poolKey, float cooldown)
        {
            key = poolKey;
            maxCooldown = cooldown;
            this.cooldown = cooldown;
            transform = viewTransform;
        }

        public void UpdateCooldown(float dt)
        {
            cooldown -= Mathf.Min(cooldown, dt);
            if (cooldown != 0) return;
            
            cooldown = maxCooldown;
            OnCooldown?.Invoke(transform.position, key);
        }
    }
}