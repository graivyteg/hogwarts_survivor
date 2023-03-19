using HogwartsSurvivor.Commands.Base;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;

namespace HogwartsSurvivor.Models
{
    public class DamageableModel<T> : BaseModel<T> where T : DamageableView
    {
        private float health;
        private float maxHealth;

        private DamageCommand damageCommand;
        private KillCommand killCommand;
        
        public DamageableModel(T view) : base(view)
        {
            health = view.MaxHealth;
            maxHealth = view.MaxHealth;
        }
    }
}