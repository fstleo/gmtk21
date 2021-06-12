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

    private ScreenType _previousScreenType;
    private ScreenType _currentScreenType;

    protected override void Awake()
    {
        base.Awake();
        foreach (var screen in _screensPresets)
        {
            _screens.Add(screen.ID, screen.Prefab);
        }
    }

    private void Start()
    {
        Open(_startScreen);
    }

    public void GoBack()
    {
        Open(_previousScreenType);
    }

    public void Open(ScreenType type)
    {
        if (_currentScreen != null)
        {
            _currentScreen.Close();
        }

        _previousScreenType = _currentScreenType;    
        _currentScreen = Instantiate(_screens[type], transform).GetComponent<Screen>();
        _currentScreenType = type;
        _currentScreen.Open();
    }
}