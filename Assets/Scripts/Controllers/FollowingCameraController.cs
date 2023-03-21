using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Controllers
{
    public class FollowingCameraController : BaseController
    {
        public override bool HasLateUpdate => true;

        private FollowingCameraView cameraView;
        private Transform cameraTransform, playerTransform;
        private Vector3 cameraOffset;

        public FollowingCameraController(FollowingCameraView cameraView, GamePlayerView playerView)
        {
            this.cameraView = cameraView;
            cameraTransform = cameraView.transform;
            playerTransform = playerView.transform;
            cameraOffset = playerTransform.position - cameraTransform.position;
        }

        public override void LateUpdate(float dt)
        {
            var cameraTargetPoint = playerTransform.position - cameraOffset;
            if (Vector3.Distance(cameraTransform.position, cameraTargetPoint) > 0.01f)
            {
                cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, cameraTargetPoint, cameraView.CameraSpeed * dt);
            }
        }
    }
}