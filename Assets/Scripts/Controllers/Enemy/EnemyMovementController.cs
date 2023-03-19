using System.Collections.Generic;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Controllers.Enemy
{
    public class EnemyMovementController : BaseController
    {
        public override bool HasUpdate => true;

        private List<EnemyMovementView> views;
        private Transform target;
        
        private readonly int moveSpeedHash = Animator.StringToHash("MoveSpeed");

        public EnemyMovementController(GamePlayerView playerView)
        {
            views = new List<EnemyMovementView>();
            target = playerView.transform;
        }
        
        public void AddView(EnemyMovementView view)
        {
            views.Add(view);
        }

        public override void Update(float dt)
        {
            foreach (var view in views)
            {
                view.Agent.speed = view.MoveSpeed;
                view.Agent.angularSpeed = view.RotationSpeed;
                view.Agent.destination = target.transform.position;
                UpdateAnimations(view);
            }
        }

        private void UpdateAnimations(EnemyMovementView view)
        {
            view.Animator.SetFloat(moveSpeedHash, view.Agent.velocity.magnitude / view.MoveSpeed);
        }
    }
}