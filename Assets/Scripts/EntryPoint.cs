using HogwartsSurvivor.Controllers;
using HogwartsSurvivor.Utils;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor
{
    public class EntryPoint : BaseEntryPoint
    {
        private static EntryPoint newInstance;
        
        public GamePlayerView MonoPlayerView { get; set; }
        public FollowingCameraView MonoCameraView { get; set; }
        public GameJoystick Joystick { get; set; }

        private new void Awake()
        {
            instance = this;
            newInstance = this;
        }

        public static EntryPoint GetNewInstance()
        {
            return newInstance;
        }

        protected override bool IsAllInited()
        {
            return MonoPlayerView != null && MonoCameraView != null && Joystick != null;
        }

        protected override void InitControllers()
        {
            AddController(new SaveController());
            AddController(new ResourcesController());
            AddController(new TimeController());
            AddController(new SpellController());
            AddController(new SpellCasterController());
            AddController(new GamePlayerController(MonoPlayerView, Joystick));
            AddController(new FollowingCameraController(MonoCameraView, MonoPlayerView));
            AddController(new PoolController());
            AddController(new SpawnerController());
            AddController(new EnemyController(MonoPlayerView));
            AddController(new HealthBarController(MonoCameraView));
            AddController(new TestController());
            base.InitControllers();
        }
    }
}