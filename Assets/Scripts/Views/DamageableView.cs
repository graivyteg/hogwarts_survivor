using UnityEngine;

namespace HogwartsSurvivor.Views
{
    public class DamageableView : MonoBehaviour
    {
        [Header("Damageable")]
        [SerializeField] private float maxHealth = 100;

        public float MaxHealth => maxHealth;
    }
}