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
        _rigidbody.MovePosition(_rigidbody.position + new Vector3(move.x, 0, 0));
    }

    public void SetForward(Vector3 forward)
    {
        if (Mathf.Abs(forward.x) > forward.z)
        {
            forward = new Vector3(Mathf.Sign(forward.x) * 0.7f, 0, 0.7f) *  (_speed * Time.fixedDeltaTime);
        }
        _transform.forward = forward;

    }
}