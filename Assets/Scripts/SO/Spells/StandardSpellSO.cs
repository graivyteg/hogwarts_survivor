using HogwartsSurvivor.SO;
using UnityEngine;

namespace HogwartsSurvivor.Models.Spells
{
    [CreateAssetMenu(menuName="SO/Spells/Standard Spell",fileName="Standard Spell", order=51)]
    public class StandardSpellSO : SpellSO
    {
        [Header("Projectile")]
        public float Damage;
        public float Speed;

        public override ISpell GetSpell()
        {
            return new StandardSpell(this);
        }
    }
}