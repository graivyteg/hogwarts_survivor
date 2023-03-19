using System;
using HogwartsSurvivor.Controllers.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace HogwartsSurvivor.Views
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class EnemyMovementView : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 3;
        [SerializeField] private float rotationSpeed = 120;

        private NavMeshAgent agent;
        private Animator animator;
        
        
        public NavMeshAgent Agent => agent;
        public Animator Animator => animator;
        public float MoveSpeed => moveSpeed;
        public float RotationSpeed => rotationSpeed;
        
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            
            var entry = EntryPoint.GetInstance();
            entry.SubscribeOnBaseControllersInit(() =>
            {
                entry.GetController<EnemyMovementController>().AddView(this);
            });
        }
    }
}