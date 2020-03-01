using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusRotate : MonoBehaviour
{
    public GameObject venus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        venus.transform.Rotate(0, 1, 0);
    }
}
