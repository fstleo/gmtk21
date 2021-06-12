using UnityEngine;
using UnityEngine.UI;

public class GameMenu : Screen
{
    [SerializeField]
    private Button _pauseButton;
    
    protected override void OnOpen()
    {
        _pauseButton.onClick.AddListener(OpenPause);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPause();
        }
    }
    
    private void OpenPause()
    {
        ScreenManager.Instance.Open(ScreenType.GamePause);
    }

    protected override void OnClosed()
    {
        _pauseButton.onClick.RemoveListener(OpenPause);
    }
}