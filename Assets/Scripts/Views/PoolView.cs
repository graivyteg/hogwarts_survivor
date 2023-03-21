using System;
using HogwartsSurvivor.Controllers;
using UnityEngine;

namespace HogwartsSurvivor.Views
{
    public class PoolView : MonoBehaviour
    {
        public string Key;
        public PoolableView Prefab;
        public int StartAmount;
        
        [Tooltip("[true] - Instantiates new objects if not enough [false] - Throws an exception")]
        public bool InstantiateIfNotEnough = true;

        private void Start()
        {
            var entry = EntryPoint.GetInstance();
            entry.SubscribeOnBaseControllersInit(() =>
            {
                entry.GetController<PoolController>().AddView(this);
            });
        }
    }
}