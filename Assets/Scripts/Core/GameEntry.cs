using System;
using UnityEngine;

namespace Game.Core
{
    public class GameEntry : MonoBehaviour
    {
        private static GameEntry _instance;

        public BaseScene _scene;

        private void Awake()
        {
            if (_instance == null) _instance = this;
            else if (_instance != this) Destroy(gameObject);
            
            DontDestroyOnLoad(gameObject);
        }

        public static GameEntry GetInstance() => _instance;

        public void ApplyScene(BaseScene scene)
        {
            _scene = scene;
        }

        public void RemoveScene(BaseScene scene)
        {
            _scene = null;
        }
    }
}