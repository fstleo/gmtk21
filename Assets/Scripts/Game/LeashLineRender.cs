using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeashLineRender : MonoBehaviour
{
    [SerializeField]
    private Transform _leashStart;
    
    [SerializeField]
    private Transform _leashTarget;

    [SerializeField]
    private LineRenderer _line;

    [SerializeField] private float _maxLength;

    void Update()
    {
        _line.SetPosition(0, _leashStart.position);
        _line.SetPosition(1, _leashTarget.position);
    }
}
