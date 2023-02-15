using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class WatchForReleased : MonoBehaviour
{
    // Start is called before the first frame update
    PointableElement pointableElement;
    MotionVectorCalculator motionVectorCalculator;
    EffectsOnReleased effectsOnReleased;
    ObjectTracker objectTracker;
    DrawAxis3D drawAxis3D;

    //Grabbable grabbable;
    bool wasHeld, isHeld;
    int heldState;
    bool waitingCollision;

    void Start()
    {
        motionVectorCalculator = GetComponent<MotionVectorCalculator>();
        pointableElement = GetComponent<PointableElement>();
        effectsOnReleased = GetComponent<EffectsOnReleased>();
        objectTracker = GetComponent <ObjectTracker>();
        drawAxis3D = GetComponent<DrawAxis3D>();

        wasHeld = false;
        isHeld = false;
        waitingCollision = false;
    }

    void LateUpdate()
    {
        isHeld = false;
        heldState = pointableElement.SelectingPointsCount;
        if (heldState == 1)
            isHeld = true;
        if (!isHeld && wasHeld)
        {
            effectsOnReleased.Invoke("StartTrail", 0);
            motionVectorCalculator.Invoke("ApplyMotionToTransform", 0);
            objectTracker.Invoke("StartTracking", 0);

            waitingCollision = true;
            
        }
        wasHeld = isHeld;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (waitingCollision)
        {
            objectTracker.Invoke("StopTracking", 0);
            effectsOnReleased.Invoke("StopTrail", 0);
            drawAxis3D.Invoke("DrawMainAxis", 0);
        }
    }
}
