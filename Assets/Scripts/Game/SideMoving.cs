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
}