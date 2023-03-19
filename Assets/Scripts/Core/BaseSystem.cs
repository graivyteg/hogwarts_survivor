using UnityEngine;

namespace Game.Core
{
    public abstract class BaseSystem : BaseMonoBehaviour
    {
        public void Dispose() => OnDispose();

        private void OnEnable() { }

        private void OnDisable() { Dispose(); }
    }
}