using HogwartsSurvivor.SO;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Controllers
{
    public class TestController : BaseController
    {
        public override bool HasUpdate => true;

        private EntryPoint entry;
        
        public TestController()
        {
            entry = EntryPoint.GetNewInstance();
        }
        
        public override void Update(float dt)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var enemy = entry.GetController<EnemyController>().GetRandom();
                entry.GetController<EnemyController>().DealDamage(enemy, 30);
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                entry.GetController<GamePlayerController>().DealDamage(30);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                var resourceController = entry.GetController<ResourcesController>();
                var resource = resourceController.GetResource<SpellSO>("SpellSO");
            }
        }
    }
}