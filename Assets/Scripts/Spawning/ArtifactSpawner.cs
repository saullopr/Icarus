using UnityEngine;

namespace Spawning {
    public class ArtifactSpawner : MonoBehaviour {
        [SerializeField] private float _spawnRange;
        [SerializeField] private GameObject[] _artifacts;
        [SerializeField] private float _prefabHeight;
        [SerializeField] private LayerMask _spawnMask;

        private void Start() {
            foreach (var artifact in _artifacts) {
                Spawn(artifact);
            }
        }

        private Vector3? GetSpawnPoint() {
            var basePos = Random.insideUnitSphere * _spawnRange + transform.position;

            var ray = new Ray(basePos, -transform.up);
            if (Physics.Raycast(ray, out var hitInfo, float.MaxValue, _spawnMask)) {
                return hitInfo.point + new Vector3(0, _prefabHeight, 0);
            }

            return null;
        }

        private void Spawn(GameObject prefab) {
            Vector3? pos = null;

            while (pos == null) {
                pos = GetSpawnPoint();
            }

            Instantiate(prefab, pos.Value, Quaternion.identity);
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.green;

            Gizmos.DrawWireSphere(transform.position, _spawnRange);
        }
    }
}
