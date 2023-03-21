using System.Collections.Generic;
using HogwartsSurvivor.Models.Spells;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;

namespace HogwartsSurvivor.Models
{
    public class SpellCasterData : BaseModel<SpellCasterView>
    {
        private List<ISpell> spells;

        public SpellCasterData(SpellCasterView view) : base(view)
        {
            spells = new List<ISpell>();
        }

        public void SetSpells(List<ISpell> spellList)
        {
            spells = new List<ISpell>(spellList);
        }

        public void Update(float dt)
        {
            foreach (var spell in spells)
            {
                spell.Update(dt);
            }
        }
    }
}