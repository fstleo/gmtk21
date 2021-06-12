using UnityEngine;

public class RunnerMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _transform;

    [SerializeField]
    private float _speed;
    
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _maxDistance = 5;
    

    private Vector3 _move;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        _move = new Vector3(h, 0, v).normalized * (_speed * Time.fixedDeltaTime);        
    }

    private void FixedUpdate()
    {

        if ((_rigidbody.position + _move - _target.position).sqrMagnitude < _maxDistance * _maxDistance)
        {
            if ((_rigidbody.position + _move).z < -19)
            {
                return;
            }
            _rigidbody.MovePosition(_rigidbody.position + _move);
            _transform.forward = _move;
        }
        else
        {
            _target.forward = transform.position - _target.position;
        }
    }
}