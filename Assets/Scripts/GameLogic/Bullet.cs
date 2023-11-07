using UnityEngine;

namespace GameLogic {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour {
        [SerializeField] private Rigidbody2D _rigidbody;
        private void OnValidate() => _rigidbody ??= GetComponent<Rigidbody2D>();

        public void Init(Vector3 direction, float speed) {
            _rigidbody.velocity = direction * speed;
        }

        public void Destroy() => gameObject.SetActive(false);
    }
}