using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherController : MonoBehaviour
{
    [SerializeField] private float restAngle = 0f;
    [SerializeField] private float pushAngle = 45f;

    private HingeJoint _hingeJoint;
    private JointSpring _spring;

    private void Awake()
    {
        _hingeJoint = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
                
            _spring = _hingeJoint.spring;
            
            if (touch.phase == TouchPhase.Began)
            {
                _spring.targetPosition = pushAngle;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                _spring.targetPosition = restAngle;
            }

            _hingeJoint.spring = _spring;
        }
    }
}
