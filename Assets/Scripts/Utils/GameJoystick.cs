using UnityEngine;
using UnityEngine.EventSystems;

namespace HogwartsSurvivor.Utils
{
    public class GameJoystick : Joystick
    {
        protected override void Start()
        {
            base.Start();
            EntryPoint.GetInstance().Joystick = this;
            background.gameObject.SetActive(false);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            background.gameObject.SetActive(false);
            base.OnPointerUp(eventData);
        }
    }
}