using HogwartsSurvivor.Models;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Views
{
    public class GamePlayerView : DamageableView
    {
        [SerializeField] private float moveSpeed = 6;
        [SerializeField] private float rotationSpeed = 6;
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody rb;

        public float MoveSpeed => moveSpeed;
        public float RotationSpeed => rotationSpeed;
        public Rigidbody Rigidbody => rb;
        public Animator Animator => animator;
        public GamePlayerData Data { get; private set; }

        private void Start()
        {
            EntryPoint.GetInstance().MonoPlayerView = this;
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