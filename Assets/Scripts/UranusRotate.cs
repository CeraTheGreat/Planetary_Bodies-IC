using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranusRotate : MonoBehaviour
{
    public GameObject uranus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uranus.transform.Rotate(0, 1, 0);
    }
}
