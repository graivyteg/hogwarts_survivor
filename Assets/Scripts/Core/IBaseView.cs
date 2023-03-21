using UnityEngine;

namespace HogwartsSurvivor.Core
{
    public interface IBaseView<T>
    {
        public T InitializeModel();
        public T GetModel();
    }
}