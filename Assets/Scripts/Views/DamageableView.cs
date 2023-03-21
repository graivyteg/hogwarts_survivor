using System;
using HogwartsSurvivor.Models;
using UnityEngine;

namespace HogwartsSurvivor.Views
{
    public class DamageableView : MonoBehaviour
    {
        [Header("Damageable")]
        [SerializeField] private float maxHealth = 100;
        
        public float MaxHealth => maxHealth;
        
        public Func<float> GetHealth { get; private set; }
        public Func<float> GetHealthNormalized { get; private set; }

        public void InitData(Func<float> healthFunc, Func<float> normalizedHealthFunc)
        {
            GetHealth = healthFunc;
            GetHealthNormalized = normalizedHealthFunc;
        }
    }
}