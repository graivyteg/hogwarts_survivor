using HogwartsSurvivor.Controllers;
using HogwartsSurvivor.Controllers.Enemy;
using HogwartsSurvivor.Utils;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor
{
    public class EntryPoint : BaseEntryPoint
    {
        private static EntryPoint instance;
        
        public GamePlayerView MonoPlayerView { get; set; }
        public FollowingCameraView MonoCameraView { get; set; }
        public GameJoystick Joystick { get; set; }

        private new void Awake()
        {
            instance = this;
        }

        public new static EntryPoint GetInstance()
        {
            return instance;
        }
        
        protected override bool IsAllInited()
        {
            return MonoPlayerView != null && MonoCameraView != null && Joystick != null;
        }

        protected override void InitControllers()
        {
            AddController(new GamePlayerController(MonoPlayerView, Joystick));
            AddController(new FollowingCameraController(MonoCameraView, MonoPlayerView));
            AddController(new PoolController());
            AddController(new SpawnerController());
            AddController(new EnemyMovementController(MonoPlayerView));
            AddController(new TestController());
            base.InitControllers();
        }
    }
}