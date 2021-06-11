using UnityEngine;
using UnityEngine.UI;

public class OptionScreen : Screen
{
    [SerializeField]
    private Slider _sound;
    
    [SerializeField]
    private Slider _music;

    [SerializeField]
    private Button _button;
    
    protected override void OnOpen()
    {
        _music.value = SoundsManager.Instance.MusicLevel;
        _sound.value = SoundsManager.Instance.SoundLevel;
        _music.onValueChanged.AddListener(MusicChanged);
        _sound.onValueChanged.AddListener(SoundChanged);
        _button.onClick.AddListener(OpenMain);
    }

    private void OpenMain()
    {
        ScreenManager.Instance.Open(ScreenType.Main);
        SoundsManager.Instance.PlaySound(SoundId.Click);
    }
    
    private void SoundChanged(float value)
    {
        SoundsManager.Instance.SoundLevel = value;
        SoundsManager.Instance.PlaySound(SoundId.Click);
    }
    
    private void MusicChanged(float value)
    {
        SoundsManager.Instance.MusicLevel = value;
    }
    
    protected override void OnClosed()
    {
        _music.onValueChanged.RemoveListener(MusicChanged);
        _sound.onValueChanged.RemoveListener(SoundChanged);
    }
}