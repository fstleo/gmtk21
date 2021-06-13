using System;
using UnityEngine;

public class OffsetScrolling : MonoBehaviour
{
    [SerializeField]
    private Material _material;

    [SerializeField]
    private Vector2 _scrollingSpeed;

    private Vector2 _currentOffset;
    
    private void FixedUpdate()
    {
        _material.SetTextureOffset("_MainTex", _currentOffset);
        _currentOffset += _scrollingSpeed * Time.fixedDeltaTime;
    }
}
