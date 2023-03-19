using UnityEngine;

namespace Game.Pool
{
    [System.Serializable]
    public class PoolData
    {
        public string Key;
        public PoolMonoBehaviour Prefab;
        public int StartAmount;
    }
}