using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _speed;
    
    private Transform _transform;
    private Camera _camera;

    [SerializeField] private float _viewportFrameWidth = 0.2f;

    private void Awake()
    {
        _transform = transform;
        _camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        var viewportPosition = _camera.WorldToViewportPoint(_target.position);
        if (viewportPosition.x < _viewportFrameWidth)
        {
            _transform.position += Vector3.left  * (_speed * Time.deltaTime);
        }
        if (viewportPosition.x > 1 - _viewportFrameWidth)
        {
            _transform.position -= Vector3.left  * (_speed * Time.deltaTime);
        }
        if (viewportPosition.y < _viewportFrameWidth)
        {
            _transform.position -= Vector3.forward  * (_speed * Time.deltaTime);
        }
        if (viewportPosition.y > 1 - _viewportFrameWidth)
        {
            _transform.position += Vector3.forward  * (_speed * Time.deltaTime);
        }
        
    }
}
