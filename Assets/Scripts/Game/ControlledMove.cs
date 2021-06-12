using UnityEngine;


public class ControlledMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _transform;

    [SerializeField]
    private float _speed;
    
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _maxDistance = 5;

    [SerializeField]
    private Animator _animator;

    
    private Vector3 _move;
    private static readonly int Speed = Animator.StringToHash("speed");

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        _move = new Vector3(h, 0, v).normalized;
        _animator.SetFloat(Speed, _move.magnitude);
    }
    
    private void FixedUpdate()
    {
        if (_move.sqrMagnitude > 0.01f)
        {
            _transform.forward = _move;
        }
        _move *= (_speed * Time.fixedDeltaTime);

        if ((_rigidbody.position + _move - _target.position).sqrMagnitude < _maxDistance * _maxDistance)
        {
            _rigidbody.MovePosition(_target.position +
                                    Vector3.ClampMagnitude(_rigidbody.position + _move - _target.position,
                                        _maxDistance));
        }
        else
        {
            _target.forward = _transform.position - _target.position;
        }
    }
}