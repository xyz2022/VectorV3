using Oculus.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WatchForReleased : MonoBehaviour
{
    PointableElement pointableElement;
    MotionVectorCalculator motionVectorCalculator;
    EffectsOnReleased effectsOnReleased;
    ObjectTracker objectTracker;
    DrawAxis3D drawAxis3D;
    public TextMeshPro heightAboveOrigin;
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
        PhysicsText.TextSet(heightAboveOrigin, "0.00");
        PhysicsText.TextShow(heightAboveOrigin, false);
        PhysicsText.TextFontSize(heightAboveOrigin, 72);
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
            objectTracker.StopTracking();
            effectsOnReleased.StopTrail();
            drawAxis3D.DrawMainAxis();
            float projectileHeightAboveOrigin = objectTracker.highestPosition.y - objectTracker.initialPosition.y;
            Vector3 textPosition = objectTracker.highestPosition - new Vector3(0, projectileHeightAboveOrigin / 2, 0);
            PhysicsText.TextSet(heightAboveOrigin, projectileHeightAboveOrigin.ToString("0.00") + "m");
            Vector3 finalPositionAdjusted = objectTracker.finalPosition;
            finalPositionAdjusted.y = objectTracker.initialPosition.y;
            Quaternion turn = Quaternion.Euler(Vector3.Cross(Vector3.up, objectTracker.initialPosition - finalPositionAdjusted));
            

            PhysicsText.TextRotate(heightAboveOrigin, turn);
            PhysicsText.TextPosition(heightAboveOrigin, textPosition);
            PhysicsText.TextShow(heightAboveOrigin, true);
        }
    }
}
