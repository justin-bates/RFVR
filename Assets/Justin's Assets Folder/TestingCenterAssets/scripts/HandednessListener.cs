using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandednessListener : MonoBehaviour
{
    // Reference to the XRSimpleInteractable component
    private XRSimpleInteractable simpleInteractable;

    private void Awake()
    {
        simpleInteractable = GetComponent<XRSimpleInteractable>();

        // Bind to the hover event
        simpleInteractable.hoverEntered.AddListener(HandednessHandler);
    }

    public void HandednessHandler(HoverEnterEventArgs args)
    {
        XRBaseInteractor interactor = args.interactorObject.transform.GetComponent<XRBaseInteractor>();

        if (interactor)
        {
            //gotem
            Debug.Log(interactor.transform.parent.name);
        }
        else
        {
            Debug.Log("null");
        }
    }
}
