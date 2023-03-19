using Game.Core;
using UnityEngine;

namespace Game
{
    public class FollowingCamera : BaseMonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _followSpeed = 10;

        private Vector3 _offset;
        
        protected override void OnInit()
        {
            base.OnInit();
            _offset = transform.position - _target.position;
        }

        protected override void OnUpdate(float dt)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                _target.position + _offset,
                _followSpeed * dt);
        }
    }
}