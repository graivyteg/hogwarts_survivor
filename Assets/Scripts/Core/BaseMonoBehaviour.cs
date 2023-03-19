using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    public class BaseMonoBehaviour : MonoBehaviour
    {
        private bool _isInitialized = false;
        
        private void OnEnable()
        {
            BaseScene.AddMonoBehaviour(this);
            if (BaseScene.GetInstance() != null
                && BaseScene.GetInstance().IsActivated 
                && !_isInitialized) Init();
        }

        public void Init()
        {
            _isInitialized = true;
            OnInit();
        }

        protected virtual void OnInit() { }

        public void CallUpdate(float dt) => OnUpdate(dt);
        protected virtual void OnUpdate(float dt) { }
        
        public void CallFixedUpdate(float dt) => OnFixedUpdate(dt);
        protected virtual void OnFixedUpdate(float dt) { }

        public void CallLateUpdate(float dt) => OnLateUpdate(dt);
        protected virtual void OnLateUpdate(float dt) { }
        
        private void OnDisable()
        {
            BaseScene.RemoveMonoBehaviour(this);
            OnDispose();
        }
        protected virtual void OnDispose() { } 
    }
}