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



    private Vector3 _move;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {

    }
    
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        var move = new Vector3(h, 0, v).normalized * (_speed * Time.fixedDeltaTime);
        if ((_rigidbody.position + move - _target.position).sqrMagnitude < _maxDistance * _maxDistance)
        {
            _rigidbody.MovePosition(_rigidbody.position + move);
            _transform.forward = move;
        }
        else
        {
            _target.forward = transform.position - _target.position;
        }
    }
}