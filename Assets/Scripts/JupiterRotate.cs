using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JupiterRotate : MonoBehaviour
{
    public GameObject jupiter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jupiter.transform.Rotate(0, 1, 0);
    }
}
