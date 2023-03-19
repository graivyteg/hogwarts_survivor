using Game.Core;
using UnityEngine;

namespace Game.Weapon
{
    public abstract class BaseSpellData : ScriptableObject
    {
        public float Cooldown;

        public abstract ISpell GetSpell(SpellCaster caster);
    }
}