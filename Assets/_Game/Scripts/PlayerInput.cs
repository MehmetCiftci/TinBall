using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private bool _gameStarted = false;
    private float _startTouchingTime;
    private float _powerPercent;
    
    
    

    [SerializeField] private float maxChargeSeconds = 1f;
    [SerializeField] private float pushPower = 375f;
    [SerializeField] private GameObject ball;

    private Rigidbody _ballRigidBody;

    private void Awake()
    {

        _ballRigidBody = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameStarted)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                
                if (touch.phase == TouchPhase.Began)
                {
                    _startTouchingTime = Time.time;
                    //yayi gerdir
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    if (Time.time - _startTouchingTime >= maxChargeSeconds)
                    {
                        _powerPercent = 1f;
                    }
                    else
                    {
                        _powerPercent = (Time.time - _startTouchingTime) / maxChargeSeconds;
                    }
                    //yayi birak topa vur
                    _ballRigidBody.AddForce(new Vector3(0,0,pushPower * _powerPercent));
                    Debug.Log("add " + pushPower * _powerPercent + " force");
                    //_gameStarted = true;

                }
            }
        }
        else // game started
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                
                if (touch.phase == TouchPhase.Began)
                {
                    //kollari kaldir
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    // kollari indir
                }
            }
        }
    }
}