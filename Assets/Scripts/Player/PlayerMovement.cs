using Game.Core;
using UnityEngine;

namespace Game
{
    public class PlayerMovement : BaseMonoBehaviour
    {
        public float MoveSpeedNormalized => _joystick.Direction.magnitude;
        
        [SerializeField] private float _moveSpeed = 5;
        [SerializeField] private float _rotationSpeed = 5;
        [SerializeField] private FloatingJoystick _joystick;

        private Rigidbody _rigidbody;
        private Vector3 _velocity;
        private Vector3 _direction;
        private Quaternion _rotDirection;

        protected override void OnInit()
        {
            Debug.Log("Movement Init");
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected override void OnFixedUpdate(float dt)
        {
            _direction.x = _joystick.Horizontal;
            _direction.z = _joystick.Vertical;

            _velocity = _direction * _moveSpeed;
            _velocity.y = _rigidbody.velocity.y;

            _rigidbody.velocity = _velocity;

            if (_direction == Vector3.zero) return;
            
            _rotDirection = Quaternion.LookRotation(_direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation, 
                _rotDirection, 
                _rotationSpeed * dt);
        }
    }
}