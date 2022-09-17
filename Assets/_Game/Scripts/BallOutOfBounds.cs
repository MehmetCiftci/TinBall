using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOutOfBounds : MonoBehaviour
{
    private Vector3 _startPosition;

    private Rigidbody _rigidBody;
    private void Awake()
    {
        _startPosition = transform.position;
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("OutOfBounds"))
        {
            Debug.Log("restart");
            _rigidBody.velocity = Vector3.zero;
            transform.position = _startPosition;

        }
        
    }

}
