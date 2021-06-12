using UnityEngine;

public class ControlledSideMove : MonoBehaviour
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
        _animator.SetFloat(Speed, 1f);
    }

    public void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        _move = new Vector3(h, 0, v).normalized;
    }
    
    private void FixedUpdate()
    {
        _transform.forward = Vector3.forward + _move;

        _move *= _speed * Time.fixedDeltaTime;
        
        var targetPosition = _target.position;
        if ((_rigidbody.position + _move - targetPosition).sqrMagnitude < _maxDistance * _maxDistance)
        {
            _rigidbody.MovePosition(targetPosition +
                                    Vector3.ClampMagnitude(_rigidbody.position + _move - targetPosition,
                                        _maxDistance));
        }
        else
        {
            _target.forward = _rigidbody.position - targetPosition;
        }
    }
}