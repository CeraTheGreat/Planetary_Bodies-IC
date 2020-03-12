/* This script was used to help our understanding of how to attach code to actions. It was only ever used in our test scence with the balls,
 * block and cylinder
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerGrabObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    private GameObject collidingObject;
    private GameObject objectInHand;

    // Update is called once per frame
    void Update()
    {
        //checks if the the button desired was pressed, if it was it continues
        if (grabAction.GetLastStateDown(handType))
        {
            //print("grab action?"); // for debugging purposes
            if (collidingObject)
            {
                GrabObject();
                //print("Grabed?"); // for debugging purposes
            }
        }

        //checks if the button was released
        if (grabAction.GetLastStateUp(handType))
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }

    // This method sets what object is the colliding object
    private void SetCollidingObject(Collider col)
    {
        if(collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }

        collidingObject = col.gameObject;
    }

    // This method sets what object is being entered by the controller
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
        //print("Enter!"); // for debuggin purposes
    }

    // This method allows the object that the controller is resting in to be the object that it is colliding with
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // Once the controller exits the object it the colliding object is null
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return ;
        }

        collidingObject = null;
        //print("Exit!"); // for debugging purposes
    }

    // This method attaches the object colliding with the controller to the controller
    private void GrabObject()
    {
        //switching objects
        objectInHand = collidingObject;
        collidingObject = null;

        var joint = addFixedJoint();

        //this method connects the joint to the object
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    //This method adds a joint to the controller with a high breaking point so you can swing the object around and not lose connection
    private FixedJoint addFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    //  This method destroys the joint between the object in hand and the controller. It also preserves the angular and directional velocity
    // of the object so that you can throw the object.
    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();
        }

        objectInHand = null;
    }
}