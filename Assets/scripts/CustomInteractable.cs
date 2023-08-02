using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomInteractable : XRBaseInteractable
{
    public void HandleHoverEnter(HoverEnterEventArgs args)
    {
        Debug.Log($"Hover entered by {args.interactorObject}");
        Debug.Log("HandleHoverEnter Called");
    }

    public void HandleHoverExit(HoverExitEventArgs args)
    {
        Debug.Log($"Hover exited by {args.interactorObject}");
        Debug.Log("HandleHoverExit Called");
    }
}
