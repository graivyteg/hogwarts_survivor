using Game.Core;

namespace Game.Pool
{
    public class PoolMonoBehaviour : BaseMonoBehaviour
    {
        
        
        public virtual void OnTakenFromPool()
        {
            
        }
        
        public virtual void ReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}