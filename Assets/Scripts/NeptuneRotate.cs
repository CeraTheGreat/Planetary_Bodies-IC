using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeptuneRotate : MonoBehaviour
{
    public GameObject neptune;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        neptune.transform.Rotate(0, 1, 0);
    }
}
