using HogwartsSurvivor.Models.Spells;
using UnityEngine;

namespace HogwartsSurvivor.SO
{
    public abstract class SpellSO : ScriptableObject
    {
        public string Key;
        public Sprite Icon;
        public float Cooldown;

        public abstract ISpell GetSpell();
    }
}