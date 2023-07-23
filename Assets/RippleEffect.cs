using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RippleEffect : MonoBehaviour
{
    private XRSimpleInteractable interactable; // reference to the XRBaseInteractable component

    // This function is called when the ray interactor begins hovering over the object
    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log("Hover started on " + gameObject.name);
    }

    // This function is called when the ray interactor stops hovering over the object
    public void OnHoverExited(HoverExitEventArgs args)
    {
        Debug.Log("Hover ended on " + gameObject.name);
    }

    private void OnEnable()
    {
        // Get the interactable component
        interactable = GetComponent<XRSimpleInteractable>();

        if (interactable != null)
        {
            Debug.Log("Interactable component found on " + gameObject.name);
            // Subscribe to its hover events
            interactable.hoverEntered.AddListener(OnHoverEntered);
            interactable.hoverExited.AddListener(OnHoverExited);
        }
        else
        {
            Debug.Log("Interactable component NOT found on " + gameObject.name);
        }
    }

    private void OnDisable()
    {
        if (interactable != null)
        {
            // Unsubscribe from the hover events when the script is disabled
            interactable.hoverEntered.RemoveListener(OnHoverEntered);
            interactable.hoverExited.RemoveListener(OnHoverExited);
        }
    }
}
