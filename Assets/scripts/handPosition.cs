using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPositionLogger : MonoBehaviour
{
    private XRDirectInteractor handInteractor;

    void Start()
    {
        handInteractor = GetComponent<XRDirectInteractor>();
    }

    void Update()
    {
       /* if (handInteractor)
        {
            Debug.Log("Hand Y-Position: " + handInteractor.transform.position.y);
        } */
    }
}





