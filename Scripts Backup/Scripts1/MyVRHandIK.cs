using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class MyVRHandIK : MonoBehaviour
{
    //Right Hand
    public ChainIKConstraint rightIndexChainIK;
    public Transform rightIndexOpenTarget;
    public Transform rightIndexClosedTarget;
    //
    public ChainIKConstraint rightMiddleChainIK;
    public Transform rightMiddleOpenTarget;
    public Transform rightMiddleClosedTarget;
    //
    public ChainIKConstraint rightRingChainIK;
    public Transform rightRingOpenTarget;
    public Transform rightRingClosedTarget;
    //
    public ChainIKConstraint rightPinkyChainIK;
    public Transform rightPinkyOpenTarget;
    public Transform rightPinkyClosedTarget;
    //
    public ChainIKConstraint rightThumbChainIK;
    public Transform rightThumbOpenTarget;
    public Transform rightThumbClosedTarget;
    //-----------------------
    //Left Hand
    public ChainIKConstraint leftIndexChainIK;
    public Transform leftIndexOpenTarget;
    public Transform leftIndexClosedTarget;
    //
    public ChainIKConstraint leftMiddleChainIK;
    public Transform leftMiddleOpenTarget;
    public Transform leftMiddleClosedTarget;
    //
    public ChainIKConstraint leftRingChainIK;
    public Transform leftRingOpenTarget;
    public Transform leftRingClosedTarget;
    //
    public ChainIKConstraint leftPinkyChainIK;
    public Transform leftPinkyOpenTarget;
    public Transform leftPinkyClosedTarget;
    //
    public ChainIKConstraint leftThumbChainIK;
    public Transform leftThumbOpenTarget;
    public Transform leftThumbClosedTarget;

    private Vector3 r_index_open;
    private Vector3 r_index_closed;
    private Vector3 r_middle_open;
    private Vector3 r_middle_closed;
    private Vector3 r_ring_open;
    private Vector3 r_ring_closed;
    private Vector3 r_pinky_open;
    private Vector3 r_pinky_closed;
    private Vector3 r_thumb_open;
    private Vector3 r_thumb_closed;

    private Vector3 l_index_open;
    private Vector3 l_index_closed;
    private Vector3 l_middle_open;
    private Vector3 l_middle_closed;
    private Vector3 l_ring_open;
    private Vector3 l_ring_closed;
    private Vector3 l_pinky_open;
    private Vector3 l_pinky_closed;
    private Vector3 l_thumb_open;
    private Vector3 l_thumb_closed;

    private float f;

    private float thumbLerpRight;
    private float thumbLerpLeft;
    private float thumbSpeed;
    // Start is called before the first frame update
    void Start()
    {
        r_index_open = rightIndexOpenTarget.localPosition;
        r_index_closed = rightIndexClosedTarget.localPosition;
        r_middle_open = rightMiddleOpenTarget.localPosition;
        r_middle_closed = rightMiddleClosedTarget.localPosition;
        r_ring_open = rightRingOpenTarget.localPosition;
        r_ring_closed = rightRingClosedTarget.localPosition;
        r_pinky_open = rightPinkyOpenTarget.localPosition;
        r_pinky_closed = rightPinkyClosedTarget.localPosition;
        r_thumb_open = rightThumbOpenTarget.localPosition;
        r_thumb_closed = rightThumbClosedTarget.localPosition;

        l_index_open = leftIndexOpenTarget.localPosition;
        l_index_closed = leftIndexClosedTarget.localPosition;
        l_middle_open = leftMiddleOpenTarget.localPosition;
        l_middle_closed = leftMiddleClosedTarget.localPosition;
        l_ring_open = leftRingOpenTarget.localPosition;
        l_ring_closed = leftRingClosedTarget.localPosition;
        l_pinky_open = leftPinkyOpenTarget.localPosition;
        l_pinky_closed = leftPinkyClosedTarget.localPosition;
        l_thumb_open = leftThumbOpenTarget.localPosition;
        l_thumb_closed = leftThumbClosedTarget.localPosition;

        thumbLerpRight = 0;
        thumbLerpLeft = 0;
        thumbSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        //OVRInput.Update();
        f = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        rightIndexChainIK.data.target.localPosition = Vector3.Lerp(r_index_open, r_index_closed, f);
        f = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        rightMiddleChainIK.data.target.localPosition = Vector3.Lerp(r_middle_open, r_middle_closed, f);
        rightRingChainIK.data.target.localPosition = Vector3.Lerp(r_ring_open, r_ring_closed, f);
        rightPinkyChainIK.data.target.localPosition = Vector3.Lerp(r_pinky_open, r_pinky_closed, f);

        f = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
        leftIndexChainIK.data.target.localPosition = Vector3.Lerp(l_index_open, l_index_closed, f);
        f = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        leftMiddleChainIK.data.target.localPosition = Vector3.Lerp(l_middle_open, l_middle_closed, f);
        leftRingChainIK.data.target.localPosition = Vector3.Lerp(l_ring_open, l_ring_closed, f);
        leftPinkyChainIK.data.target.localPosition = Vector3.Lerp(l_pinky_open, l_pinky_closed, f);

        //Thumb Movement has extra steps because its a button not an axis
        AnimateThumbRight();
        AnimateThumbLeft();


    }

    void AnimateThumbRight()
    {
        //Check for thumb pressed. If not pressed, check for touch. Set pres as 100% (1) and touch as 50% (0.5)
        bool thumb = OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch);
        float target = thumb ? 1 : 0.001f;
        float increment = thumbSpeed * Time.deltaTime; 
        if (thumb && thumbLerpRight < target)
            thumbLerpRight += increment;
        else if (!thumb && thumbLerpRight > target)
            thumbLerpRight -= increment;

        rightThumbChainIK.data.target.localPosition = Vector3.Lerp(r_thumb_open, r_thumb_closed, thumbLerpRight);
    }
    void AnimateThumbLeft()
    {
        //Check for thumb pressed. If not pressed, check for touch. Set pres as 100% (1) and touch as 50% (0.5)
        bool thumb = OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch);
        float target = thumb ? 1 : 0.001f;
        float increment = thumbSpeed * Time.deltaTime;
        if (thumb && thumbLerpLeft < target)
            thumbLerpLeft += increment;
        else if (!thumb && thumbLerpLeft > target)
            thumbLerpLeft -= increment;

        leftThumbChainIK.data.target.localPosition = Vector3.Lerp(l_thumb_open, l_thumb_closed, thumbLerpLeft);
    }
}
