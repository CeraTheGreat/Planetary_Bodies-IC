/* This scrip takes input from the controller and when that input is given it changes the speed variable from 1 to 3.
 * This was attached to the sun so that all the planets could access the speed multiplier easily.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlanetSpeedup : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean speedupAction;
    private float speedMultiplyer;

    public AudioSource music;

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
            //print("Speed!");      //for debugging purposes
            speedMultiplyer = 3;
            music.pitch = 3;
        }
        else
        {
            speedMultiplyer = 1;
            music.pitch = 1;
        }
    }

    //This method allows the planets, or any object, to gain access to the speed multiplyer varible
    public float getSpeedup()
    {
        return speedMultiplyer;
    }
}
