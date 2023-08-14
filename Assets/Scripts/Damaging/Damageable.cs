using UnityEngine;
using UnityEngine.Events;

namespace Damaging {
    [RequireComponent(typeof(Collider))]
    public class Damageable : MonoBehaviour {
        [SerializeField] private float _maxHeath;
        [Range(0, 1)] [SerializeField] private float _resistance;

        [SerializeField] private UnityEvent<float> _onTakeDamage;
        [SerializeField] private UnityEvent _onDie;

        private float _heath;

        public float MaxHeath => _maxHeath;

        // ReSharper disable once InconsistentNaming
        public UnityEvent<float> OnTakeDamage => _onTakeDamage;

        // ReSharper disable once InconsistentNaming
        public UnityEvent OnDie => _onDie;

        public float Heath => _heath;

        private void Awake() {
            _heath = _maxHeath;
        }

        public void TakeDamage(float damage) {
            var finalDamage = damage * (1 - _resistance);

            _heath -= finalDamage;

            print($"Took {finalDamage} damage");
            
            _onTakeDamage.Invoke(finalDamage);

            if (_heath <= 0) {
                _onDie.Invoke();

                print("Died!");
                
                Destroy(gameObject);
            }
        }
    }
}
