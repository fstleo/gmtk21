using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _height;

    [SerializeField]
    private float _distance;
    
    private void LateUpdate()
    {
        transform.LookAt(_target);
        transform.position = Vector3.Lerp(transform.position, _target.position - transform.forward * _distance + Vector3.up * _height, 0.5f);
    }
}
