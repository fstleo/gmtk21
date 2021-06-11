using System;
using System.Collections.Generic;
using UnityEngine;

public enum SoundId
{
    Click
}

public class SoundsManager : Singletone<SoundsManager>
{
    [Serializable]
    private class Sound
    {
        [SerializeField] private SoundId _id;
        [SerializeField] private AudioClip _clip;

        public AudioClip Clip => _clip;

        public SoundId ID => _id;
    }
    
    [SerializeField]
    private AudioSource _soundsSource;
    
    [SerializeField]
    private AudioSource _musicSource;

    public float SoundLevel
    {
        get => _soundsSource.volume;
        set => _soundsSource.volume = value;
    }

    public float MusicLevel
    {
        get => _musicSource.volume;
        set => _musicSource.volume = value;
    }

    [SerializeField] 
    private Sound[] _clips;

    private Dictionary<SoundId, AudioClip> _audioClips = new Dictionary<SoundId, AudioClip>();
    
    private void Awake()
    {
        foreach (var audio in _clips)
        {
            _audioClips.Add(audio.ID, audio.Clip);
        }
    }

    public void PlaySound(SoundId id)
    {
        if (_audioClips.TryGetValue(id, out var clip))
        {
            _soundsSource.PlayOneShot(clip);
        }
    }
    
}