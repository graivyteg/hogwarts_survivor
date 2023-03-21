using HogwartsSurvivor.Models;
using HogwartsSurvivor.Utils;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HogwartsSurvivor.Controllers
{
    public class GamePlayerController : BaseController
    {
        public override bool HasFixedUpdate => true;
        public GamePlayerData PlayerData { get; private set; }
        
        private GameJoystick joystick;
        private Animator playerAnimator;
        private Rigidbody playerRigidbody;

        private TimeController timeController;

        public GamePlayerController(GamePlayerView playerView, GameJoystick joystick)
        {
            timeController = EntryPoint.GetInstance().GetController<TimeController>();
            
            this.joystick = joystick;
            
            playerAnimator = playerView.Animator;
            playerRigidbody = playerView.Rigidbody;
            
            PlayerData = new GamePlayerData(playerView);
            PlayerData.OnDamaged += OnDamaged;
            PlayerData.OnKilled += OnKilled;
        }

        public override void FixedUpdate(float dt)
        {
            var dir = joystick.Direction;

            var moveDirection = new Vector3(dir.x, 0, dir.y);
            var gravity = new Vector3(0, playerRigidbody.velocity.y, 0);
            
            playerRigidbody.velocity = moveDirection * PlayerData.MoveSpeed + gravity;

            if (moveDirection != Vector3.zero)
            {
                var rotDirection = Quaternion.LookRotation(moveDirection);
                playerRigidbody.rotation = Quaternion.Slerp(playerRigidbody.rotation, rotDirection, PlayerData.RotationSpeed * dt);
            }

            playerAnimator.SetFloat("MoveSpeed", moveDirection.magnitude);
        }

        public void DealDamage(float damage)
        {
            PlayerData.ApplyDamage(damage);
        }

        public void Kill()
        {
            PlayerData.Kill();
        }
        
        private void OnDamaged(object sender, float damage)
        {
            playerAnimator.SetTrigger("OnDamaged");
            
            PlayerData.StopMoving();
            timeController.SetTimeout(PlayerData.DamagedDelay, () =>
            {
                PlayerData.ContinueMoving();
            });
        }
        
        private void OnKilled(object sender)
        {
            playerAnimator.SetTrigger("OnKilled");
            PlayerData.StopMoving();
        }
    }
}