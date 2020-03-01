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

    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitpoint;
    private GameObject pointingObject;

    // Start is called before the first frame update
    void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointAction.GetState(handType))
        {
            print("Point!");
            RaycastHit hit;
            if(Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100f))
            {
                hitpoint = hit.point;
                showLaser(hit);
                if(hit.collider != null)
                {
                    print("hit!");
                    ObjectInfo(hit);
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

    private void showLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitpoint, .5f);
        laserTransform.LookAt(hitpoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
    }

    private void ObjectInfo(RaycastHit hit)
    {
        pointingObject = hit.collider.gameObject;
        //pointingObject.GetComponent<Renderer>().material.color = Color.blue;
        //print(pointingObject.GetComponent<Text>().text);
    }
}
