using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomInteractable : XRBaseInteractable
{
    public void HandleHoverEnter(HoverEnterEventArgs args)
    {
        Debug.Log($"Hover entered by {args.interactorObject}");
    }

    public void HandleHoverExit(HoverExitEventArgs args)
    {
        Debug.Log($"Hover exited by {args.interactorObject}");
    }
}
