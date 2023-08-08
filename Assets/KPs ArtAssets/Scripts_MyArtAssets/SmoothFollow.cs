using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;

    [Range(0, 1)]
    public float positionDamping;

    [Range(0, 1)]
    public float rotationDamping;

    void OnEnable()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    void Update()
    {
        //slow down when close
        transform.position = Vector3.Lerp(transform.position, target.position, positionDamping);

        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationDamping);
    }
}
