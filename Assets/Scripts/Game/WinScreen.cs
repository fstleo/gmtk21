using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : Screen
{
        
    [SerializeField]
    private Button _nextLevel;

    [SerializeField]
    private Button _menuButton;
    
    protected override void OnOpen()
    {
        _nextLevel.onClick.AddListener(RestartGame);
        _menuButton.onClick.AddListener(LoadMenu);
    }

    protected override void OnClosed()
    {
        _nextLevel.onClick.RemoveListener(RestartGame);
        _menuButton.onClick.RemoveListener(LoadMenu);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
        ScreenManager.Instance.Open(ScreenType.Main);
        Time.timeScale = 1f;
    }
    
    private void RestartGame()
    {
        var nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextLevelIndex);
        ScreenManager.Instance.Open(ScreenType.Game);
        Time.timeScale = 1f;
    }
}