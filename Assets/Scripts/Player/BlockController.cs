using UnityEngine;

namespace Scripts.Player
{
    public class BlockController : MonoBehaviour
    {
        [SerializeField] private float sideMovementSpeed;
        [SerializeField] private float minMaxSidePosition;
        private float _xDir;

        private void Update()
        {
            _xDir = Input.GetAxis("Horizontal");
            var currentPosition = transform.position;
            currentPosition = new Vector2(Mathf.Clamp(currentPosition.x, -minMaxSidePosition, minMaxSidePosition),
                currentPosition.y);
            transform.position = currentPosition;
        }
        private void FixedUpdate()
        {
            transform.Translate(Vector2.right * (_xDir * (Time.fixedDeltaTime * sideMovementSpeed)));
        }
    }
}

