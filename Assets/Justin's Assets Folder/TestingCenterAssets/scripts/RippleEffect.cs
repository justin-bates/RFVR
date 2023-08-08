using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RippleEffect : MonoBehaviour
{
    public GameObject rippleEffectPrefab;

    private XRSimpleInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        // Add listeners for hover events
        interactable.hoverEntered.AddListener(HoverEntered);
        interactable.hoverExited.AddListener(HoverExited);
    }

    private void OnDestroy()
    {
        // Remove listeners for hover events
        interactable.hoverEntered.RemoveListener(HoverEntered);
        interactable.hoverExited.RemoveListener(HoverExited);
    }

    private void HoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log("Hover started on " + gameObject.name);

        // Get the hit point from the interactor's attach point
        Vector3 hitPoint = args.interactorObject.transform.position;

        // Instantiate a ripple effect at the hit point
        Instantiate(rippleEffectPrefab, hitPoint, Quaternion.identity);
    }

    private void HoverExited(HoverExitEventArgs args)
    {
        Debug.Log("Hover ended on " + gameObject.name);
    }
}
