using System;
using UnityEngine;

namespace Scripts.Blocks
{
    public class BlockHitModule : MonoBehaviour,IBlockHit
    {
        public bool HasHit { get; private set; }
        [SerializeField] private int health;
        
        public void GetDamage(Action callBack)
        {
            if (health > 0)
            {
                health--;
                if (health <= 0)
                {
                    DestroyObject(callBack);
                }
                return;
            }
            DestroyObject(callBack);
        }
        private void DestroyObject(Action callback)
        {
            HasHit = true;
            callback?.Invoke();
            this.gameObject.SetActive(false);
        }
    }

    public interface IBlockHit
    {
        public void GetDamage(Action callBack);
        
    }
}

