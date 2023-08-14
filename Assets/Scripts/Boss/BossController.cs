using UnityEngine;

/// <summary>
/// Responsável por controllar o boss, olha para o jogador e atira misseis
/// </summary>
public class BossController : MonoBehaviour {
    [SerializeField] private GameObject _missilePrefab; //Prefab do missel
    [SerializeField] private Transform _gunPivot; //Pivot da arma, usado pra spawnar misseis
    [SerializeField] private float _fireDelay; //Cadencia de tiro (dos misseis)

    //Momento do ultimo tiro
    private float _lastShot;

    private void Update() {
        SpawnMissile();
    }

    //Resposável por criar o míssiel
    private void SpawnMissile() {
        //Se o tempo desde o ultimo missíl for menor do que [_fireDelay] então sai método sem spawnar
        if (Time.realtimeSinceStartup - _lastShot < _fireDelay) {
            return;
        }

        //Cria um missíl na posição do [_gunPivot]
        Instantiate(_missilePrefab, _gunPivot.position, Quaternion.identity);

        //Save o tempo atual como o ultimo tiro
        _lastShot = Time.realtimeSinceStartup;
    }
}
