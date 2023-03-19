using System;
using Game.Core;
using UnityEngine;

namespace Game
{
    public abstract class ColliderEventPerformer<T> : MonoBehaviour where T : MonoBehaviour
    {
        public event Action<T> OnEnterTrigger;
        public event Action<T> OnExitTrigger;
        public event Action<T> OnStayTrigger; 

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<T>(out var component))
            {
                OnEnterTrigger?.Invoke(component);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<T>(out var component))
            {
                OnExitTrigger?.Invoke(component);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent<T>(out var component))
            {
                OnStayTrigger?.Invoke(component);
            }
        }
    }
}