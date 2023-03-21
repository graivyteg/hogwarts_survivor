using System.Collections.Generic;
using HogwartsSurvivor.Models.Spells;
using HogwartsSurvivor.SO;
using OLS_HyperCasual;

namespace HogwartsSurvivor.Controllers
{
    public class SpellController : BaseController
    {
        private readonly List<SpellSO> spellDataCollection;

        private const string SpellCollectionPath = "Spell Collection";
        
        public SpellController()
        {
            var resourceController = BaseEntryPoint.Get<ResourcesController>();
            spellDataCollection = resourceController
                .GetResource<SpellCollectionSO>(SpellCollectionPath).GetSpellsData();
        }

        public ISpell GetSpell(string spellKey)
        {
            var spellSO = spellDataCollection.Find(spell => spell.Key == spellKey);
            return spellSO.GetSpell();
        }
    }
}