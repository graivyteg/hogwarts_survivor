using Game.Core;
using Game.Pool;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class BasicEnemyMovement : PoolMonoBehaviour
    {
        public float MoveSpeedNormalized => _agent.velocity.magnitude / _moveSpeed;
        
        [SerializeField] private float _moveSpeed = 3;
        [SerializeField] private float _rotationSpeed = 120;
        
        private static GameObject _player;
        private NavMeshAgent _agent;
        
        protected override void OnInit()
        {
            _agent = GetComponent<NavMeshAgent>();
            _player = BaseScene.GetInstance().GetPlayer();
            _agent.speed = _moveSpeed;
            _agent.angularSpeed = _rotationSpeed;
        }

        public override void OnTakenFromPool() => OnInit();

        protected override void OnUpdate(float dt)
        {
            if (_player == null) return;

            _agent.destination = _player.transform.position;
        }
    }
}