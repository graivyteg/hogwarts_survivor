using System;
using System.Collections.Generic;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HogwartsSurvivor.Models
{
    public class PoolData : BaseModel<PoolView>
    {
        public readonly string Key;
        private PoolableView prefab;
        private readonly int startAmount;
        
        private Queue<PoolableView> availableObjects;
        private List<PoolableView> aliveObjects;

        public PoolData(PoolView view) : base(view)
        {
            Key = view.Key;
            prefab = view.Prefab;
            startAmount = view.StartAmount;
            availableObjects = new Queue<PoolableView>();
            
            Init();
        }

        public void Init()
        {
            for (var i = 0; i < startAmount; i++) Add();
        }

        public PoolableView Get()
        {
            if (availableObjects.Count == 0)
            {
                if(View.InstantiateIfNotEnough)
                    return Add(true);
                throw new ArgumentOutOfRangeException(nameof(availableObjects),
                    "Can't get an object because there are no available");
            }

            var obj = availableObjects.Dequeue();
            obj.gameObject.SetActive(true);
            
            return obj;
        }

        public PoolableView Add(bool isActive = false)
        {
            var obj = Object.Instantiate(prefab.gameObject, View.transform);
            obj.SetActive(isActive);
            
            var poolable = obj.GetComponent<PoolableView>();
            poolable.InitData(new PoolableData(Key));
            
            if (!isActive)
            {
                availableObjects.Enqueue(poolable);
            }
            
            return poolable;
        }

        public void Return(PoolableView poolable)
        {
            if (poolable.GetData().Key != Key)
            {
                throw new ArgumentException("Object you try to return isn't encountered in this pool");
            }
            if (poolable.transform.parent != View.transform)
            {
                poolable.transform.parent = View.transform;
            }
            poolable.gameObject.SetActive(false);
            availableObjects.Enqueue(poolable);
        }
    }
}