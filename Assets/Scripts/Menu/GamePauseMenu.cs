using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePauseMenu : Screen
{
    
    [SerializeField]
    private Slider _sound;
    
    [SerializeField]
    private Slider _music;
    
    [SerializeField]
    private Button _backToTheGame;
    
    [SerializeField]
    private Button _mainMenu;
    
    private SoundMenu _soundMenu;
    
    protected override void OnOpen()
    {
        Time.timeScale = 0;
        
        _soundMenu = new SoundMenu(_sound, _music);
        _backToTheGame.onClick.AddListener(BackToTheGame);
        _mainMenu.onClick.AddListener(GoToMainMenu);
    }

    private void BackToTheGame()
    {
        ScreenManager.Instance.GoBack();
        Click();
    }

    private void GoToMainMenu()
    {
        ScreenManager.Instance.Open(ScreenType.Main);
        SceneManager.LoadScene("MainMenu");
        Click();
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToTheGame();
        }
    }
    

    protected override void OnClosed()
    {
        Time.timeScale = 1f;
        _soundMenu.Dispose();
        _backToTheGame.onClick.RemoveListener(BackToTheGame);
        _mainMenu.onClick.RemoveListener(GoToMainMenu);
    }
}