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
            entry = EntryPoint.GetInstance();
        }
        
        public override void Update(float dt)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var obj = entry.GetController<PoolController>().Get("enemy");
                obj.transform.position = Vector3.up;
            }
        }
    }
}