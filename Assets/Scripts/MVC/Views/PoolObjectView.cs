using System;
using UnityEngine;

namespace Game.Views
{
    public class PoolObjectView : MonoBehaviour
    {
        public string Key { get; private set; }

        public event Action<PoolObjectView> OnTakenFromPool;
        public event Action<PoolObjectView> OnReturnedToPool;

        public void Init(string key)
        {
            Key = key;
        }

        public void TakenFromPool()
        {
            OnTakenFromPool?.Invoke(this);
        }

        public void ReturnedToPool()
        {
            OnReturnedToPool?.Invoke(this);
        }
    }
}