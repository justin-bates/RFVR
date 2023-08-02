using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandTagChecker : MonoBehaviour
{
    XRDirectInteractor interactor;

    void Awake()
    {
        interactor = GetComponent<XRDirectInteractor>();
        interactor.hoverEntered.AddListener(CheckHandTag);
    }

    void CheckHandTag(HoverEnterEventArgs args)
    {
        if (args.interactor.gameObject.CompareTag("rHand"))
        {
            Debug.Log("This is the hand you're looking for");
        }
    }
}
