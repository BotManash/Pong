using UnityEngine;

namespace Scripts.Player
{
    public class BallPhysicsController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;

        public void EnablePhysics()
        {
            rb.isKinematic = false;
        }
        public void DisablePhysics()
        {
            rb.isKinematic = true;
        }

    }

}
