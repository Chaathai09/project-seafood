using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public UnityEngine.Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UnityEngine.Vector3 destination = target.position + offset;
        UnityEngine.Vector3 smoothedPosition = UnityEngine.Vector3.Lerp(transform.position, destination, smoothSpeed * Time.deltaTime);
        transform.position = new UnityEngine.Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
