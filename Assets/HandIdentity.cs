using UnityEngine;

public class HandIdentity : MonoBehaviour
{
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