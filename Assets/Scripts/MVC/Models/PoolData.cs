using System.Collections.Generic;
using Game.Views;
using OLS_HyperCasual;
using UnityEngine;

namespace Game.Models
{
    public class PoolData
    {
        private readonly Queue<PoolObjectView> _availableObjects;
        public int AvailableObjects => _availableObjects.Count;

        public PoolData()
        {
            _availableObjects = new Queue<PoolObjectView>();
        }

        public bool TryGetAvailable(out PoolObjectView obj)
        {
            obj = null;
            if (AvailableObjects == 0) return false;
            
            obj = _availableObjects.Dequeue();
            obj.gameObject.SetActive(true);
            return true;
        }

        public void ReturnToPool(PoolObjectView obj)
        {
            if (obj.gameObject.activeInHierarchy)
            {
                obj.gameObject.SetActive(false);
            }
            _availableObjects.Enqueue(obj);
        }
    }
}