using System.Collections.Generic;
using System.Linq;
using Game.Core;
using Game.Enemy;
using Game.Pool;
using UnityEngine;

namespace Game.Weapon
{
    public class TargetSpell : ISpell
    {
        private PoolSystem _pool;
        private TargetSpellData _data;

        private List<EnemyDamageable> _enemies;

        private float _cooldown;
        
        public TargetSpell(SpellCaster caster, TargetSpellData data)
        {
            _pool = BaseScene.GetInstance().GetSystem<PoolSystem>();
            _cooldown = 0;
            _data = data;
            _enemies = new List<EnemyDamageable>();
            SpawnSphere(caster);   
        }
        
        public void Update(float dt)
        {
            _cooldown -= Mathf.Min(_cooldown, dt);
        }
        
        public bool TryCast(SpellCaster caster)
        {
            if (_cooldown > 0)
            {
                Debug.LogWarning("Cooldown!");
                return false;
            }
            
            if (TryGetClosestEnemy(caster.transform.position, out var enemy))
            {
                Cast(caster, enemy);
                return true;
            }
            
            Debug.LogWarning("No enemies found!");
            return false;
        }
        
        protected virtual void Cast(SpellCaster caster, EnemyDamageable enemy)
        {
            var obj = _pool.Get(_data.PoolKey);
            obj.transform.position = caster.CastPoint.position;
            obj.GetComponent<TargetProjectile>().Setup(enemy);
            _cooldown = _data.Cooldown;
        }

        /// <summary>
        /// Создает сферу вокруг игрока, чтобы отслеживать противников по коллизии, а не просчитывать всех
        /// </summary>
        /// <param name="caster"></param>
        private void SpawnSphere(SpellCaster caster)
        {
            var sphere = new GameObject("Target Spell Trigger")
            {
                transform =
                {
                    parent = caster.transform,
                    localPosition = Vector3.zero
                }
            };
            
            var collider = sphere.AddComponent<SphereCollider>();
            collider.isTrigger = true;
            collider.radius = _data.MaxDistance;
            
            var performer = sphere.AddComponent<ColliderEnemyPerformer>();
            performer.OnEnterTrigger += (enemy) =>
            {
                _enemies.Add(enemy);
            };
            performer.OnExitTrigger += (enemy) =>
            {
                _enemies.Remove(enemy);
            };
        }

        private bool TryGetClosestEnemy(Vector3 position, out EnemyDamageable result)
        {
            result = null;
            if (_enemies.Count == 0) return false;
            
            float bestDistance = Mathf.Infinity;
            float dist;

            _enemies.RemoveAll(enemy => !enemy.gameObject.activeInHierarchy);
            foreach (var enemy in _enemies)
            {
                dist = Vector3.Distance(enemy.transform.position, position);
                if (dist < bestDistance)
                {
                    bestDistance = dist;
                    result = enemy;
                }
            }
            
            return true;
        }
    }
}