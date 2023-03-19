using HogwartsSurvivor.Models;

namespace HogwartsSurvivor.Controllers
{
    public class EnemyDamageableController : AbstractDamageableController
    {
        protected override void OnDamaged(DamageableData data, float damaged)
        {
            
        }

        protected override void OnDied(DamageableData data)
        {
        }
    }
}