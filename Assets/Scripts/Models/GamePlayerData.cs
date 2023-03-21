using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Models
{
    public class GamePlayerData : DamageableData<GamePlayerView>
    {
        public Vector3 PlayerPosition => CachedTransform.position;
        public bool IsCarryingItem => storageData.StorageCount > 0;
        public Transform CachedTransform { get; private set; }
        
        public float MoveSpeed { get; private set; }
        public float RotationSpeed { get; private set; }

        private float maxSpeed;
        private float maxRotationSpeed;

        public readonly float DamagedDelay;

        private StorageData storageData { get; }

        public GamePlayerData(GamePlayerView view):base(view)
        {
            this.View = view;
            storageData = new StorageData("PlayerData", 100);
            CachedTransform = view.transform;
            view.InitData(this);

            MoveSpeed = view.MoveSpeed;
            RotationSpeed = view.RotationSpeed;
            maxSpeed = view.MoveSpeed;
            maxRotationSpeed = view.RotationSpeed;
            DamagedDelay = view.DamagedDelay;
        }
        
        public T GetItemFromStorage<T>() where T : StorageItem
        {
            var item = storageData.storageItems[^1] as T;
            item.UpdateStorage(null);
            return item;
        }

        public void StopMoving()
        {
            MoveSpeed = 0;
            RotationSpeed = 0;
        }

        public void ContinueMoving()
        {
            MoveSpeed = maxSpeed;
            RotationSpeed = maxRotationSpeed;
        }
    }
}