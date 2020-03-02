using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{

    public GameObject parentBody;
    public Vector3 rotationAxis;
    public float orbialPeriod;
    public float rotationalPeriod;
    private GameObject satelite;
    private Vector3 orbitAxis;
    private float deltaOrbitalAngle;
    private float deltaRotationalAngle;
    private float speedup;

 


    // Start is called before the first frame update
    void Start()
    {
        satelite = this.gameObject;
        orbitAxis = new Vector3(0f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        speedup = parentBody.GetComponent<PlanetSpeedup>().getSpeedup();

        deltaRotationalAngle = (360f / rotationalPeriod) * speedup;
        deltaOrbitalAngle = (360f / orbialPeriod) * speedup;
        
        satelite.transform.RotateAround(parentBody.transform.position, orbitAxis, Time.deltaTime * deltaOrbitalAngle);
        satelite.transform.Rotate(0f, Time.deltaTime * deltaRotationalAngle, 0f);
    }
}
