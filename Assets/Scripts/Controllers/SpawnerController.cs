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

        private List<SpawnerData> spawners;
        private PoolController poolController;
        
        public SpawnerController()
        {
            spawners = new List<SpawnerData>();
            poolController = EntryPoint.GetInstance().GetController<PoolController>();
        }

        public void AddView(SpawnerView view)
        {
            var data = new SpawnerData(view);
            data.OnCooldown += Spawn;
            spawners.Add(data);
        }

        public override void Update(float dt)
        {
            foreach (var spawner in spawners)
            {
                spawner.RemoveCooldown(dt);
            }
        }

        public void Spawn(Vector3 position, string key)
        {
            var obj = poolController.Get(key);
            obj.transform.position = position;
        } 
    }
}