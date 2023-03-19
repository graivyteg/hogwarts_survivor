using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Models
{
    public class GamePlayerModel
    {
        public Vector3 PlayerPosition => CachedTransform.position;
        public bool IsCarryingItem => storageData.StorageCount > 0;
        public Transform CachedTransform { get; private set; }
        public bool IsMoving { get; set; }

        private StorageData storageData { get; }

        public PlayerData(PlayerView view):base(view)
        {
            this.View = view;
            storageData = new StorageData("PlayerData", 100);
            CachedTransform = view.transform;
            view.InitData(this);
        }

        public void PickupItem(StorageItem item)
        {
            item.UpdateStorage(storageData);
            View.PickupItem(item.CachedTransform, storageData.StorageCount * 0.11f);
        }

        public T GetItemFromStorage<T>() where T : StorageItem
        {
            var item = storageData.storageItems[^1] as T;
            item.UpdateStorage(null);
            return item;
        }
    }
}