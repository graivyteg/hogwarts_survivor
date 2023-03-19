using System.Collections.Generic;
using HogwartsSurvivor.Models;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Controllers
{
    public class EnemyController : BaseController
    {
        public override bool HasUpdate => true;

        private List<EnemyData> enemies;
        private Transform target;

        private PoolController poolController;
        
        private readonly int moveSpeedHash = Animator.StringToHash("MoveSpeed");

        public EnemyController(GamePlayerView playerView)
        {
            enemies = new List<EnemyData>();
            target = playerView.transform;

            poolController = EntryPoint.GetInstance().GetController<PoolController>();
        }
        
        public void AddView(EnemyView view)
        {
            var enemy = new EnemyData(view);
            enemy.OnDamaged += OnDamaged;
            enemy.OnKilled += OnKilled;
            
            TrySubscribePoolableEvents(enemy);
            enemies.Add(enemy);
        }

        private bool TrySubscribePoolableEvents(EnemyData enemy)
        {
            if (!enemy.IsPoolable) return false;

            poolController.OnTakenFromPool += view =>
            {
                if (view == enemy.PoolableView) OnTakenFromPool(enemy);
            };
            poolController.OnReturnedToPool += view =>
            {
                if (view == enemy.PoolableView) OnReturnedToPool(enemy);
            };
            return true;
        }

        public override void Update(float dt)
        {
            foreach (var enemy in enemies)
            {
                var view = enemy.View;
                view.Agent.speed = view.MoveSpeed;
                view.Agent.angularSpeed = view.RotationSpeed;
                view.Agent.destination = target.transform.position;
                UpdateAnimations(view);
            }
        }

        public void KillRandom()
        {
            var enemy = enemies[0];
            Kill(enemy);
        }
        
        public void DealDamage(EnemyData model, float damage)
        {
            model.ApplyDamage(damage);
        }

        public void Kill(EnemyData model)
        {
            model.Kill();
        }

        protected virtual void OnTakenFromPool(EnemyData enemy)
        {
            enemies.Add(enemy);
            enemy.RestoreHealth();
        }

        protected virtual void OnReturnedToPool(EnemyData enemy) { }

        protected virtual void OnDamaged(object sender, float damage)
        {
            Debug.Log("AY BLYA");
        }

        protected virtual void OnKilled(object sender)
        {
            var enemy = (EnemyData)sender;
            enemies.Remove(enemy);
            
            if (!enemy.IsPoolable)
            {
                Object.Destroy(enemy.View.gameObject);
                return;
            }
            
            var pool = EntryPoint.GetInstance().GetController<PoolController>();
            pool.ReturnToPool(enemy.PoolableView);
        }
        
        protected virtual void UpdateAnimations(EnemyView view)
        {
            view.Animator.SetFloat(moveSpeedHash, view.Agent.velocity.magnitude / view.MoveSpeed);
        }
    }
}