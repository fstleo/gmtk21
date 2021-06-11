using System;
using UnityEngine;

// public class Leading : MonoBehaviour
// {
//     [SerializeField]
//     private Transform _target;
//     
//     private float 
//
//
//
//     public void Update()
//     {
//         
//     }
// }
public class MovingForward : MonoBehaviour
{
    private Rigidbody _rbody;

    private Transform _transform;

    [SerializeField]
    private float _speed;

    private Vector3 _move;

    private void Awake()
    {
        _transform = transform;
        _rbody = GetComponent<Rigidbody>();
        _move = _transform.forward * _speed;
    }

    private void Update()
    {
        _rbody.MovePosition(_transform.position + _move * Time.deltaTime);
    }
}
