using UnityEngine;

namespace HogwartsSurvivor.Models.Spells
{
    public class StandardSpell : ISpell
    {
        private float maxCooldown;
        private float cooldown;

        private float damage;
        private float speed;
        
        public StandardSpell(StandardSpellSO so)
        {
            cooldown = 0;
            maxCooldown = so.Cooldown;
            speed = so.Speed;
            damage = so.Damage;
        } 
        
        public void Update(float dt)
        {
            cooldown -= Mathf.Min(dt, cooldown);

            if (cooldown == 0)
            {
                TryCast();
            }
        }

        public bool TryCast()
        {
            if (cooldown > 0) return false;
            
            Debug.Log("BOOOM");
            ResetCooldown();
            return true;
        }

        public void ResetCooldown()
        {
            cooldown = maxCooldown;
        }
    }
}