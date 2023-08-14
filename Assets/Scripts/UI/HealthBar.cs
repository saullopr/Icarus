using Damaging;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class HealthBar : MonoBehaviour {
        [SerializeField] private Damageable _damageable;
        [SerializeField] private Slider _slider;

        private void Start() {
            _damageable.OnTakeDamage.AddListener(HandleOnTakeDamage);
        }

        private void HandleOnTakeDamage(float damage) {
            _slider.value -= Mathf.Clamp(damage, 0, _damageable.MaxHeath) / _damageable.MaxHeath;
        }
    }
}
