using UnityEngine;

namespace GameLogic {
    public class BottomBorderTrigger : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D other) {
            other.TryGetComponent(out Bullet bullet);
            if(bullet) bullet.Destroy();
        }
    }
}