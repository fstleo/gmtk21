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

    [SerializeField]
    private Button _quit;
    
    protected override void OnOpen()
    {
        _startGame.onClick.AddListener(StartGame);
        _options.onClick.AddListener(OpenOptions);
        _infiniteMode.onClick.AddListener(StartInfiniteMode);
        _quit.onClick.AddListener(Quit);
    }

    private void StartInfiniteMode()
    {
        SceneManager.LoadScene(1);
        ScreenManager.Instance.Open(ScreenType.Game);
        Click();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(2);
        ScreenManager.Instance.Open(ScreenType.Game);
        Click();
    }
    
    private void Quit()
    {
        Application.Quit();
    }
    
    private void OpenOptions()
    {
        ScreenManager.Instance.Open(ScreenType.Options);
        Click();
    }

    protected override void OnClosed()
    {
        _startGame.onClick.RemoveListener(StartGame);
        _options.onClick.RemoveListener(OpenOptions);
        _infiniteMode.onClick.RemoveListener(StartInfiniteMode);
        _quit.onClick.RemoveListener(Quit);
    }
}
