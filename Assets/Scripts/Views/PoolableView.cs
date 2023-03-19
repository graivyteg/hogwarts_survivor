using System;
using HogwartsSurvivor.Models;
using NaughtyAttributes;
using UnityEngine;

namespace HogwartsSurvivor.Views
{
    public class PoolableView : MonoBehaviour
    {
        private PoolableData _data;
        
        public void InitData(PoolableData data)
        {
            if (_data != null)
            {
                throw new InvalidOperationException("Data is already inited");
            }

            _data = data;
        }
        
        public PoolableData GetData() => _data;
    }
}