using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringDoorController : MonoBehaviour
{
    [SerializeField] private float closedAngle = 0f;
    [SerializeField] private float openAngle = 40f;
    
    
    [SerializeField] private float openAfterThisSeconds = 15f;
    private float _lastCloseTime;

    private HingeJoint _hingeJoint;
    private JointSpring _spring;

    private void Awake()
    {
        _hingeJoint = GetComponent<HingeJoint>();
        _spring = _hingeJoint.spring;
        _lastCloseTime = Time.time;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (_lastCloseTime + openAfterThisSeconds <= Time.time)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        _spring.targetPosition = openAngle;
        _hingeJoint.spring = _spring;
    }

    public void CloseDoor()
    {
        _lastCloseTime = Time.time;
        _spring.targetPosition = closedAngle;
        _hingeJoint.spring = _spring;
        
    }
}
