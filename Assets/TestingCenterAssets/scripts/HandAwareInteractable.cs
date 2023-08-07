using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAwareInteractable : XRBaseInteractable
{
    private List<XRBaseInteractor> hoverInteractors = new List<XRBaseInteractor>();

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        XRBaseInteractor baseInteractor = args.interactorObject as XRBaseInteractor;
        if (baseInteractor != null)
        {
            hoverInteractors.Add(baseInteractor);
        }
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        XRBaseInteractor baseInteractor = args.interactorObject as XRBaseInteractor;
        if (baseInteractor != null)
        {
            hoverInteractors.Remove(baseInteractor);
        }
    }

    public bool IsHoveredByHand()
    {
        foreach (XRBaseInteractor interactor in hoverInteractors)
        {
            if (interactor is XRDirectInteractor)
            {
                return true;
            }
        }
        return false;
    }

    public XRBaseInteractor GetHoveringHand()
    {
        foreach (XRBaseInteractor interactor in hoverInteractors)
        {
            if (interactor is XRDirectInteractor)
            {
                return interactor;
            }
        }
        return null;
    }
}
