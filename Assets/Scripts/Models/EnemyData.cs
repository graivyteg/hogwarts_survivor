using System;
using HogwartsSurvivor.Views;
using OLS_HyperCasual;
using UnityEngine;

namespace HogwartsSurvivor.Models
{
    public class EnemyData : DamageableModel<EnemyView>
    {
        public bool IsPoolable => PoolableView != null;
        public readonly PoolableView PoolableView;

        public EnemyData(EnemyView view) : base(view)
        {
            PoolableView = view.PoolableView != null ? view.PoolableView : null;
        }
    }
}