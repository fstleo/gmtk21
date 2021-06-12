using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SoundId
{
    Click,
    Bark
}

public class SoundsManager : Singletone<SoundsManager>
{
    [Serializable]
    private class Sound
    {
        [SerializeField] private SoundId _id;
        [SerializeField] private AudioClip [] _clips;

        public AudioClip [] Clips => _clips;

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
        get => _musicSource.volume / 0.5f;
        set => _musicSource.volume = value * 0.5f;
    }

    [SerializeField] 
    private Sound[] _clips;

    private Dictionary<SoundId, AudioClip[]> _audioClips = new Dictionary<SoundId, AudioClip[]>();
    
    protected override void Awake()
    {
        base.Awake();
        foreach (var audio in _clips)
        {
            _audioClips.Add(audio.ID, audio.Clips);
        }
    }

    public void PlaySound(SoundId id)
    {
        if (_audioClips.TryGetValue(id, out var clips))
        {
            _soundsSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
        }
    }
    
}