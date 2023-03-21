using System.Collections.Generic;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Controllers
{
    public class HealthBarController : BaseController
    {
        public override bool HasUpdate => true;

        private List<HealthBarView> views;
        private FollowingCameraView camera;

        public HealthBarController(FollowingCameraView camera)
        {
            views = new List<HealthBarView>();
            this.camera = camera;
        }
        
        public void AddView(HealthBarView view)
        {
            views.Add(view);
        }

        public override void Update(float dt)
        {
            bool refresh = false;
            foreach (var view in views)
            {
                if (view == null)
                {
                    refresh = true;
                    continue;
                }
                
                view.DisplayHealth(view.Target.GetHealthNormalized()); 
                view.transform.LookAt(camera.transform.position);
            }

            if (refresh)
            {
                views.RemoveAll(view => view == null);
            }
        }

        public void RemoveView(HealthBarView view)
        {
            views.Remove(view);
        }
    }
}