using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace HogwartsSurvivor.SO
{
    [CreateAssetMenu(fileName = "Spell Collection", menuName = "SO/Spell Collection", order = 51)]
    public class SpellCollectionSO : ScriptableObject
    {
        [SerializeField] private bool loadAutomatically;

        [ShowIf(nameof(loadAutomatically))] 
        [SerializeField] private string folderPath;
        
        [DisableIf(nameof(loadAutomatically))]
        [SerializeField] private List<SpellSO> spells;

        private void OnValidate()
        {
            UpdateList();
        }
        
        [ShowIf(nameof(loadAutomatically))]
        [Button("Update")]
        private void UpdateList()
        {
            if (!loadAutomatically) return;

            spells = new List<SpellSO>();

            foreach (var spell in Resources.LoadAll<SpellSO>(folderPath))
            {
                spells.Add(spell);
            }
        }

        public List<SpellSO> GetSpellsData() => spells;

    }
}