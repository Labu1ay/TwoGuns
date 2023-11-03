using UnityEngine;

namespace GameLogic {
    public class SlowdownZone : MonoBehaviour {
        [SerializeField] private float _slowdownValue = 10f;
        private void OnTriggerEnter2D(Collider2D other) {
            other.TryGetComponent(out Rigidbody2D rigidbody);
            if (rigidbody) {
                rigidbody.velocity /= _slowdownValue;
                rigidbody.gravityScale /= _slowdownValue;
                rigidbody.drag *= _slowdownValue;
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            other.TryGetComponent(out Rigidbody2D rigidbody);
            if (rigidbody) {
                rigidbody.velocity *= _slowdownValue;
                rigidbody.gravityScale *= _slowdownValue;
                rigidbody.drag /= _slowdownValue;
            }
        }
    }
}