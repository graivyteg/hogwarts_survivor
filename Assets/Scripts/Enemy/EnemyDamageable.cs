using Game.Core;
using Game.Pool;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyDamageable : PoolMonoBehaviour, IDamageable
    {
        [SerializeField] private float _maxHealth = 100;
        private float _health;
        
        public Transform SpellPoint;

        protected override void OnInit()
        {
            _health = _maxHealth;
        }

        public void DealDamage(float damage)
        {
            _health -= Mathf.Min(_health, damage);
            if (_health == 0)
            {
                ReturnToPool();
            }
        }
    }
}