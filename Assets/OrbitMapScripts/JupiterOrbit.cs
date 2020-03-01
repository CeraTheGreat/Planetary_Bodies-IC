using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JupiterOrbit : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 sun = new Vector3(0.0f, 2.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(sun, Vector3.up, 30 * Time.deltaTime);
    }
}
