using UnityEngine;

public class GameMenu : Screen
{
    [SerializeField]
    private GameObject _pauseText;
    
    protected override void OnOpen()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f - Time.timeScale;
            _pauseText.SetActive(Time.timeScale < 0.5f);
        }
    }
    

    protected override void OnClosed()
    {
    }
}
