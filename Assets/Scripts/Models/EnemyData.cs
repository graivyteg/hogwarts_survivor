using System;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;
using UnityEngine.AI;

namespace HogwartsSurvivor.Models
{
    public class EnemyData : DamageableData<EnemyView>
    {
        public bool IsPoolable => PoolableView != null;
        public readonly PoolableView PoolableView;
        
        public readonly float DeathDelay;
        public readonly float DamagedDelay;

        private float moveSpeed;
        private float rotationSpeed;

        private NavMeshAgent agent;

        public EnemyData(EnemyView view) : base(view)
        {
            PoolableView = view.PoolableView != null ? view.PoolableView : null;
            agent = view.Agent;
            
            moveSpeed = view.MoveSpeed;
            rotationSpeed = view.RotationSpeed;
            
            DeathDelay = view.DeathDelay;
            DamagedDelay = view.DamagedDelay;
        }

        public void StopMoving()
        {
            agent.speed = 0;
            agent.angularSpeed = 0;
        }

        public void ContinueMoving()
        {
            agent.speed = moveSpeed;
            agent.angularSpeed = rotationSpeed;
        }

        public void Reset()
        {
            RestoreHealth();
            ContinueMoving();
            
            View.Animator.Rebind();
            View.Animator.Update(0f);
        }
    }
}