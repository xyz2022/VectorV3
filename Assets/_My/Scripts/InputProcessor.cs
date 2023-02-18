using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputProcessor : MonoBehaviour
{
    SwitchWorlds switchWorlds;
    // Start is called before the first frame update
    void Start()
    {
        switchWorlds = gameObject.GetComponent<SwitchWorlds>();
    }

    // Update is called once per frame
    void Update()
    {
        bool switchNow = OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch);
        if (switchNow)
            switchWorlds.ActivateNext();
    }
}
