namespace HogwartsSurvivor.Models.Spells
{
    public interface ISpell
    {
        public void Update(float dt);
        public bool TryCast();
    }
}