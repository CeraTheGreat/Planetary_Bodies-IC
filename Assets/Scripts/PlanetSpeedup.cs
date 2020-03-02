using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlanetSpeedup : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean speedupAction;
    private float speedMultiplyer;

    // Start is called before the first frame update
    void Start()
    {
        speedMultiplyer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (speedupAction.GetState(handType))
        {
            print("Speed!");
            speedMultiplyer = 3;
        }
        else
        {
            speedMultiplyer = 1;
        }
    }

    public float getSpeedup()
    {
        return speedMultiplyer;
    }
}
