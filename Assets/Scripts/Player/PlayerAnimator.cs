using Game.Core;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : BaseMonoBehaviour
    {
        private PlayerMovement _movement;
        private Animator _animator;
        
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        
        protected override void OnInit()
        {
            base.OnInit();
            _animator = GetComponent<Animator>();
            _movement = GetComponent<PlayerMovement>();
        }

        protected override void OnUpdate(float dt)
        {
            _animator.SetFloat(MoveSpeed, _movement.MoveSpeedNormalized);
        }
    }
}