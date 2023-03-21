using UnityEngine;

namespace HogwartsSurvivor.Core
{
    public abstract class BaseView<T> : MonoBehaviour
    {
        public abstract T InitializeData();
    }
}