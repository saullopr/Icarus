using System;
using UnityEngine;
using Weapons;

namespace Player {
    public class PlayerWeaponController : MonoBehaviour {
        [SerializeField] private Weapon _weapon;
        
        [SerializeField] private FiringMethod _firingMethod;
        [SerializeField] private KeyCode _fireKey = KeyCode.Mouse0;

        private void Update() {
            switch (_firingMethod) {
                case FiringMethod.Constant:
                    if (Input.GetKey(_fireKey)) {
                        _weapon.Fire();
                    }

                    break;
                case FiringMethod.Single:
                    if (Input.GetKeyDown(_fireKey)) {
                        _weapon.Fire();
                    }

                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
