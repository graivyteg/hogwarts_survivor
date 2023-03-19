using NaughtyAttributes;
using UnityEngine;

namespace Game.Weapon
{
    [CreateAssetMenu(menuName = "Spells/Target Spell", fileName = "Target Spell", order = 51)]
    public class TargetSpellData : BaseSpellData
    {
        public string PoolKey;
        
        [MinValue(0.1f)]
        public float MaxDistance = 5;
        
        public override ISpell GetSpell(SpellCaster caster)
        {
            return new TargetSpell(caster, this);
        }
    }
}