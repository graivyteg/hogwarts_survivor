using System.Collections.Generic;
using HogwartsSurvivor.Controllers;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Views
{
    public class SpellCasterView : MonoBehaviour
    {
        [field: SerializeField] public List<string> SpellKeys { get; private set; }

        public void Start()
        {
            var entry = BaseEntryPoint.GetInstance();
            entry.SubscribeOnBaseControllersInit(() =>
            {
                entry.GetController<SpellCasterController>().AddView(this);
            });
        }
    }
}