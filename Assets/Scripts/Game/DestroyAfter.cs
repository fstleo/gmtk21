using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    private float _lifeTime = 10f;

    public void Init(float lifeTime)
    {
        _lifeTime = lifeTime;
    }
    
    private void Update()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }
}