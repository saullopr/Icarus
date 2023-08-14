using UnityEngine;

namespace Spawning {
    public class Spawner : MonoBehaviour {
        [SerializeField] private float _spawnRange;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private GameObject _spawnPrefab;
        [SerializeField] private float _prefabHeight;
        [SerializeField] private LayerMask _spawnMask;
        [SerializeField] private int _batchSize = 1;
        [SerializeField] private int _maxSpawns = -1;

        private float _lastSpawn;
        private int _spawned;

        private void Start() {
            SpawnBatch(true);
        }

        private void Update() {
            SpawnBatch();
        }

        private bool CanSpawn() {
            return Time.realtimeSinceStartup - _lastSpawn >= _spawnDelay &&
                (_maxSpawns == -1 || _spawned < _maxSpawns);
        }

        private Vector3? GetSpawnPoint() {
            var basePos = Random.insideUnitSphere * _spawnRange + transform.position;

            var ray = new Ray(basePos, -transform.up);
            if (Physics.Raycast(ray, out var hitInfo, float.MaxValue, _spawnMask)) {
                return hitInfo.point + new Vector3(0, _prefabHeight, 0);
            }

            return null;
        }

        private void SpawnBatch(bool ignoreConditions = false) {
            for (var i = 0; i < _batchSize; i++) {
                Spawn(ignoreConditions);
            }
        }

        private void Spawn(bool ignoreConditions = false) {
            if (!ignoreConditions && !CanSpawn()) {
                return;
            }

            Vector3? pos = null;

            while (pos == null) {
                pos = GetSpawnPoint();
            }

            var go = Instantiate(_spawnPrefab, pos.Value, Quaternion.identity);

            _lastSpawn = Time.realtimeSinceStartup;
            _spawned++;
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.green;

            Gizmos.DrawWireSphere(transform.position, _spawnRange);
        }
    }
}
