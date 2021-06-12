using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : Screen
{
    [SerializeField]
    private Button _startGame;

    protected override void OnOpen()
    {
        _startGame.onClick.AddListener(RestartGame);
    }

    protected override void OnClosed()
    {
        _startGame.onClick.RemoveListener(RestartGame);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        ScreenManager.Instance.Open(ScreenType.Game);
        Time.timeScale = 1f;
    }

}
