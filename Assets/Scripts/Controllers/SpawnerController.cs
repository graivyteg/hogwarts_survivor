using System.Collections.Generic;
using HogwartsSurvivor.Models;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Controllers
{
    public class SpawnerController : BaseController
    {
        public override bool HasUpdate => true;

        private List<SpawnerModel> spawnerModels;
        private PoolController poolController;
        
        public SpawnerController()
        {
            spawnerModels = new List<SpawnerModel>();
            poolController = BaseEntryPoint.GetInstance().GetController<PoolController>();
        }

        public void AddView(SpawnerView view)
        {
            var data = view.InitializeModel();
            data.OnCooldown += Spawn;
            spawnerModels.Add(data);
        }

        public override void Update(float dt)
        {
            foreach (var spawner in spawnerModels)
            {
                spawner.UpdateCooldown(dt);
            }
        }

        public void Spawn(Vector3 position, string key)
        {
            var obj = poolController.Get(key);
            obj.transform.position = position;
        } 
    }
}