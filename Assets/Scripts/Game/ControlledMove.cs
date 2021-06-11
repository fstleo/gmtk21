using UnityEngine;

public class ControlledMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _transform;

    [SerializeField]
    private float _speed;

    private Vector3 _move;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        var move = new Vector3(h, 0, v).normalized * (_speed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(_rigidbody.position + move);
    }
}