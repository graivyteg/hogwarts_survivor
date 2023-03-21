using HogwartsSurvivor.Models;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Views
{
    public class GamePlayerView : DamageableView
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 6;
        [SerializeField] private float rotationSpeed = 6;
        
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }

        [Header("Additional")] 
        [SerializeField] private float damagedDelay = 0.3f;

        public float MoveSpeed => moveSpeed;
        public float RotationSpeed => rotationSpeed;

        public float DamagedDelay => damagedDelay;
        
        public GamePlayerData Data { get; private set; }

        private void Start()
        {
            EntryPoint.GetNewInstance().MonoPlayerView = this;
        }

        public void InitData(GamePlayerData data)
        {
            if (Data != null)
            {
                Debug.LogError("[PlayerView.InitData]: Data already inited");
                return;
            }

            Data = data;
        }
    }
}