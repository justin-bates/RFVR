using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandIdentity : MonoBehaviour
{
    public XRBaseInteractor interactor;
    public bool isLeft;

    // Static references to the left and right hands
    public static HandIdentity LeftHand { get; private set; }
    public static HandIdentity RightHand { get; private set; }

    private void Awake()
    {
        // Set the static references in Awake
        if (isLeft)
        {
            LeftHand = this;
            Debug.Log("Left hand initialized.");
        }
        else
        {
            RightHand = this;
            Debug.Log("Right hand initialized.");
        }

    }

    // Hover event handlers
    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log((isLeft ? "Left" : "Right") + " hand started hovering with " + args.interactorObject);
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        Debug.Log((isLeft ? "Left" : "Right") + " hand stopped hovering over " + args.interactorObject);
    }

    // Method to check which hand is higher
    public static HandIdentity GetHigherHand()
    {
        // Check if both hands are initialized
        if (LeftHand == null || RightHand == null)
        {
            Debug.LogError("Both hands have not been initialized.");
            return null;
        }

        // Compare the y coordinates of both hands
        if (LeftHand.transform.position.y > RightHand.transform.position.y)
        {
            return LeftHand;
        }
        else
        {
            return RightHand;
        }
    }
}


