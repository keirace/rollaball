using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // transform.position = camera position
        // distance between cam and player
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame and runs after all updates are done
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
