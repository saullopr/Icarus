using System.Collections;
using UnityEngine;

namespace Boss {
    /// <summary>
    /// Responsável por spawnar o BOSS
    /// </summary>
    public class BossSpawner : MonoBehaviour {
        [SerializeField] private GameObject _bossPrefab; //Prefab do boss
        [SerializeField] private float _spawnHeight;     //Em que altura spawnar o boss

        //Spawna o boss depois de um delay
        private IEnumerator SpawnBoss() {
            //Ativa as 5 particulas que ficam girando antes do boss aparecer
            ArtifactManager.I.EnableCombo();

            //Espera por 8 segundos, esse é o tempo que a animação dura para finalizar
            yield return new WaitForSeconds(8);

            //Cria o prefab do boss na mesma posição desse objeto
            Instantiate(_bossPrefab, 
                transform.position + new Vector3(0, _spawnHeight, 0),
                Quaternion.identity);
        }

        //Ativa quando o jogador entrar no trigger desse objeto 
        private void OnTriggerEnter(Collider other) {
            if (!other.CompareTag("Player")) {
                return;
            }

            //Inicia o contador pra spawnar o boss
            StartCoroutine(SpawnBoss());
        }
    }
}
