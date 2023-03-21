using System;
using HogwartsSurvivor.Controllers;
using HogwartsSurvivor.Core;
using HogwartsSurvivor.Models;
using UnityEngine;

namespace HogwartsSurvivor.Views
{
    public class SpawnerView : MonoBehaviour, IBaseView<SpawnerModel>
    {
        [SerializeField] private string poolKey;
        [SerializeField] private float cooldown;

        public string PoolKey => poolKey;
        public float Cooldown => cooldown;

        private SpawnerModel model;

        private void Start()
        {
            var entry = EntryPoint.GetInstance();
            entry.SubscribeOnBaseControllersInit(() =>
            {
                entry.GetController<SpawnerController>().AddView(this);
            });
        }

        public SpawnerModel InitializeModel()
        {
            model = new SpawnerModel(transform, poolKey, cooldown);
            return model;
        }

        public SpawnerModel GetModel() => model;
    }
}