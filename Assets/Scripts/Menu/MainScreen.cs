using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScreen : Screen
{

    [SerializeField]
    private Button _startGame;
    
    [SerializeField]
    private Button _options;
    
    [SerializeField]
    private Button _infiniteMode;

    protected override void OnOpen()
    {
        _startGame.onClick.AddListener(StartGame);
        _options.onClick.AddListener(OpenOptions);
        _infiniteMode.onClick.AddListener(StartInfiniteMode);
    }

    private void StartInfiniteMode()
    {
        SceneManager.LoadScene("InfiniteMode");
        ScreenManager.Instance.Open(ScreenType.Game);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("LevelTest");
        ScreenManager.Instance.Open(ScreenType.Game);
    }
    
    private void OpenOptions()
    {
        ScreenManager.Instance.Open(ScreenType.Options);
        SoundsManager.Instance.PlaySound(SoundId.Click);
    }

    protected override void OnClosed()
    {
        _startGame.onClick.RemoveListener(StartGame);
        _options.onClick.RemoveListener(OpenOptions);
        _infiniteMode.onClick.RemoveListener(StartInfiniteMode);
    }
}
