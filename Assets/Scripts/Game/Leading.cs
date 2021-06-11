using UnityEngine;

public class Leading : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _maxDistance = 5;

    public void Update()
    {
        if ((transform.position - _target.position).sqrMagnitude > _maxDistance * _maxDistance)
        {
            _target.forward = transform.position - _target.position;
        }
    }
}