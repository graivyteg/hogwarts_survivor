using System;
using System.Collections;
using System.Collections.Generic;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Controllers
{
    public class TimeController : BaseController
    {
        private EntryPoint entryPoint;
        private Dictionary<int, Coroutine> coroutines;

        private int lastId;

        public TimeController()
        {
            entryPoint = EntryPoint.GetNewInstance();
            coroutines = new Dictionary<int, Coroutine>();
            lastId = 0;
        }
        
        public void SetTimeout(float delay, Action callback)
        {
            var coroutine = entryPoint.StartCoroutine(Timeout(lastId, delay, callback));
            coroutines.Add(lastId, coroutine);
            lastId++;
        }

        public void SetInterval(float delay, Action callback)
        {
            var coroutine = entryPoint.StartCoroutine(Interval(lastId, delay, callback));
            coroutines.Add(lastId, coroutine);
            lastId++;
        }

        public void ClearCoroutine(int id)
        {
            try
            {
                entryPoint.StopCoroutine(coroutines[id]);
            }
            catch
            {
                Debug.LogWarning("Such coroutine can't be cleared, because it is not active");
            }

            if(coroutines.ContainsKey(id))
                coroutines.Remove(id);
        }

        private IEnumerator Timeout(int id, float delay, Action callback)
        {
            yield return new WaitForSeconds(delay);
            callback?.Invoke();
            coroutines.Remove(id);
        }
        
        private IEnumerator Interval(int id, float delay, Action callback)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                callback?.Invoke();
            }
        }
    }
}