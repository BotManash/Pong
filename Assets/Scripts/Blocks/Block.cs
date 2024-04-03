using Scripts.GameLoop;
using Scripts.Global;
using UnityEngine;

namespace Scripts.Blocks
{
    public abstract class Block : MonoBehaviour
    {
        [SerializeField] protected string blockName;

        
        protected abstract void OnTrigger(Collider2D other);
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(ConstantKey.Ball))
            {
                return;
            }
            OnTrigger(other);
            
        }
    }
}