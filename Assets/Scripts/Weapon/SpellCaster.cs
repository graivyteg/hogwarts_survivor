using Game.Core;
using UnityEngine;

namespace Game.Weapon
{
    public class SpellCaster : BaseMonoBehaviour
    {
        public Transform CastPoint;
        
        [SerializeField] private BaseSpellData _spellData;

        private ISpell _spell;
        
        protected override void OnInit()
        {
            _spell = _spellData.GetSpell(this);
        }

        protected override void OnUpdate(float dt)
        {
            _spell.Update(dt);
            Debug.Log(_spell.TryCast(this));
        }
    }
}