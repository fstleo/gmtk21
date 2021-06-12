using System;
using UnityEngine;

public class SideMoving : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private Transform _transform;

    [SerializeField]
    private float _speed;


    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var move = _transform.forward * (_speed * Time.fixedDeltaTime);
        // if (Mathf.Abs(move.x) > move.z)
        // {
        //     move = new Vector3(Mathf.Sign(move.x) * 0.7f, 0, 0.7f) *  (_speed * Time.fixedDeltaTime);
        //     _transform.forward = move;
        // }

        _rigidbody.MovePosition(_rigidbody.position + new Vector3(move.x, 0, 0));
    }
}