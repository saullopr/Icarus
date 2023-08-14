using UnityEngine;

namespace Weapons {
    public class Weapon : MonoBehaviour {
        [SerializeField] private double _fireDelay;

        [SerializeField] private GameObject _bulletPrefab;

        [SerializeField] private Transform _bulletPivot;
        [SerializeField] private float _maxAimDistance = 10;

        private float _lastShot;

        public void Fire(Vector3? target = null) {
            var now = Time.realtimeSinceStartup;

            if (now - _lastShot < _fireDelay) {
                return;
            }

            target = target ?? GetTargetPos();

            _bulletPivot.LookAt(target.Value);

            var bullet = Instantiate(_bulletPrefab, _bulletPivot.position, _bulletPivot.rotation);

            bullet.GetComponent<Bullet>().Target = target.Value;

            _lastShot = now;
        }

        private Vector3 GetTargetPos() {
            var ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f));

            if (Physics.Raycast(ray, out var hit, _maxAimDistance)) {
                return hit.point;
            }

            return ray.GetPoint(_maxAimDistance);
        }
    }
}
