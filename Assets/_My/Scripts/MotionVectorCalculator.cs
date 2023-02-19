using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MotionVectorCalculator : MonoBehaviour
{
    
    Rigidbody rigidbodyToApplyForce;
    public float strengthMultiplyer = 1.0f;
    private Vector3 lastLaunchVelocity;
    private Vector3 lastAngularVelocity;
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
        
        lastLaunchVelocity = rigidbodyToApplyForce.velocity;
        lastAngularVelocity = rigidbodyToApplyForce.angularVelocity;

        Vector3 direction = lastLaunchVelocity.normalized; // Example direction vector
        Vector3 directionProjection = Vector3.ProjectOnPlane(direction, Vector3.up); // Project direction onto the horizontal plane
        angle = Vector3.Angle(direction, directionProjection);
        speed = rigidbodyToApplyForce.velocity.magnitude;
    }
    public void ReapplyMotionToTransform()
    {
        rigidbodyToApplyForce.velocity = lastLaunchVelocity;
        rigidbodyToApplyForce.angularVelocity = lastAngularVelocity;

        Vector3 direction = lastLaunchVelocity.normalized; // Example direction vector
        Vector3 directionProjection = Vector3.ProjectOnPlane(direction, Vector3.up); // Project direction onto the horizontal plane
        angle = Vector3.Angle(direction, directionProjection);
        speed = rigidbodyToApplyForce.velocity.magnitude;
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
