using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speedZ = 7;
    private float accelerationTime = 60;
    private float maxSpeed = 20;
    private float time;

    private void Start()
    {
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        // move the road backward and increase speed over time
        float currentSpeedZ = Mathf.SmoothStep(speedZ, maxSpeed, time / accelerationTime);
        transform.position -= new Vector3(0, 0, currentSpeedZ) * Time.deltaTime;
        time += Time.deltaTime;
    }
}
