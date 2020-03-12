/* This script was used to test if when a button was pressed the system would recognize it
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionTest : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabAction;

    // Update is called once per frame
    void Update()
    {
        if (getGrab())
        {
            print("Grab " + handType);
        }
    }

    // This method returns whether or not the specified button is pressed
    public bool getGrab()
    {
        return grabAction.GetState(handType);
    }
}
