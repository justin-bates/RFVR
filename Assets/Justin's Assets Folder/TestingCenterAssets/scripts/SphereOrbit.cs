using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SphereOrbit : MonoBehaviour
{
    public GameObject playerHead; // The player's head
    public float radius = 1.0f; // The radius of the orbit
    public float speed = 1.0f; // The speed of the orbit

    private void Update()
    {
        // Ensure the head is defined
        if (playerHead == null)
        {
            // Try to find the head based on the current XR Rig setup
            playerHead = GameObject.Find("Main Camera");
        }

        // Orbit the head if it's defined
        if (playerHead != null)
        {
            // Calculate the new position of the sphere
            float newX = playerHead.transform.position.x + radius * Mathf.Cos(speed * Time.time);
            float newZ = playerHead.transform.position.z + radius * Mathf.Sin(speed * Time.time);

            // Apply the new position
            transform.position = new Vector3(newX, playerHead.transform.position.y, newZ);
        }
    }
}
