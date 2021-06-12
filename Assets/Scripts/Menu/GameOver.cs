using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : Screen
{
    [SerializeField]
    private Button _startGame;

    [SerializeField]
    private Button _menuButton;
    
    protected override void OnOpen()
    {
        _startGame.onClick.AddListener(RestartGame);
        _menuButton.onClick.AddListener(LoadMenu);
    }

    protected override void OnClosed()
    {
        _startGame.onClick.RemoveListener(RestartGame);
        _menuButton.onClick.RemoveListener(LoadMenu);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        ScreenManager.Instance.Open(ScreenType.Main);
        Time.timeScale = 1f;
    }
    
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScreenManager.Instance.Open(ScreenType.Game);
        Time.timeScale = 1f;
    }

}
