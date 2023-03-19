using Game.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class PlayerDamageable : BaseMonoBehaviour, IDamageable
    {
        [SerializeField] private float _maxHealth = 100;

        private float _health;

        protected override void OnInit()
        {
            _health = _maxHealth;
        }

        public void DealDamage(float damage)
        {
            _health -= Mathf.Min(damage, _health);
            if (_health == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}