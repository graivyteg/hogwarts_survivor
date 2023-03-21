using System.Collections.Generic;
using HogwartsSurvivor.Models;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Controllers
{
    public class EnemyController : BaseMonoController<EnemyView, EnemyData>
    {
        public override bool HasUpdate => true;
        
        private Transform target;

        private PoolController poolController;
        private TimeController timeController;
        
        public EnemyController(GamePlayerView playerView) 
        {
            target = playerView.transform;

            var entry = EntryPoint.GetInstance();
            poolController = entry.GetController<PoolController>();
            timeController = entry.GetController<TimeController>();
        }
        
        public override EnemyData AddView(EnemyView view)
        {
            var enemy = new EnemyData(view);
            enemy.OnDamaged += OnDamaged;
            enemy.OnKilled += OnKilled;

            TrySubscribePoolableEvents(enemy);
            modelsList.Add(enemy);
            
            return enemy;
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
            foreach (var enemy in modelsList)
            {
                var view = enemy.View;
                view.Agent.destination = target.transform.position;
                view.Animator.SetFloat("MoveSpeed", view.Agent.velocity.magnitude / view.MoveSpeed);
            }
        }

        public EnemyData GetRandom()
        {
            return modelsList[Random.Range(0, modelsList.Count)];
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
            modelsList.Add(enemy);
            enemy.Reset();
        }

        protected virtual void OnReturnedToPool(EnemyData enemy) { }

        protected virtual void OnDamaged(object sender, float damage)
        {
            var enemy = (EnemyData)sender;
            enemy.View.Animator.SetTrigger("OnDamaged");
            
            enemy.StopMoving();
            timeController.SetTimeout(enemy.DamagedDelay, () =>
            {
                if (enemy.IsAlive) enemy.ContinueMoving();
            });
        }

        protected virtual void OnKilled(object sender)
        {
            var enemy = (EnemyData) sender;
            enemy.View.Animator.SetTrigger("OnKilled");
            enemy.StopMoving();

            RemoveModel(enemy);
            
            timeController.SetTimeout(enemy.DeathDelay, () =>
            {
                if (!enemy.IsPoolable)
                {
                    Object.Destroy(enemy.View.gameObject);
                    return;
                }
                
                poolController.ReturnToPool(enemy.PoolableView); 
            });
        }
    }
}