using UnityEngine;

namespace Weapons {
    public class Bullet : MonoBehaviour {
        [SerializeField] private bool _dieOnCollision;
        [SerializeField] private float _lifeSpan;
        [SerializeField] private float _speed;

        private Vector3 _direction;

        public Vector3 Target {
            set => _direction = (value - transform.position).normalized;
        }

        private void Start() {
            if (_lifeSpan != 0) {
                Destroy(this, _lifeSpan);
            }
        }

        private void Update() {
            transform.position += _direction * (_speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision _) {
            if (!_dieOnCollision) {
                return;
            }

            Destroy(gameObject);
        }
    }
}
