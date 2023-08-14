using UnityEngine;

public class GameManager : MonoBehaviour {
    #region Singleton

    private static GameManager _i;

    public static GameManager I {
        get {
            if (_i == null) {
                _i = FindObjectOfType<GameManager>() ??
                    new GameObject(nameof(GameManager)).AddComponent<GameManager>();
            }

            return _i;
        }
    }

    #endregion

    public enum GameState {
        Idle,
        Playing,
        GameOver
    }

    public GameState State { get; set; }

    private void Start() {
        State = GameState.Idle;
        UIManager.I.ShowMainMenu();
    }

    public void StartGame() {
        State = GameState.Playing;
        UIManager.I.ShowGameUI();
    }
    
    public void GameOver() {
        State = GameState.GameOver;
        UIManager.I.ShowGameOver();
    }
}
