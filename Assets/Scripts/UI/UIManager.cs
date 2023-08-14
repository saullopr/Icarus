using UnityEngine;

public class UIManager : MonoBehaviour {
    #region Singleton

    private static UIManager _i;

    public static UIManager I {
        get {
            if (_i == null) {
                _i = FindObjectOfType<UIManager>() ??
                    new GameObject(nameof(UIManager)).AddComponent<UIManager>();
            }

            return _i;
        }
    }

    #endregion

    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _inGamePanel;
    [SerializeField] private GameObject _gameOverPanel;

    public void ShowMainMenu() {
        _mainMenuPanel.SetActive(true);
        _inGamePanel.SetActive(false);
        _gameOverPanel.SetActive(false);
    }
    
    public void ShowGameUI() {
        _mainMenuPanel.SetActive(false);
        _inGamePanel.SetActive(true);
        _gameOverPanel.SetActive(false);
    }

    public void ShowGameOver() {
        _mainMenuPanel.SetActive(false);
        _inGamePanel.SetActive(false);
        _gameOverPanel.SetActive(true);
    }

    public void QuitApp() {
        Application.Quit();
    }
}
