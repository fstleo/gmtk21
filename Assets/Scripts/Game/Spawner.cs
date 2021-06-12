using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform _from;
    
    [SerializeField]
    private Transform _to;
    
    [SerializeField]
    private GameObject _prefab;
    

    [SerializeField]
    private float _spawnCooldown;

    private float _cooldown;

    private void Update()
    {
        _cooldown -= Time.deltaTime;
        if (_cooldown < 0)
        {
            _cooldown = _spawnCooldown;
            Spawn();
        }
    }

    private void Spawn()
    {
        Instantiate(_prefab, Vector3.Lerp(_from.position, _to.position, Random.Range(0f, 1f)), Quaternion.identity).transform.forward = _from.forward;
    }
}
