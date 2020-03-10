using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionTest : MonoBehaviour
{
    public SteamVR_Input_Sources handType; // 1
    public SteamVR_Action_Boolean grabAction; // 2

    // Update is called once per frame
    void Update()
    {
        if (getGrab())
        {
            print("Grab " + handType);
        }
    }

    public bool getGrab()
    {
        return grabAction.GetState(handType);
    }
}
