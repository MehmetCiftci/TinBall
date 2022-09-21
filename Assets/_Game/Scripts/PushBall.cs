using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBall : MonoBehaviour
{
    [SerializeField] private float pushPower = 425f;
    [SerializeField] private float waitSeconds = 1f;
    private GameObject _ball;

    private Rigidbody _ballRigidBody;
    private bool _isPushing = false;

    private float _powerPercent = 1f;
    [SerializeField] private GameObject springDoor;
    private SpringDoorController _springDoorController;

    private void Awake()
    {
        _ball = GameObject.FindWithTag("Ball");
        _ballRigidBody = _ball.GetComponent<Rigidbody>();
        _springDoorController = springDoor.GetComponent<SpringDoorController>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (!_isPushing)
            {
                StartCoroutine("StartPushingBall");
            }
        }
        
    }

    private IEnumerator StartPushingBall()
    {
        _isPushing = true;

        yield return new WaitForSeconds(waitSeconds);
        
        _ballRigidBody.AddForce(new Vector3(0,0,pushPower * _powerPercent));

        yield return new WaitForSeconds(0.5f);
        _springDoorController.CloseDoor();
        
        _isPushing = false;
    }
}
