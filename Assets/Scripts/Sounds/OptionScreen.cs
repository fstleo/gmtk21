using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundMenu : IDisposable
{
    private Slider _sound;
    private Slider _music;

    public SoundMenu(Slider soundSlider, Slider musicSlider)
    {
        _sound = soundSlider;
        _music = musicSlider;
        
        _music.value = SoundsManager.Instance.MusicLevel;
        _sound.value = SoundsManager.Instance.SoundLevel;
        
        _music.onValueChanged.AddListener(MusicChanged);
        _sound.onValueChanged.AddListener(SoundChanged);
    }

    public void Dispose()
    {
        _music.onValueChanged.RemoveListener(MusicChanged);
        _sound.onValueChanged.RemoveListener(SoundChanged);        
    }
    
    private void SoundChanged(float value)
    {        
        SoundsManager.Instance.SoundLevel = value;
        SoundsManager.Instance.PlaySound(SoundId.Bark);
    }
    
    private void MusicChanged(float value)
    {
        SoundsManager.Instance.MusicLevel = value;
    }

}

public class OptionScreen : Screen
{
    [SerializeField]
    private Slider _sound;
    
    [SerializeField]
    private Slider _music;

    [SerializeField]
    private Button _button;

    private SoundMenu _soundMenu;
    
    protected override void OnOpen()
    {
        _soundMenu = new SoundMenu(_sound, _music);
        if (_button != null)
        {
            _button.onClick.AddListener(OpenMain);
        }
    }

    private void OpenMain()
    {
        ScreenManager.Instance.Open(ScreenType.Main);
        Click();
    }
    

    protected override void OnClosed()
    {
        _soundMenu.Dispose();
        if (_button != null)
        {
            _button.onClick.RemoveListener(OpenMain);
        }
    }
}