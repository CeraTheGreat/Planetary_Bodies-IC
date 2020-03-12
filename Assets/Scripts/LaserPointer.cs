/* This is a script that creates a laser that points from the end of the controller to any object that it hits. With it we could
 * but did not implement a information gathering on a planet if it touched one. 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class LaserPointer : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public GameObject laserPrefab;
    public SteamVR_Action_Boolean pointAction;
    //public Text t;

    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitpoint;
    private GameObject pointingObject;

    // Start is called before the first frame update
    void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
        //t.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointAction.GetState(handType))
        {
            //print("Point!");  //for debugging purposes
            RaycastHit hit;

            //this if statement checks if the RaycastHit hit touches any object
            if(Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 1000f))
            {
                hitpoint = hit.point;
                showLaser(hit);
                if(hit.collider != null)
                {
                    //print("hit!"); //for debugging purposes
                    //ObjectInfo(hit);
                    //t.enabled = true;
                }
            }
            else
            {
                hitpoint = hit.point;
                showLaser(hit);
            }
        }
        else
        {
            laser.SetActive(false);
        }
    }

    //This method takes in a RaycastHit object and resizes the laser prefab to touch the object that the RaycastHit object touched as well
    private void showLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitpoint, .5f);
        laserTransform.LookAt(hitpoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
    }

    //This method would have been implemented to get any object info that the RaycastHit touched
    private void ObjectInfo(RaycastHit hit)
    {
        pointingObject = hit.collider.gameObject;
        //pointingObject.GetComponent<Renderer>().material.color = Color.blue;
        //print(pointingObject.GetComponent<Text>().text);
    }
}
