using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 10f;
    
    private void Update()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }
}