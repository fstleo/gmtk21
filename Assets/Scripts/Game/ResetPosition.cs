using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            other.transform.position -= _offset;
        }
    }
}