using UnityEngine;

public class MovingForward : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private Transform _transform;

    [SerializeField]
    private float _speed;

    [SerializeField] private bool _log;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var move = _transform.forward * (_speed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(_rigidbody.position + move);
    }
}