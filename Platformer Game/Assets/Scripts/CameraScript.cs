using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject target;
    public float distance = 10.0f;
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x,target.transform.position.y,target.transform.position.z-distance);
    }
}
