using System;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Models
{
    public class SpawnerData : BaseModel<SpawnerView>
    {
        private string key;
        private float maxCooldown;
        private float cooldown;

        public event Action<Vector3, string> OnCooldown;
        
        public SpawnerData(SpawnerView view) : base(view)
        {
            key = View.PoolKey;
            maxCooldown = View.Cooldown;
            cooldown = View.Cooldown;
        }

        public void RemoveCooldown(float time)
        {
            cooldown -= Mathf.Min(cooldown, time);
            if (cooldown == 0)
            {
                cooldown = maxCooldown;
                OnCooldown?.Invoke(View.transform.position, key);
            }
        }
    }
}