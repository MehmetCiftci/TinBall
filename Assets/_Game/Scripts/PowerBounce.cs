using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBounce : MonoBehaviour
{
    [SerializeField] private float explosionPower = 150f;
    private float _explosionRange = 0;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, transform.position, _explosionRange);
            //add animation and sound
        }
    }
}
