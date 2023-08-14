using UnityEngine;

namespace Damaging {
    [RequireComponent(typeof(Collider))]
    public class Damager : MonoBehaviour {
        [SerializeField] private float _damage;

        private void OnCollisionEnter(Collision other) {
            var damageable = other.gameObject.GetComponent<Damageable>();

            if (damageable == null) {
                return;
            }

            damageable.TakeDamage(_damage);
            
            Destroy(gameObject);
        }
    }
}
