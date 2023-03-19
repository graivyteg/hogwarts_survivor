using Game.Core;
using UnityEngine;

namespace Game.Enemy
{
    [RequireComponent(typeof(BasicEnemyMovement))]
    [RequireComponent(typeof(Animator))]
    public class BasicEnemyAnimator : BaseMonoBehaviour
    {
        private BasicEnemyMovement _movement;
        private Animator _animator;
        
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        
        protected override void OnInit()
        {
            _animator = GetComponent<Animator>();
            _movement = GetComponent<BasicEnemyMovement>();
        }

        protected override void OnUpdate(float dt)
        {
            _animator.SetFloat(MoveSpeed, _movement.MoveSpeedNormalized);
        }
    }
}