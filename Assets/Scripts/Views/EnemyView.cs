using System;
using HogwartsSurvivor.Controllers;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

namespace HogwartsSurvivor.Views
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class EnemyView : DamageableView
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 3;
        [SerializeField] private float rotationSpeed = 120;

        [Header("Additional")]
        [SerializeField] private float deathDelay = 3;
        [SerializeField] private float damagedDelay = 0.5f; 

        private NavMeshAgent agent;
        private Animator animator;
        private PoolableView poolableView;
        
        public NavMeshAgent Agent => agent;
        public Animator Animator => animator;
        public float MoveSpeed => moveSpeed;
        public float RotationSpeed => rotationSpeed;

        public float DeathDelay => deathDelay;
        public float DamagedDelay => damagedDelay;

        public PoolableView PoolableView => poolableView;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();

            TryGetComponent<PoolableView>(out poolableView);
            
            var entry = EntryPoint.GetInstance();
            entry.SubscribeOnBaseControllersInit(() =>
            {
                entry.GetController<EnemyController>().AddView(this);
            });
        }
    }
}