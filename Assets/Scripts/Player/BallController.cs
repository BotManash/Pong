using System;
using Scripts.Blocks;
using Scripts.Global;
using UnityEngine;


namespace Scripts.Player
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private float thrust;
        [SerializeField] private AudioClip hitAudioClip;
        [SerializeField] private float maxSpeed;
        private Rigidbody2D Rb => GetComponent<Rigidbody2D>();
        private AudioSource AudioS=>GetComponent<AudioSource>();

        private void Update()
        {
            if (Rb.velocity.magnitude >= maxSpeed)
            {
                Rb.velocity = Vector3.ClampMagnitude(Rb.velocity, maxSpeed);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(ConstantKey.HitBlock))
            {
                if (!other.TryGetComponent(out IBlockHit blockHealth))
                {
                    return;
                }
                blockHealth.GetDamage(() =>
                {
                    if (!AudioS.isPlaying)
                    {
                        AudioS.PlayOneShot(hitAudioClip);
                    }
                });
            }
            else if (other.CompareTag(ConstantKey.Player) && Rb.velocity.magnitude < maxSpeed) 
            {
                var direction = other.transform.position - transform.position;
                var finalDir = new Vector3(1 * direction.x, 1 * direction.y, 0);
                Rb.AddForce(finalDir * thrust, ForceMode2D.Impulse);
            }
        }
    }
}