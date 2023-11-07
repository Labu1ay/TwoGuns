using System;
using UnityEngine;

namespace GameLogic {
    public class SlowdownZone : MonoBehaviour {
        [SerializeField] private float _slowdownValue = 10f;
        private float _squareSlowdownValue;
        
        private void Start() => _squareSlowdownValue = Mathf.Pow(_slowdownValue, 2);

        private void OnTriggerEnter2D(Collider2D other) {
            other.TryGetComponent(out Rigidbody2D rigidbody);
            if (rigidbody) {
                rigidbody.velocity /= _slowdownValue;
                rigidbody.gravityScale /= _squareSlowdownValue;
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            other.TryGetComponent(out Rigidbody2D rigidbody);
            if (rigidbody) {
                rigidbody.velocity *= _slowdownValue;
                rigidbody.gravityScale *= _squareSlowdownValue;
            }
        }
    }
}