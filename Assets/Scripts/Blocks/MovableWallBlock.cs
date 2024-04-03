using UnityEngine;

namespace Scripts.Blocks
{
    public class MovableWallBlock : Block
    {
        [SerializeField] private float minMaxPos;

        private void Update()
        {
            var vector3 = transform.position;
            vector3.x = Mathf.PingPong(Time.time, minMaxPos)-(minMaxPos/2);
            transform.position = vector3;
        }

        protected override void OnTrigger(Collider2D other)
        {
            
        }
    }
}