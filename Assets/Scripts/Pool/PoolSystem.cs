using System.Collections.Generic;
using Game.Core;
using UnityEngine;

namespace Game.Pool
{
    public class PoolSystem : BaseSystem
    {
        [SerializeField] private List<PoolData> _pools;

        private Dictionary<string, Queue<PoolMonoBehaviour>> _availableObjects;
        private Dictionary<string, Transform> _parents;

        protected override void OnInit()
        {
            _availableObjects = new Dictionary<string, Queue<PoolMonoBehaviour>>();
            _parents = new Dictionary<string, Transform>();
            
            foreach (var pool in _pools)
            {
                _availableObjects.Add(pool.Key, new Queue<PoolMonoBehaviour>());

                var parent = new GameObject("Pool " + pool.Key).transform;
                parent.parent = transform;
                parent.gameObject.SetActive(false);
                _parents[pool.Key] = parent;
                
                for (var i = 0; i < pool.StartAmount; i++)
                {
                    var obj = Instantiate(pool.Prefab.gameObject, parent);
                    obj.SetActive(false);
                    _availableObjects[pool.Key].Enqueue(obj.GetComponent<PoolMonoBehaviour>());
                }
                
                parent.gameObject.SetActive(true);
            }
        }

        public PoolMonoBehaviour Get(string key)
        {
            if (_availableObjects[key].Count > 0)
            {
                var obj = _availableObjects[key].Dequeue();
                obj.gameObject.SetActive(true);
                obj.OnTakenFromPool();
                return obj;
            }

            return Add(key);
        }

        private PoolMonoBehaviour Add(string key)
        {
            var poolData = _pools.Find(pool => pool.Key == key);
            return Instantiate(poolData.Prefab.gameObject, _parents[key])
                .GetComponent<PoolMonoBehaviour>();
        }
    }
}