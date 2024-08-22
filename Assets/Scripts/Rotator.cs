using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // spin
        // translate & rotate to affect the transform of the object
        // deltaTime = diff in seconds since the last update occured
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
