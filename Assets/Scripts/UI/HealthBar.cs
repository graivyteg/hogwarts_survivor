using Game.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    [RequireComponent(typeof(Slider))]
    public class HealthBar : BaseMonoBehaviour
    {
        private Slider _bar;

        protected override void OnInit()
        {
            _bar = GetComponent<Slider>();
        }
    }
}