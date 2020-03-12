/*This script takes in multiple parameters to set the orbit speed and rotation speed of each planet along with setting the size of the trail.
 * We created it to be have a generic public parentBody game object so that we could apply this script to every planet and have the Sun be
 * the "parent" of the planets so that they would orbit the sun. This script was generic enought that we could implement it to satellites
 * such as moons orbiting a planet
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    public GameObject ringPrefab;
    public GameObject parentBody;
    public Vector3 rotationAxis;
    public float orbialPeriod;
    public float rotationalPeriod;
    public float ringThickness = 0.05f;
  


    private GameObject satelite;
    private Vector3 orbitAxis;
    private float deltaOrbitalAngle;
    private float deltaRotationalAngle;
    private float speedup;



    // Start is called before the first frame update
    void Start()
    {
        GameObject ringInstance = Instantiate(ringPrefab, parentBody.transform.position, Quaternion.identity);
        satelite = this.gameObject;
        orbitAxis = new Vector3(0f, 1f, 0f);
        
        //getting the distance to the sun from the planet
        float distanceToParent = Vector3.Distance(satelite.transform.position, parentBody.transform.position);

        //Setting the size of the trail line
        ringInstance.transform.localScale = new Vector3(distanceToParent *2f , ringThickness, distanceToParent *2f);
    }

    // Update is called once per frame
    void Update()
    {
        //the PlanetSpeedup script is attached to the sun so that every planet can get the same speedup from the sun when the trigger is pulled
        //more details in the PlanetSpeedup script
        speedup = parentBody.GetComponent<PlanetSpeedup>().getSpeedup();

        //Setting the speeds of the rotation and orbit variables
        deltaRotationalAngle = -(360f / rotationalPeriod) * speedup;
        deltaOrbitalAngle = -(360f / orbialPeriod) * speedup;
        
        //Actually implementing a rotation and orbit around a parent object
        satelite.transform.RotateAround(parentBody.transform.position, orbitAxis, Time.deltaTime * deltaOrbitalAngle);
        satelite.transform.Rotate(0f, Time.deltaTime * deltaRotationalAngle, 0f);
    }
}
