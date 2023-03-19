using System;
using HogwartsSurvivor.Enums;
using UnityEngine;

namespace HogwartsSurvivor.Views
{
    public abstract class DamageableView : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private Team team;

        public float MaxHealth => maxHealth;
        public Team Team => team;
    }

    public class EnemyDamageableView : MonoBehaviour
    {
        
    }
}