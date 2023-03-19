namespace Game.Weapon
{
    public interface ISpell
    {
        public bool TryCast(SpellCaster caster);
        public void Update(float dt);
    }
}