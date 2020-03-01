using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaturnRotate : MonoBehaviour
{
    public GameObject saturn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        saturn.transform.Rotate(0, 1, 0);
    }
}
