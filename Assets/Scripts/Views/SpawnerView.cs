using System;
using HogwartsSurvivor.Controllers;
using UnityEngine;

namespace HogwartsSurvivor.Views
{
    public class SpawnerView : MonoBehaviour
    {
        [SerializeField] private string poolKey;
        [SerializeField] private float cooldown;

        public string PoolKey => poolKey;
        public float Cooldown => cooldown;

        private void Start()
        {
            var entry = EntryPoint.GetInstance();
            entry.SubscribeOnBaseControllersInit(() =>
            {
                entry.GetController<SpawnerController>().AddView(this);
            });
        }
    }
}