using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : Screen
{

    [SerializeField]
    private Button _startGame;
    
    [SerializeField]
    private Button _options;

    protected override void OnOpen()
    {
        _startGame.onClick.AddListener(StartGame);
        _options.onClick.AddListener(OpenOptions);
    }

    private void StartGame()
    {
        
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
    }
}
