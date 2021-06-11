using System;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : Singletone<ScreenManager>
{
    [Serializable]
    private class ScreenPreset
    {
        [SerializeField] private ScreenType _id;
        [SerializeField] private GameObject prefab;

        public GameObject Prefab => prefab;

        public ScreenType ID => _id;
    }
    
    private Dictionary<ScreenType, GameObject> _screens = new Dictionary<ScreenType, GameObject>();

    [SerializeField]
    private ScreenPreset[] _screensPresets;

    [SerializeField]
    private ScreenType _startScreen;

    private Screen _currentScreen;


    private void Awake()
    {
        foreach (var screen in _screensPresets)
        {
            _screens.Add(screen.ID, screen.Prefab);
        }
    }

    private void Start()
    {
        Open(_startScreen);
    }

    public void Open(ScreenType type)
    {
        if (_currentScreen != null)
        {
            _currentScreen.Close();
        }
        _currentScreen = Instantiate(_screens[type], transform).GetComponent<Screen>();
        _currentScreen.Open();
    }
}