using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MotionVectorCalculator : MonoBehaviour
{
    
    Rigidbody rigidbodyToApplyForce;
    public float strengthMultiplyer = 1.0f;

    void Awake()
    {
        rigidbodyToApplyForce = GetComponent<Rigidbody>();

    }

    public void ApplyMotionToTransform()
    {
        rigidbodyToApplyForce.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RHand) * strengthMultiplyer;
        rigidbodyToApplyForce.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RHand);  
    }
}
