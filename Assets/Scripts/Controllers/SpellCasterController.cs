using System.Collections.Generic;
using HogwartsSurvivor.Models;
using HogwartsSurvivor.Models.Spells;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;

namespace HogwartsSurvivor.Controllers
{
    public class SpellCasterController : BaseMonoController<SpellCasterView, SpellCasterData>
    {
        public override bool HasUpdate => true;

        private SpellController spellController;
        
        public SpellCasterController()
        {
            spellController = BaseEntryPoint.Get<SpellController>();
        }
        
        public override SpellCasterData AddView(SpellCasterView view)
        {
            var data = new SpellCasterData(view);
            var spellKeys = view.SpellKeys;
            List<ISpell> spells = new List<ISpell>();
            
            foreach (var key in spellKeys)
            {
                spells.Add(spellController.GetSpell(key));
            }
            
            data.SetSpells(spells);
            
            modelsList.Add(data);
            return data;
        }

        public override void Update(float dt)
        {
            foreach (var caster in modelsList)
            {
                caster.Update(dt);
            }
        }
    }
}