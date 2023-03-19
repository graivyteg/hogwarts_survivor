using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    public class BaseScene : MonoBehaviour
    {
        private static BaseScene _instance;

        private static List<BaseMonoBehaviour> _objects = new();
        private static Dictionary<BaseMonoBehaviour, bool> _changes = new();

        [SerializeField] private List<BaseSystem> _systems;
        [SerializeField] private GameObject _player;

        public event Action OnSceneActivated;
        public event Action OnSceneDeactivated;

        public bool IsActivated;

        private void Awake()
        {
            if (_instance == null) _instance = this;
            else if(_instance != this) Destroy(gameObject);

            IsActivated = false;
        }
        
        public static BaseScene GetInstance() => _instance;
        public GameObject GetPlayer() => _player;
        
        protected virtual void Start()
        {
            foreach (var system in _systems)
            {
                system.Init();
            }
            ApplyMonoChanges();
            foreach (var obj in _objects)
            {
                obj.Init();
            }
            GameEntry.GetInstance().ApplyScene(this);
            IsActivated = true;
            OnSceneActivated?.Invoke();
        }

        protected virtual void OnDisable()
        {
            for (int i = _systems.Count - 1; i > 0; i--)
            {
                _systems[i].Dispose();
            }
            GameEntry.GetInstance().RemoveScene(this);
            OnSceneDeactivated?.Invoke();
        }

        protected virtual void Update()
        {
            foreach (var system in _systems)
            {
                system.CallUpdate(Time.deltaTime);
            }
            foreach (var obj in _objects)
            {
                obj.CallUpdate(Time.deltaTime);
            }
        }
        
        protected virtual void FixedUpdate()
        {
            foreach (var system in _systems)
            {
                system.CallFixedUpdate(Time.fixedDeltaTime);
            }
            foreach (var obj in _objects)
            {
                obj.CallFixedUpdate(Time.fixedDeltaTime);
            }
        }
        
        protected virtual void LateUpdate()
        {
            foreach (var system in _systems)
            {
                system.CallLateUpdate(Time.deltaTime);
            }
            foreach (var obj in _objects)
            {
                obj.CallLateUpdate(Time.deltaTime);
            }
            ApplyMonoChanges();
        }

        public T GetSystem<T>() where T : BaseSystem
        {
            foreach (var system in _systems)
            {
                if (system is T targetSystem)
                {
                    return targetSystem;
                }
            }

            throw new NullReferenceException("No such system found!");
        }

        private static void ApplyMonoChanges()
        {
            foreach (var change in _changes)
            {
                if (change.Value == true)
                {
                    _objects.Add(change.Key);    
                }
                else
                {
                    _objects.Remove(change.Key);
                }
            }
            _changes.Clear();
        }
        
        public static void AddMonoBehaviour(BaseMonoBehaviour obj)
        {
            _changes[obj] = true;
        }

        public static void RemoveMonoBehaviour(BaseMonoBehaviour obj)
        {
            _changes[obj] = false;
        }
    }
}