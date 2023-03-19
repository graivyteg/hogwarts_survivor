using Game.Controllers;
using Game.Models;
using NaughtyAttributes;
using OLS_HyperCasual;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Views
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class BaseEnemyView : PoolObjectView
    {
        [SerializeField] private float maxHealth;
        [MinValue(2f)] public float TargetDistanceToPlayer = 1f;
        public float MoveSpeed = 3f;
        public NavMeshAgent Agent { get; private set; }
        public Animator Animator { get; private set; }

        public DamageableData Data;
        
        private void Start()
        {
            Agent = GetComponent<NavMeshAgent>();
            Animator = GetComponent<Animator>();

            var entry = BaseEntryPoint.GetInstance();
            entry.SubscribeOnBaseControllersInit(() =>
            {
                var controller = entry.GetController<BaseEnemyController>();
                controller.AddView(this);
            });
        }

        public void InitData()
        {
            Data = new DamageableData(maxHealth);
        }

        public void DealDamage(float damage)
        {
            
        }

        public void Kill()
        {
            
        }
    }
}