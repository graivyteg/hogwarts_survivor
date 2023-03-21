using System;
using HogwartsSurvivor.Controllers;
using OLS_HyperCasual;
using UnityEngine;
using UnityEngine.UI;

namespace HogwartsSurvivor.Views
{
    public class HealthBarView : MonoBehaviour
    {
        [field: SerializeField] public DamageableView Target { get; private set; }
        [SerializeField] private Slider slider;

        private const float lerpSpeed = 0.2f;

        private void Start()
        {
            var entry = BaseEntryPoint.GetInstance();
            entry.SubscribeOnBaseControllersInit(() =>
            {
                entry.GetController<HealthBarController>().AddView(this);
            });
        }

        public void DisplayHealth(float value)
        {
            slider.value = Mathf.Lerp(slider.value, value, lerpSpeed);
        }
    }
}