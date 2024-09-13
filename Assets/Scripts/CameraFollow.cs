using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject cam;
    float distance;
    void Start()
    {
        distance = transform.position.x - cam.transform.position.x;
    }

    void Update()
    {
        cam.transform.position = new Vector3(transform.position.x - distance,
        cam.transform.position.y, cam.transform.position.z);
    }
}
