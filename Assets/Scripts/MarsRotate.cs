using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsRotate : MonoBehaviour
{
    public GameObject mars;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mars.transform.Rotate(0, 1, 0);
    }
}
