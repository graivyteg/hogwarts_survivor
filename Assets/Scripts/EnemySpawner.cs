using Game.Core;
using Game.Pool;
using NaughtyAttributes;
using UnityEngine;

namespace Game
{
    public class EnemySpawner : BaseMonoBehaviour
    {
        [SerializeField] private bool _usePool = true;
        [ShowIf(nameof(_usePool))]
        [SerializeField] private string _poolKey;
        [HideIf(nameof(_usePool))] 
        [SerializeField] private GameObject _prefab;

        [SerializeField] private float _delay = 3;
        private float _timer;
        
        protected override void OnInit()
        {
            base.OnInit();
            _timer = 0;
        }

        protected override void OnUpdate(float dt)
        {
            _timer += dt;
            if (_timer >= _delay)
            {
                _timer = 0;
                Spawn();
            }
        }

        private void Spawn()
        {
            GameObject obj;
            if (_usePool)
            {
                obj = BaseScene.GetInstance().GetSystem<PoolSystem>().Get(_poolKey).gameObject;
            }
            else
            {
                obj = Instantiate(_prefab);
            }

            obj.transform.position = transform.position;
        }
    }
}