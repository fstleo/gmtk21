using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private Vector3 _offset;

    private Transform _transform;


    private void Awake()
    {
        _transform = transform;
    }

    private void LateUpdate()
    {
        _transform.LookAt(_target);
        _transform.position = Vector3.Lerp(_transform.position, _target.position + _offset, 3f*Time.deltaTime);
    }
}
