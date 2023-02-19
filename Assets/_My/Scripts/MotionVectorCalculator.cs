using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MotionVectorCalculator : MonoBehaviour
{
    
    Rigidbody rigidbodyToApplyForce;
    public float strengthMultiplyer = 1.0f;
    private float speed;
    private float angle;

    void Awake()
    {
        rigidbodyToApplyForce = GetComponent<Rigidbody>();
        speed = 0;

    }

    public void ApplyMotionToTransform()
    {
        rigidbodyToApplyForce.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RHand) * strengthMultiplyer;
        rigidbodyToApplyForce.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RHand);
        speed = rigidbodyToApplyForce.velocity.magnitude;
        angle = Mathf.Atan2(rigidbodyToApplyForce.velocity.y, rigidbodyToApplyForce.velocity.x);
        angle *= Mathf.Rad2Deg;
    }
    public float GetSpeed()
    {
        return speed;
    }
    public float GetAngle()
    {
        return angle;
    }
}
