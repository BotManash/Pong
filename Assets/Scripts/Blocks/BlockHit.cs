using System;
using UnityEngine;

namespace Scripts.Blocks
{
    public class BlockHit : MonoBehaviour,IBlockHit
    {
        public bool HasHit { get; private set; }
        [SerializeField] private int health;
        
        public void GetDamage(Action callBack)
        {
            Hit(null);
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

        public void Hit(Action callBack)
        {
            HasHit = true;
        }


        private void DestroyObject(Action callback)
        {
            callback?.Invoke();
            this.gameObject.SetActive(false);
        }
    }

    public interface IBlockHit
    {
        public void GetDamage(Action callBack);
        public void Hit(Action callBack);
    }
}

