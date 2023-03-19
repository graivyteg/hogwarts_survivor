using System;
using System.Collections.Generic;
using HogwartsSurvivor.Models;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;

namespace HogwartsSurvivor.Controllers
{
    public class PoolController : BaseController
    {
        private Dictionary<string, PoolData> pools;

        public event Action<PoolableView> OnTakenFromPool;
        public event Action<PoolableView> OnReturnedToPool; 

        public PoolController()
        {
            pools = new Dictionary<string, PoolData>();
        }
        
        public void AddView(PoolView view)
        {
            if (pools.ContainsKey(view.Key))
            {
                throw new ArgumentException(
                    $"Such key {view.Key} is already inited on {pools[view.Key].View.gameObject.name}");
            }

            pools[view.Key] = new PoolData(view);
        }

        public PoolableView Get(string key)
        {
            var view = pools[key].Get();
            OnTakenFromPool?.Invoke(view);
            return view;
        }

        public void ReturnToPool(PoolableView view)
        {
            pools[view.GetData().Key].Return(view);
            OnReturnedToPool?.Invoke(view);   
        }
    }
}