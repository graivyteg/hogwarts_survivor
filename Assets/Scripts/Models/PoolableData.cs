using System;

namespace HogwartsSurvivor.Models
{
    public class PoolableData
    {
        public readonly string Key;

        public PoolableData(string key)
        {
            Key = key;
        }
    }
}