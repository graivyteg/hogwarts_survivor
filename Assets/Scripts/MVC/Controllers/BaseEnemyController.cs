using System.Collections.Generic;
using Game.Views;
using OLS_HyperCasual;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Controllers
{
    public class BaseEnemyController : BaseController
    {
        public override bool HasUpdate => true;

        private readonly List<BaseEnemyView> _views;
        private readonly PlayerView _player;
        
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");

        public BaseEnemyController(PlayerView playerView)
        {
            _player = playerView;
            _views = new List<BaseEnemyView>();
        }
        
        public override void Update(float dt)
        {
            float distance;
            foreach (var view in _views)
            {
                view.Agent.speed = view.MoveSpeed;
                view.Agent.stoppingDistance = view.TargetDistanceToPlayer;
                view.Agent.destination = _player.transform.position;
                UpdateAnimation(view);
            }
        }

        public virtual void AddView(BaseEnemyView view)
        {
            _views.Add(view);
        }

        protected virtual void UpdateAnimation(BaseEnemyView view)
        {
            float speed = view.Agent.velocity.magnitude / view.MoveSpeed;
            view.Animator.SetFloat(MoveSpeed, speed);
        }
    }
}