using System.Linq;
using UnityEngine;
using Weapons;

namespace Enemies {
    public class Enemy : MonoBehaviour {
        [SerializeField] private float _viewDistance;
        [SerializeField] private LayerMask _targetMask;

        [Header("Weapon config")]
        [SerializeField] private Weapon _weapon;

        private void Update() {
            var target = FindTarget();

            if (target == null) {
                return;
            }
        
            LookAt(target);
            FireAt(target);
        }

        private Transform FindTarget() {
            var targets = Physics.OverlapSphere(transform.position, _viewDistance, _targetMask);

            if (targets.Length > 0) {
                return targets.First().transform;
            }

            return null;
        }

        private void LookAt(Transform target) {
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }

        private void FireAt(Transform target) {
            _weapon.Fire(target.position);
        }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;
            
            Gizmos.DrawWireSphere(transform.position, _viewDistance);
        }
    }
}
