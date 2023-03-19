using System.Collections.Generic;
using HogwartsSurvivor.Enums;
using HogwartsSurvivor.Models;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;

namespace HogwartsSurvivor.Controllers
{
    public abstract class AbstractDamageableController : BaseController
    {
        protected List<DamageableData> damageables;
        
        public void AddView(DamageableView view)
        {
            var data = new DamageableData(view);
            data.OnDamaged += OnDamaged;
            data.OnDied += OnDied;
            damageables.Add(data);
        }

        protected abstract void OnDamaged(DamageableData data, float damaged);

        protected abstract void OnDied(DamageableData data);
    }
}