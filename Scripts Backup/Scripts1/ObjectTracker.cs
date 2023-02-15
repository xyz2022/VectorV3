using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTracker : MonoBehaviour
{
    public GameObject objectToTrack;
    public Vector3 initialPosition;
    public Vector3 crossoverPosition;
    public Vector3 finalPosition;
    public Vector3 highestPosition;

    private bool tracking;
    private bool highPointFound;
    private float objectYnow;
    private float objectYlast;
    private Vector3 highPoint;
    private int loopCount;


    // Start is called before the first frame update
    void Start()
    {
        tracking = false;
        highestPosition = Vector3.zero;
        initialPosition = Vector3.zero;
        crossoverPosition = Vector3.zero;
        finalPosition = Vector3.zero;

        ResetHighPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(tracking)
        {
            //find peak height
            if (!highPointFound)
            {
                objectYnow = objectToTrack.transform.position.y;
                if (objectYnow > objectYlast)
                    highPoint = objectToTrack.transform.position;
                else if (loopCount > 1)
                {
                    highestPosition = highPoint;
                    highPointFound = true;
                }

                objectYlast = objectYnow;
                loopCount++;
            }

            //find crossover position
        }
    }

    private void ResetHighPoint()
    {
            objectYnow = 0;
            objectYlast = 99999999;
            highPoint = Vector3.zero;
            highPointFound = false;
            loopCount = 0;
    }

    public void StartTracking()
    {
        tracking = true;
        initialPosition = objectToTrack.transform.position;
        ResetHighPoint();
    }
    public void StopTracking()
    {
        finalPosition = objectToTrack.transform.position;
        tracking = false;
    }

 /*   public static Vector3 GetInitialPosition()
    {
        return initialPosition;
    }
    public static Vector3 GetFinalPosition()
    {
        return finalPosition;
    }
  */
}
