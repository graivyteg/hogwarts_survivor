using UnityEngine;

namespace HogwartsSurvivor.Views
{
    public class FollowingCameraView : MonoBehaviour
    {
        [SerializeField] private float cameraSpeed;

        public float CameraSpeed => cameraSpeed;

        private void Start()
        {
            EntryPoint.GetNewInstance().MonoCameraView = this;
        }
    }
}