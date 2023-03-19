using Game.Enemy;
using Game.Pool;
using UnityEngine;

namespace Game.Weapon
{
    public class TargetProjectile : PoolMonoBehaviour
    {
        [SerializeField] private float _damage = 10;
        [SerializeField] private float _speed = 1;
        [SerializeField] private float _explosionDistance = 0.3f;
        
        private EnemyDamageable _target;
        
        public void Setup(EnemyDamageable target)
        {
            _target = target;
        }
        
        protected override void OnUpdate(float dt)
        {
            if (_target != null)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position, 
                    _target.SpellPoint.position, 
                    _speed * dt);

                if (Vector3.Distance(transform.position, _target.SpellPoint.position) < _explosionDistance)
                {
                    Explode();
                }
            }
        }

        protected virtual void Explode()
        {
            _target.DealDamage(_damage);
            ReturnToPool();
        }
    }
}