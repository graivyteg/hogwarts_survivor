using HogwartsSurvivor.Models;
using HogwartsSurvivor.Utils;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Controllers
{
    public class GamePlayerController : BaseController
    {
        public override bool HasFixedUpdate => true;

        public GamePlayerData PlayerData { get; private set; }

        private GamePlayerView playerView;
        private GameJoystick joystick;
        private Transform playerTransform;
        private Animator playerAnimator;
        private Rigidbody playerRigidbody;
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");

        public GamePlayerController(GamePlayerView playerView, GameJoystick joystick)
        {
            this.playerView = playerView;
            PlayerData = new GamePlayerData(playerView);
            this.joystick = joystick;
            playerTransform = playerView.transform;
            playerRigidbody = playerView.Rigidbody;
            playerAnimator = playerView.Animator;

            PlayerData.OnDamaged += OnDamaged;
            PlayerData.OnKilled += OnKilled;
        }

        public override void FixedUpdate(float dt)
        {
            var dir = joystick.Direction;

            var moveDirection = new Vector3(dir.x, 0, dir.y);
            var gravity = new Vector3(0, playerRigidbody.velocity.y, 0);
            
            playerRigidbody.velocity = moveDirection * playerView.MoveSpeed + gravity;

            if (moveDirection != Vector3.zero)
            {
                var rotDirection = Quaternion.LookRotation(moveDirection);
                playerRigidbody.rotation = Quaternion.Slerp(playerRigidbody.rotation, rotDirection, playerView.RotationSpeed * dt);
            }

            UpdateAnimation(moveDirection.magnitude);
            PlayerData.IsMoving = true;
        }

        private void UpdateAnimation(float normalizedSpeed)
        {
            playerAnimator.SetFloat(MoveSpeed, normalizedSpeed);
        }

        public void DealDamage(float damage)
        {
            PlayerData.ApplyDamage(damage);
        }

        public void Kill(GamePlayerData model)
        {
            PlayerData.Kill();
        }
        
        private void OnDamaged(object sender, float damage)
        {
            Debug.Log("Ay suka bolno");
        }
        
        private void OnKilled(object sender)
        {
            Debug.Log("Vse pizdec");
        }
    }
}